﻿using BlogProject.CORE.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.MODEL.Entities
{
    public class User:CoreEntity
    {
        public string  Firstname { get; set; }
        public string  LastName { get; set; }
        public string  Title { get; set; }
        public string  ImageURL { get; set; }
        public string  EmailAdress { get; set; }
        public string  Password { get; set; }
        public string  LastIPAdress { get; set; }
        public DateTime LastLogin { get; set; }

        public virtual List<Post> Posts { get; set; }
    }
}
