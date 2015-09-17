using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Manage.Models;

namespace Manage.Controllers
{
    public class MoviesController : Controller
    {
        private MovieDBContext db = new MovieDBContext();

        // GET: Movies
        public ActionResult Index()
        {


            //for (int i = 1; i <= 10; i++)
            //{
            //    User user = new Models.User();
            //    //user.ID = i;
            //    user.Username = "username" + i;
            //    user.Password = "password" + i;
            //    user.version = 1;
            //    user.status = 0;
            //    user.CreateTime = DateTime.Now;
            //    user.UpdateTime = DateTime.Now;
            //    user.CreateUserId = 1;
            //    user.UpdateUserId = 1;

            //    db.Users.Add(user);
            //    db.SaveChanges();
            //}

            ViewBag.Users = db.Users.ToList();



            // http://www.cnblogs.com/easonwu/p/beginner-aspnet-mvc-various-ways-of-passing-data-in-mvcapps.html

            // ViewData与TempData方式是弱类型的方式传递数据，而使用Model传递数据是强类型的方式。

            // 1.使用ViewData传递数据
            // ViewData只能在一个Action方法中进行设置，在相关的视图页面读取，只对当前视图有效。
            ViewData["Message"] = "Hello world from ViewData";
            // 页面使用 <% = Html.Encode(ViewData[“Message”]) %>

            // 2.使用TempData传递数据
            // TempData应该可以在一个Action中设置，多个页面读取。但是，实际上TempData中的元素被访问一次以后就会被删除。
            TempData["Message"] = "Hello world form TempData";
            // 页面使用 <% = Html.Encode(TempData [“Message”]) %>

            // 3.使用Model传递数据 : 使用Model传递数据的时候，通常在创建View的时候我们会选择创建强类型View

            // 4.使用 ViewBag传递数据。 ViewBag是一个动态的对象，这意味着在您没有给ViewBag放置属性时，它没有任何属性，您可以把任何您想放置的对象放入到 ViewBag对象中
            // ViewBag是一个动态类型变量
            // ViewBag基本上是ViewData的包装，也是用来从Controller向View来传递值的。
            // ViewBag也只在当前的请求中有效。
            // 在重定向(redirection)后，ViewBag中存储的变量值将变为null
            // 因为ViewBag是动态类型，所以我们在取得其值时，不需要进行类型转换。
            ViewBag.Times = 4;
            ViewBag.Message = "Hello world from ViewBag.";

            // 强类型：偏向于不容忍隐式类型转换。
            // 弱类型：偏向于容忍隐式类型转换。
            // 静态类型：编译的时候就知道每一个变量的类型，因为类型错误而不能做的事情是语法错误。
            // 动态类型：编译的时候不知道每一个变量的类型，因为类型错误而不能做的事情是运行时错误。

            return View(db.Movies.ToList());
        }


        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }


        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,ReleaseDate,Genre,Price")] Movie movie)
        {
            // View向Controller传递数据
            // 1.通过Request.Form读取表单数据
            // 2.通过FormCollection读取表单数据
            // 3.自定义数据绑定 : 创建一个自定义数据绑定类，让这个类继承自IModelBinder，实现该接口中的BindModel方法。



            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movie);
        }


        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }


        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,ReleaseDate,Genre,Price")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }


        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }


        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
