call env.bat
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

%BC% pkg\pkg.csproj 
%BC% System.Windows.Forms.Mstv\System.Windows.Forms.Mstv.csproj
%BC% ZtpLib\ZtpLib.csproj 
%BC% ZtpConfig\ZtpConfig.csproj 
%BC% ZtpModel\ZtpModel.csproj
%BC% ZtpModel.Creator\ZtpModel.Creator.csproj
%BC% TcpStub\TcpStub.csproj
%BC% ZtpManager\ZtpManager.csproj

