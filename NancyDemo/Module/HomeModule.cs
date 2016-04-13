using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;
using Nancy.Json;
using Nancy.Security;
using System.IO;

namespace NancyDemo
{
    public class HomeModule:NancyModule
    {
        public HomeModule(IRootPathProvider path) 
        {
            this.RequiresAuthentication();
            Get["/"] = r =>
            {                
                var os = System.Environment.OSVersion;
                var p = path.GetRootPath();
                var user = Context.CurrentUser.UserName;
                return "Hello Nancy<br/> System:" + os.VersionString + "<br/>" + p + "<br/>" + user;
            };

            Get["/blog/{name}"] = r => {
                return "blog name " + r.name;
            };

            Get["/mvc/{controller}/{action}/{id}"] = r => {
                StringBuilder mvc = new StringBuilder();
                mvc.AppendLine("controller :" + r.controller+"<br/>");
                mvc.AppendLine("action :" + r.action + "<br/>");
                mvc.AppendLine("id :" + r.id + "<br/>");
                return mvc.ToString();
            };

            Get["/json"] = r =>
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                return  js.Serialize(new { status = 200, message = "this json" });
            };

            Post["/file"] = r =>
            {
                var uploadDirectory = Path.Combine(path.GetRootPath(), "uploads");

                if (!Directory.Exists(uploadDirectory))
                {
                    Directory.CreateDirectory(uploadDirectory);
                }

                foreach (var file in Request.Files)
                {
                    var filename = Path.Combine(uploadDirectory, file.Name);
                    using (FileStream fileStream = new FileStream(filename, FileMode.Create))
                    {
                        file.Value.CopyTo(fileStream);
                    }
                }
                return HttpStatusCode.OK;
            };
        }
    }
}
