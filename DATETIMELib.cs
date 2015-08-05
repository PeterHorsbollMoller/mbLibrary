// Namespace Declaration
using System;

// The MapBasicExtensions Namespace
namespace DATETIMELib
{
   // The MBDateAndTime class
   class MBDateAndTime
   {
	  public static string RegionalLongDate(string sDateString)
	  {
		string mbDateString;
        DateTime stringToDate;

        stringToDate = ConvertMBDate(sDateString);

		/* Convert the DateTime object stringToDate to
		it's equivalent long date string representation
		(depends on the Regional and Language Options) */
		mbDateString = (stringToDate.ToLongDateString());
		
		return mbDateString;
	  }
	  
	  public static string RegionalMonth(string sDateString)
	  {
		string mbMonthString;
        DateTime stringToDate;

        stringToDate = ConvertMBDate(sDateString);

        /* Extract from this date the name of the month
        in the regional language (depends on the Regional
        and Language Options) */
        mbMonthString = stringToDate.ToString("MMMM");
		
		return mbMonthString;
	  }

	  public static string RegionalWeekday(string sDateString)
	  {
		string mbWeekdayString;
        DateTime stringToDate;

        stringToDate = ConvertMBDate(sDateString);

        /* Extract from this date the name of the weekday
        in the regional language (depends on the Regional
        and Language Options) */
        mbWeekdayString = stringToDate.ToString("dddd");

        return mbWeekdayString;
	  }

      public static DateTime ConvertMBDate(string sDateString)
      /* The input string sDateString which comes from your
      MapBasic app will be either a Date (i.e. YYYYMMDD) or
      a DateTime (i.e. YYYYMMDDHHMMSSFFF) */
      {
          int mbYear;
          int mbMonth;
          int mbDay;
          DateTime stringToDate;

          /* Take the Year component from the input string
          (i.e. YYYY) and convert it to an integer */
          mbYear = Convert.ToInt32(sDateString.Substring(0, 4));

          /* Take the Month component from the input string
          (i.e. MM) and convert it to an integer */
          mbMonth = Convert.ToInt32(sDateString.Substring(4, 2));

          /* Take the Day component from the input string
          (i.e. DD) and convert it to an integer */
          mbDay = Convert.ToInt32(sDateString.Substring(6, 2));

          // Assign a value to the DateTime object stringToDate
          stringToDate = new DateTime(mbYear, mbMonth, mbDay);

          return stringToDate;
      }
  }
}