﻿using DLL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DLL.DBContext
{
   public  class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions options) :base(options)
        {
           

        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
