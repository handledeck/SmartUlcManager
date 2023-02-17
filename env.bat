@echo off
SET xOS=x86
SET VER_VS=Current
IF Defined PROCESSOR_ARCHITEW6432 (SET xOS=x64) ELSE IF "%PROCESSOR_ARCHITECTURE%"=="AMD64" SET xOS=x64

SET EDITION=Community
SET VS_PATH=C:\Program Files (x86)\Microsoft Visual Studio\2019
rem IF %xOS%==x86 (SET VS_PATH=C:\Program Files\Microsoft Visual Studio\2017)
rem IF EXIST %VS_PATH%\%EDITION% (
	SET NET=%VS_PATH%\%EDITION%\MSBuild\%VER_VS%\Bin
rem 	) ELSE (
rem	SET NET=%VS_PATH%\Enterprise\MSBuild\%VER_VS%\Bin
rem	)


rem IF %xOS%==x86 (set NET=C:\Program Files\Microsoft Visual Studio\2017\Community\MSBuild\%VER_VS%\Bin) ELSE set NET=C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\%VER_VS%\Bin
echo NET=%NET%
set path=%path%;%NET%





