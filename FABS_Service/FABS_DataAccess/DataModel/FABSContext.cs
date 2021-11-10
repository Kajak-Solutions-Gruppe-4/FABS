using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FABS_DataAccess.Model
{
    public partial class FABSContext
    {
        private string _connectionString;

        public void OnCreate()
        {
            string physicalPath = "";
            string appSettingsString = @"FABS_API_Service\appsettings.json";
            string folderUpString = @"";
            // Loops to search back in folders to be able to find appsettings.
            // TODO: find a better solution than just looping 10 times
            for (int i = 0; i < 10; i++)
            {
                physicalPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), folderUpString));
                physicalPath += appSettingsString;
                if (physicalPath.Contains(@"FABS_Service\FABS_API_Service\appsettings.json"))
                {
                    break;
                }
                folderUpString += @"..\";
            }

            IConfigurationRoot Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(physicalPath)
                .Build();
            _connectionString = Configuration.GetConnectionString("FABS_connectionstring");
        }
    }
}
