using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pss.ProgrammerMate.CommonClasses
{
    public static class CommonVariables
    {


        public static string New_IntialValue = "New";

        public static string DateFormat_Full = "ddd MMM-dd-yyyy HH:mm:ss";


        public static string FullDateFormat = "ddd, MMM dd,yyyy HH:mm:ss";
        public static string ShortDateFormat = "MM/dd/yyyy";
        public static CultureInfo myCulture = CultureInfo.InvariantCulture;

        public static string getDateString(object inputDate, string ReturnFormat, Boolean isDefault = true)
        {
            try
            {

                if (inputDate is DateTime)
                {
                    return Convert.ToDateTime(inputDate).ToString(ReturnFormat);

                }
                else
                {
                    if (isDefault == true)
                    {
                        return DateTime.Now.ToString(ReturnFormat);
                    }
                    else
                    {
                        return string.Empty;
                    }
                }


            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        public static string ConvertMinutes_ToHours(object TotalMinutes)
        {
            try
            {

                if (TotalMinutes is int || TotalMinutes is string)
                {

                    TimeSpan myTimeSpan = TimeSpan.FromMinutes(int.Parse(TotalMinutes.ToString()));

                    return myTimeSpan.ToString(@"hh\:mm");

                }
                else
                {
                    return "00:00";
                }


            }
            catch (Exception ex)
            {
                return "00:00";
            }
        }

        #region "Images"
        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            try
            {
                MemoryStream ms = new MemoryStream(byteArrayIn);
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

    }
}
