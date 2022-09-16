cd .\bin
"%WIX%\bin\heat.exe" dir "Debug" -o ".\build\src.wxs" -dr SRC_DIR_REF ag -cg COMP_SRC_FRAG -gg –sfrag -var var.SRC -directoryid metter
"%WIX%\bin\candle.exe" -dSRC="Debug" -out ".\build\src.wixobj" ".\build\src.wxs"
"%WIX%\bin\candle.exe" -out ".\build\Product.wixobj" "..\Product.wxs"
"%WIX%\bin\light.exe" ".\build\src.wixobj" ".\build\Product.wixobj" -cultures:ru-RU -ext WixUtilExtension -ext WixUIExtension -out ".\build\elm302.msi"

