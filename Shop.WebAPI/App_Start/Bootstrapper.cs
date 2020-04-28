using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http;

namespace Shop.WebAPI.App_Start
{
    public class Bootstrapper
    {
        public static void Run()
        {
            AutofacWebAPIConfig.Initialize(GlobalConfiguration.Configuration);
        }

    }
}