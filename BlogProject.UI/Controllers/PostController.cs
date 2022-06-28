using BlogProject.CORE.Service;
using BlogProject.MODEL.Entities;
using BlogProject.UI.Models.VM;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BlogProject.UI.Controllers
{
    public class PostController : Controller
    {
        private readonly ICoreService<Category> cs;
        private readonly ICoreService<Post> ps;
        private readonly ICoreService<User> us;
        public PostController(ICoreService<Category> _cs, ICoreService<Post> _ps, ICoreService<User> _us)
        {

            cs = _cs;
            us = _us;
            ps = _ps;
        }
        public IActionResult PostByID(Guid id)
        {
            SinglePostVM singlePostVM = new SinglePostVM();
            singlePostVM.Post = ps.GetByID(id);
            singlePostVM.User = us.GetByDefault(x => x.ID == ps.GetByID(id).UserID);
            ViewBag.Categories = cs.GetActive();
            return View(singlePostVM);
        }

        public IActionResult PostByAuthor(Guid id)
        {
            ViewBag.Author=us.GetByID(id).FirstName + " " + us.GetByID(id).LastName;
            return View(ps.GetDefault(x => x.UserID == id));
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
