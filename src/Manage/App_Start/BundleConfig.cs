using System.Web;
using System.Web.Optimization;

namespace Manage
{
    // BundleConfig 一个打包的配置类
    // 使用Bundle来引用css有个好处 就是可以把多个css文件在一起请求，浏览器只发一次请求。不过必须在Global.asax里面 加一段代码  BundleTable.EnableOptimizations = true;
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // 捆绑除了可以方便地管理脚本和样式文件，还可以给网络减少带宽。
            // Include 方法用于包含具体要捆绑的文件。其中的 {version} 是文件版本的占位符，MVC会在相应的目录下定位到最新的一个版本文件。
            // 捆绑 
            // JS 脚本文件用的是 ScriptBundle 类，View中的引用 @Styles.Render("~/Content/css")
            // CSS 样式文件用的是 StyleBundle 类，View中的引用 @Scripts.Render("~/bundles/jquery") 

            //一个Styles.Render 或 Scripts.Render 方法生成了一个带有v参数的URL，这个URL将使MVC把一整个捆绑的数据进行最小化处理并一次发送到客户端。


            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.js", "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/bootstrap.css","~/Content/site.css"));
        }
    }
}
