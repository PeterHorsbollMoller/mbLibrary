@Echo Off
REM Recompiling all modules with MapBasic 17.3
SET MY_PATH=C:\Horsboll-Moller Dropbox\Peter Horsbøll Møller\3. MB_Kode\mbLibrary

"C:\MapInfo\MapBasic\17.3\Mapbasic.Exe" -NOSPLASH -D  ^
	"%MY_PATH%\RIBBONLib.mb"

"C:\MapInfo\MapBasic\17.3\Mapbasic.Exe" -NOSPLASH -D  ^
	"%MY_PATH%\ARRAYLib.mb" ^
	"%MY_PATH%\COLUMNLib.mb" ^
	"%MY_PATH%\DATETIMELib.mb" ^
	"%MY_PATH%\DBMSInfoLib.MB" ^
	"%MY_PATH%\DBMSMapCatalog.mb" ^
	"%MY_PATH%\DBMSUtilityLib.mb" ^
	"%MY_PATH%\DEBUGLib.mb" ^
	"%MY_PATH%\ERRORLib.mb" ^
	"%MY_PATH%\EXCELLib.mb"

"C:\MapInfo\MapBasic\17.3\Mapbasic.Exe" -NOSPLASH -D  ^
	"%MY_PATH%\FILELib.mb" ^
	"%MY_PATH%\FMEQuickTranslatorLib.MB" ^
	"%MY_PATH%\GroupLayerLib.mb" ^
	"%MY_PATH%\LAYERLib.mb" ^
	"%MY_PATH%\MAPPERLib.mb" ^
	"%MY_PATH%\MathLib.mb" ^
	"%MY_PATH%\OBJLib.mb" ^
	"%MY_PATH%\ProgramInfo.mb"

"C:\MapInfo\MapBasic\17.3\Mapbasic.Exe" -NOSPLASH -D  ^
	"%MY_PATH%\ReadRecordsLib.mb" ^
	"%MY_PATH%\RESSTRNGLib.mb" ^
	"%MY_PATH%\STRINGLib.mb" ^
	"%MY_PATH%\STYLELib.mb" ^
	"%MY_PATH%\SystemLib.mb" ^
	"%MY_PATH%\TABLELib.mb" ^
	"%MY_PATH%\TOOLBARLib.mb"

"C:\MapInfo\MapBasic\17.3\Mapbasic.Exe" -NOSPLASH -D  ^
	"%MY_PATH%\ConfigFileLib.mb" ^
	"%MY_PATH%\FILELib 1522.mb" ^
	"%MY_PATH%\WINDOWLib.mb"

dir "%MY_PATH%\*.err" /s
Pause