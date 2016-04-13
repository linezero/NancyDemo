using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;

namespace NancyDemo
{
    public class RazorModule:NancyModule
    {
        public RazorModule() :base("/razor")
        {
            Get["/"] = r =>
            {
                var os = System.Environment.OSVersion;
                return "Hello Razor<br/> System:" + os.VersionString;
            };

            Get["/index"] = r =>
            {
                var model = "我是 Razor 引擎";
                return View["index",model];
            };

            Get["/each"] = r =>
            {
                var arr = new int[] { 3, 6, 9, 12, 15, 12, 9, 6, 3 };
                return View["each", arr];
            };
        }
    }
}
