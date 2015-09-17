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
        // GET: User
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Create(UserModel user)
        {
            // 页面表示用Model
            var model = new CreateUserViewModel();

            // 测试用的User数据
            //User user = new Models.User();
            user.UserName = "dotuian";
            user.Password = "test1234";
            user.Birthday = DateTime.Now;
            user.Email = "dotuian@outlook.com";
            user.Telephone = "080-9155-2781";
            user.Memo = "memo";
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
            if (user.Hobbies != null) {
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

            return View(model);
        }


    }
}