call env.bat
call clean.bat
echo !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
echo !!! Для сборки в режиме Release наберите: build.bat r !!!
echo !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
IF "%1" == "r" (
    set COND=/p:Configuration=Release
) ELSE (
    set COND=/p:Configuration=Debug
)
echo ======== %COND% ========
set BC="%NET%\MSBuild.exe" /t:Rebuild /verbosity:m %COND%
echo %BC%

%BC% SmartUlcService/SmartUlcService.csproj
%BC% CtmAction/CtmAction.csproj 
%BC% winrvpulcreader/UlcWin/UlcWin/UlcWin.csproj 
  

