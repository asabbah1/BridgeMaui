using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Helpers
{
    public class CultureHelper
    {
        public static List<string> CountryList()
        {
            //Creating list
            List<string> CultureList = new List<string>();

            //getting the specific Culturelnfo from Culturelnfo class
            CultureInfo[] getCultureInfo = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            foreach (CultureInfo getCulture in getCultureInfo)
            {
                //creating the object of RegionInfo class
                RegionInfo getRegionInfo = new RegionInfo(getCulture.Name);
                //adding each country Name into the Dictionary
                if (!(CultureList.Contains(getRegionInfo.EnglishName)))
                {
                    if (getRegionInfo.EnglishName == "Jordan")
                        continue;

                    CultureList.Add(getRegionInfo.EnglishName);
                }
            }

            CultureList.Sort();
            CultureList.Insert(0, "Jordan");

            

            return CultureList;
        }
    }
}
