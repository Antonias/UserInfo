using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UsersInfo
{
    public class main
    {
        public static string GetConnectionString()

        {

#if debug

            return @"Data Source=TANAATU-PC\SQLEXPRESS;"
                    + @"Integrated Security=False;"
                    + @"User ID=sa;"
                    + @"Password=yuto";

#else   

            return @"Data Source=YUTO06;"
                  + @"Integrated Security=False;"
                  + @"User ID=sa;"
                  + @"Password=yuto";


#endif
        }

        public static string PhotoSavePath()
        {
#if debug
            return @"C:\Users\tanaatu\Documents\Visual Studio 2017\Projects\UsersInfo\UsersInfo\image";
            
#else
            return @"C:\inetpub\wwwroot\image";
#endif        

        }

        public static string TrimString(object s)
        {
            
            if (DBNull.Value.Equals(s))
            {
                return "";
            }
            else
            {
                string tmp = (string)s;
                return tmp.Trim();
            }
            

            //string tmp = (string)s;
            //return tmp.Trim();

        }

    }
}