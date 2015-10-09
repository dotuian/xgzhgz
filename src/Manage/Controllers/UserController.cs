using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Manage.Models;

namespace Manage.Controllers
{
    public class UserController : Controller
    {
        private MovieDBContext db = new MovieDBContext();

        // GET: User
        public ActionResult Index()
        {
            return View("Index", db.Users.ToList());
        }

        [HttpGet]
        [ActionName("Create")] // 给Action方法定义别名
        public ActionResult Create() {

            CreateUserViewModel model = this.initCreatePage(null);

            // 测试用的User数据
            UserModel user = new UserModel();
            user.UserName = "dotuian";
            user.Password = "test1234";
            user.Birthday = DateTime.Now.ToString("yyyy-MM-dd");
            user.Email = "dotuian@outlook.com";
            user.Telephone = "080-9155-2781";
            user.Memo = "memo";
            model.User = user;

            return View(model);
        }


        // http://www.cnblogs.com/willick/p/3424188.html
        //MVC 框架内置默认的 Model Binder 是 DefaultModelBinder 类。当 Action Invoker 没找到自定义的 Binder 时，则默认使用 DefaultModelBinder。默认情况下，DefaultModelBinder 从如下 4 种途径查找要绑定到 Model 上的值：

        //Request.Form，HTML form 元素提供的值。
        //RouteData.Values，通过应用程序路由提供的值。
        //Request.QueryString，所请求 URL 的 query string 值。
        //Request.Files，客户端上传的文件。
        //DefaultModelBinder 按照该顺序来查找需要的值。如对于上面的例子，DefaultModelBinder 会按照如下顺序为 id 参数查找值：

        //Request.Form["id"]
        //RouteData.Values["id"]
        //Request.QueryString["id"]
        //Request.Files["id"]
        //一旦找到则停止查找。
        [HttpPost]
        public ActionResult Create(UserModel user)
        {
            CreateUserViewModel model = this.initCreatePage(user);

            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }


        private CreateUserViewModel initCreatePage(UserModel user) {
            // 页面表示用Model
            var model = new CreateUserViewModel();

            model.User = user;

            // 可供选择数据
            IList<Hobby> AvailableHobbies = new List<Hobby> {
                new Hobby { Code = "1", Name = "排球", IsChecked = true},
                new Hobby { Code = "2", Name = "足球", IsChecked = false},
                new Hobby { Code = "3", Name = "篮球", IsChecked = false},
                new Hobby { Code = "4", Name = "台球", IsChecked = false},
                new Hobby { Code = "5", Name = "保龄球", IsChecked = false},
                new Hobby { Code = "5", Name = "兵乓球", IsChecked = false},
            };
            model.AvailableHobbies = AvailableHobbies;

            IList<Hobby> SelectedHobbies = new List<Hobby>();
            if (user!= null && user.Hobbies != null)
            {
                foreach (string code in user.Hobbies)
                {
                    for (int i = 0; i < AvailableHobbies.Count; i++)
                    {
                        Hobby hobby = AvailableHobbies[i];
                        if (hobby.Code == code)
                        {
                            SelectedHobbies.Add(hobby);
                        }
                    }
                }
                model.SelectedHobbies = SelectedHobbies;
            }

            // 运营商
            List<KV> CarriersList = new List<KV>();
            CarriersList.Add(new KV { Code = "au", Name = "AU" });
            CarriersList.Add(new KV { Code = "softbank", Name = "SoftBank" });
            CarriersList.Add(new KV { Code = "docomo", Name = "Docomo" });

            model.CarriersList = CarriersList;

            return model;
        }


    }
}