using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NancyDemo
{
    public class SSVEModule : NancyModule
    {
        public SSVEModule():base("/ssve") 
        {
            Get["/"] = r =>
            {
                var os = System.Environment.OSVersion;
                return "Hello SSVE<br/> System:" + os.VersionString;
            };

            Get["/model"] = r =>
            {
                var model = "我是字符串";
                return View["model", model];
            };

            Get["/each"] = r =>
            {
                var arr = new int[] { 3, 6, 9, 12, 15, 12, 9, 6, 3 };
                return View["each", arr];
            };

            Get["/if"] = r =>
            {
                return View["if", new { HasModel = true }];
            };
        }
    }
}
