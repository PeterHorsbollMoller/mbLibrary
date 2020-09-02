@Echo Off
"C:\MapInfo\MapBasic\15.0\Mapbasic.Exe" -NOSPLASH -D  ^
	"ARRAYLib.mb" ^
	"COLUMNLib.mb" ^
	"DATETIMELib.mb" ^
	"DBMSInfoLib.MB" ^
	"DBMSMapCatalog.mb" ^
	"DBMSUtilityLib.mb" ^
	"DEBUGLib.mb" ^
	"ERRORLib.mb" ^
	"EXCELLib.mb"

"C:\MapInfo\MapBasic\15.0\Mapbasic.Exe" -NOSPLASH -D  ^
	"FILELib.mb" ^
	"FMEQuickTranslatorLib.MB" ^
	"GroupLayerLib.mb" ^
	"LAYERLib.mb" ^
	"MAPPERLib.mb" ^
	"MathLib.mb" ^
	"OBJLib.mb" ^
	"ProgramInfo.mb"

"C:\MapInfo\MapBasic\15.0\Mapbasic.Exe" -NOSPLASH -D  ^
	"ReadRecordsLib.mb" ^
	"RESSTRNGLib.mb" ^
	"STRINGLib.mb" ^
	"STYLELib.mb" ^
	"SystemLib.mb" ^
	"TABLELib.mb" ^
	"TOOLBARLib.mb"

"C:\MapInfo\MapBasic\12.5.1\Mapbasic.Exe" -NOSPLASH -D  ^
	"SystemLib 1251.mb" ^
	"FILELib 1251.mb"

"C:\MapInfo\MapBasic\15.2\Mapbasic.Exe" -NOSPLASH -D  ^
	"ConfigFileLib.mb" ^
	"FILELib 1522.mb" ^
	"RIBBONLib.mb" ^
	"WINDOWLib.mb"

dir /s "*.err"
Pause