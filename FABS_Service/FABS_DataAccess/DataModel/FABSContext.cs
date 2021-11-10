using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FABS_DataAccess.Model
{
    //public partial class FABSContext
    //{
    //    public FABSContext()
    //    {
    //        string appSettingsString = @"\FABS_API_Service\appsettings.json";
    //        // Loops to search back in folders to be able to find appsettings.
    //        // TODO: find a better solution than just looping 10 times
    //        for (int i = 0; i < 10; i++)
    //        {
    //            string physicalPath = @Directory.GetCurrentDirectory() + appSettingsString;
    //            if (physicalPath.Contains(@"FABS_Service\FABS_API_Service\appsettings.json"))
    //            {
    //                break;
    //            }
    //        }

    //        Configuration = new ConfigurationBuilder()
    //            .SetBasePath(Directory.GetCurrentDirectory())
    //            .AddJsonFile(@Directory.GetCurrentDirectory() + @"\..\..\..\..\FABS_API_Service\appsettings.json")
    //            .Build();
    //    }
    //}
}
