using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Http;
using Microsoft.WindowsAzure.Mobile.Service;
using YorNService.DataObjects;
using YorNService.Models;

namespace YorNService
{
    public static class WebApiConfig
    {
        public static void Register()
        {
            // Use this class to set configuration options for your mobile service
            ConfigOptions options = new ConfigOptions();

            // Use this class to set WebAPI configuration options
            HttpConfiguration config = ServiceConfig.Initialize(new ConfigBuilder(options));

            // To display errors in the browser during development, uncomment the following
            // line. Comment it out again when you deploy your service for production use.
            // config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            
            Database.SetInitializer(new YorNInitializer());
        }
    }

    public class YorNInitializer : ClearDatabaseSchemaIfModelChanges<YorNContext>
    {
        protected override void Seed(YorNContext context)
        {
            List<User> userItems = new List<User>
            {
                new User { Username = "1", Password = "Pass1", ID = 1},
                new User { Username = "2", Password = "Pass2", ID = 0},
            };

            foreach (User user in userItems)
            {
                context.Set<User>().Add(user);
            }

            base.Seed(context);
        }
    }
}

