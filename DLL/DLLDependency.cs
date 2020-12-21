﻿using DLL.DBContext;
using DLL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DLL
{
  public static   class DLLDependency
    {
       public   static void  AllDependency(IServiceCollection services,IConfiguration Configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
           options.UseSqlServer(Configuration.GetConnectionString(name: "DefaultConnection")));

            //Repository Dependence
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();

        }
    }
}
