DROP FUNCTION IF EXISTS ufn_IntToStr;

CREATE FUNCTION ufn_IntToStr(int_val INT)
  RETURNS varchar(255)
BEGIN
  RETURN CONVERT(int_val, CHAR);
END;

DROP FUNCTION IF EXISTS ufn_CreatePath;
CREATE FUNCTION ufn_CreatePath(parent_path VARCHAR(350), current_id INT)
  RETURNS varchar(350)
BEGIN
  	IF parent_path IS NULL THEN
		  RETURN cast(current_id as CHAR);
    END IF;
	RETURN CONCAT(parent_path, '.', ufn_IntToStr(current_id));
END;

DROP FUNCTION IF EXISTS ufn_GetParentPath;
CREATE FUNCTION ufn_GetParentPath(path VARCHAR(350))
  RETURNS varchar(350)
BEGIN
	DECLARE pos INT;
	DECLARE ind INT;
	DECLARE len INT;
	DECLARE res VARCHAR(350);
	SET pos = -1;
	IF path IS NOT NULL THEN
		SET len = char_length(path);
		SET pos = locate('.', path);
		IF pos = 0 THEN
			RETURN res;
		END IF;

		SET ind = pos;
		WHILE pos > 0 DO
			SET pos = LOCATE('.', path, pos + 1);
			IF pos > 0 THEN
				SET ind = pos;
      END IF;
		END WHILE;
		SET res = substring(path, 1, ind - 1);
	END IF;
	RETURN res;
END;

DROP FUNCTION IF EXISTS ufn_GetLastOpIdForDevice;
CREATE FUNCTION `ufn_GetLastOpIdForDevice`(
        `device_id` INTEGER
    )
    RETURNS INTEGER(11)
    NOT DETERMINISTIC
    CONTAINS SQL
    SQL SECURITY DEFINER
    COMMENT ''
BEGIN
  declare res INTEGER;
  select max(Id) into res
  from `ophistories`
  where IdNode = device_id;
  RETURN res;
END;

DROP FUNCTION IF EXISTS ufn_GetDisplayPath;
CREATE FUNCTION ufn_GetDisplayPath(
        in_path VARCHAR(350)
    )
    RETURNS VARCHAR(1024) CHARACTER SET utf8
    DETERMINISTIC
    READS SQL DATA
    SQL SECURITY DEFINER
    COMMENT ''
BEGIN
  declare _pos int;
  declare _result VARCHAR(1024);
  declare _stringId VARCHAR(11);
  declare _dn VARCHAR(1024);

  set _pos = LOCATE('.', in_path);
  set _result = '';
  REPEAT
  	if _pos > 0 then
	    SET _stringId = substring(in_path, 1, _pos - 1);
      select DisplayName into _dn from Nodes where Id = CONVERT(_stringId, UNSIGNED);
      if CHAR_LENGTH(_result) = 0 then
        set _result = _dn;
      else
        set _result = CONCAT(_result, '\\', _dn);
      end if;
      set in_path = substring(in_path, _pos + 1, CHAR_LENGTH(in_path) - _pos);
      SET _pos = LOCATE('.', in_path);
    end if;
		UNTIL  _pos = 0 END REPEAT;

    if CHAR_LENGTH(in_path) > 0 then
      select DisplayName into _dn from Nodes where Id = CONVERT(in_path, UNSIGNED);
      if CHAR_LENGTH(_result) = 0 then
        set _result = _dn;
      else
        set _result = CONCAT(_result, '\\', _dn);
      end if;
    end if;
RETURN _result;
END;

DROP PROCEDURE IF EXISTS usp_GetDeviceNodeEx;
CREATE PROCEDURE `usp_GetDeviceNodeEx`()
    NOT DETERMINISTIC
    CONTAINS SQL
    SQL SECURITY DEFINER
    COMMENT ''
BEGIN
select 
	n.*
  , `ufn_GetDisplayPath`(n.Path) as DisplayPath
  , h.`IsError`
  from 
  	`nodes` n
    left join `ophistories` h on (n.`Id` = h.`IdNode`
    and h.`Id`= ufn_GetLastOpIdForDevice(h.`IdNode`))
  where 
  	n.`Kind` = 2;
END;

DROP PROCEDURE IF EXISTS usp_AddNode;
CREATE PROCEDURE usp_AddNode(
        IN `idown` INTEGER,
        IN `kind` TINYINT,
        IN `displayname` VARCHAR(100),
        IN `description` VARCHAR(1024),
        IN `ipaddress` VARCHAR(15),
        IN `password` VARCHAR(30),
        IN `estcommstateguid` VARCHAR(80),
		IN `devtype` TINYINT,
        OUT `new_id` INTEGER,
        OUT `new_path` VARCHAR(350),
        OUT `new_display_path` VARCHAR(1024)
    )
    NOT DETERMINISTIC
    CONTAINS SQL
    SQL SECURITY DEFINER
    COMMENT ''
BEGIN
  DECLARE parent_path varchar(350);
  SELECT path FROM Nodes WHERE Id = idown INTO parent_path;
  INSERT INTO Nodes (IdOwn, Kind, DisplayName, Description, Path, IpAddress, Password, EstCommStateGuid, DevType) VALUES (idown, kind, displayname, description, '0', ipaddress, password, estcommstateguid, devtype);
  SELECT LAST_INSERT_ID() INTO new_id;
	SET new_path = ufn_CreatePath(parent_path, new_id);
  UPDATE Nodes set Nodes.Path = new_path WHERE Nodes.Id = new_id;
  SET new_display_path = `ufn_GetDisplayPath`(new_path);
END;

DROP PROCEDURE IF EXISTS usp_DeleteNode;
CREATE PROCEDURE usp_DeleteNode(IN id INT)
BEGIN
  DECLARE current_path VARCHAR(350);
  SELECT path FROM Nodes WHERE Nodes.Id = id INTO current_path;
  DELETE FROM Nodes
  WHERE Nodes.Path = current_path OR
    Nodes.Path LIKE CONCAT(current_path, '.%');
END;

DROP PROCEDURE IF EXISTS usp_GetNodeDisplayPath;
CREATE PROCEDURE usp_GetNodeDisplayPath(
        IN node_id INTEGER
    )
    NOT DETERMINISTIC
    READS SQL DATA
    SQL SECURITY DEFINER
    COMMENT ''
BEGIN
	select `ufn_GetDisplayPath`(Path) as DisplayPath
  from `nodes`
  where Id = node_id;
END;

DROP PROCEDURE IF EXISTS usp_GetLastOp;
CREATE PROCEDURE usp_GetLastOp()
    NOT DETERMINISTIC
    READS SQL DATA
    SQL SECURITY DEFINER
    COMMENT ''
BEGIN
  select 	n.`DisplayName` 
    ,n.`IpAddress`
    , `ufn_GetDisplayPath`(n.Path) as DisplayPath
    , h.`IsError`
    , h.`OpName`
    , h.`OpDate`
    , h.`OpResult`
    , h.`ObjText`
    from 
      `nodes` n
      left join `ophistories` h on (n.`Id` = h.`IdNode`
      and h.`Id`= ufn_GetLastOpIdForDevice(h.`IdNode`))
    where 
      n.`Kind` = 2
    order by n.`DisplayName`;
END;
