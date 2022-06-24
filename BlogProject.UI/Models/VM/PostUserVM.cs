using BlogProject.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.UI.Models.VM
{
    public class PostUserVM
    {
        public List<User> Users { get; set; }
        public List<Post> Posts { get; set; }
    }
}
