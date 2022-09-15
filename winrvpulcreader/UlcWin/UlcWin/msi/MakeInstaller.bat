@echo off

set projectDir=.

rem Automatically generated fragment file for application files
"%WIX%bin\heat.exe" dir "app" -cg INSTALLDIR_comp -gg -scom -sreg -sfrag -srd -dr INSTALLDIR -var var.ProjectDir -out "./build/Product.Files.wxs"
"%WIX%bin\candle.exe" "./build/Product.Files.wxs" -out "./build/_Product.Files.wixobj" -dProjectDir="%projectDir%\app"

rem Create setup-1.0.msi
rem "%WIX%bin\candle.exe" "Product.wxs" -out "_Product.wixobj" -dBUILD_GUID="2BEA883D-BB4C-4A70-B668-88AA54025F5A" -dBUILD_VERSION="1.0.0.0" -dBUILD_PROJECTDIR="%projectDir%\app" -ext WixUtilExtension -nologo
rem "%WIX%bin\light.exe" "_Product.Files.wixobj" "_Product.wixobj" -loc "Product.Loc-en.wxl" -cultures:en-US -ext WixUtilExtension -ext WixUIExtension -ext WixNetFxExtension -out "setup-1.0.msi" -nologo

rem Create setup-1.1.msi
rem "%WIX%bin\candle.exe" "Product.wxs" -out "_Product.wixobj" -dBUILD_GUID="2BEA883D-BB4C-4A70-B668-88AA54025F5A" -dBUILD_VERSION="1.1.0.0" -dBUILD_PROJECTDIR="%projectDir%\app" -ext WixUtilExtension -nologo
rem "%WIX%bin\light.exe" "_Product.Files.wixobj" "_Product.wixobj" -loc "Product.Loc-en.wxl" -cultures:en-US -ext WixUtilExtension -ext WixUIExtension -ext WixNetFxExtension -out "setup-1.1.msi" -nologo

rem Create setup-2.0.msi
"%WIX%bin\candle.exe" "Product.wxs" -out "./build/_Product.wixobj" -dBUILD_GUID="2BEA883D-BB4C-4A70-B668-88AA54025F5A" -dBUILD_VERSION="2.0.0.0" -dBUILD_PROJECTDIR="%projectDir%\app" -ext WixUtilExtension -nologo
"%WIX%bin\light.exe" "./build/_Product.Files.wixobj" "./build/_Product.wixobj" -loc "Product.Loc-en.wxl" -cultures:ru-RU -ext WixUtilExtension -ext WixUIExtension -ext WixNetFxExtension -out "./build/UlcCtrlView.msi" -nologo