using BlogProject.CORE.Service;
using BlogProject.MODEL.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICoreService<Category> cs;
        private readonly ICoreService<Post> ps;
        private readonly ICoreService<User> us;
        public CategoryController(ICoreService<Category> _cs, ICoreService<Post> _ps, ICoreService<User> _us)
        {
            cs = _cs;
            us = _us;
            ps = _ps;
        }
        public IActionResult Index()
        {
            return View(cs.GetActive());
        }
    }
}
