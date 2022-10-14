Author:Prafulla Garasia
Student Id:0797964
Date:14/10/2022
Time:6:07PM

Project Name:MvcCandel
-------------------Started the project---------------


--------------------Part 1: Create a new project.--------------------
        1.comment// "sslPort": 44334 for security reason
        2.debug the app by selecting the IIS Express button

--------------------Part 2: Add Controller-----------------------
        1.name as CandelController.cs
        2.change code as..
        // 
        // GET: /Candel/

        public string Index()
        {
            return "This is my default action...";
        }

        // 
        // GET: /Candel/Welcome/ 

        public string Welcome()
        {
            return "This is the Welcome action method...";
        }

        3.Debug program and got the output.
        4.update Welcome method code with..
        // 
        // GET: /Candel/Welcome/ 
        // Requires using System.Text.Encodings.Web;
        public string Welcome(string name, int numTimes = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");
        }

        5.Debug program and got the required output.
        6.Replace the Welcome method with the following code..

        public string Welcome(string name, int ID = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}");
        }

-------------------------Part 3: Add View----------------------
1.replace the Index method with the following code..

public IActionResult Index()
{
    return View();
}

2. create in folder name Candel in View folder

3. add new item name Index.cshtml

4. add content in Index.cshtml as..
@{
    ViewData["Title"] = "Index";
}

<h2>Index</h2>

<p>Hello from our View Template!</p>

5.Change the title, footer, and menu link in the layout file

6. Change the title and <h2> element in Index.cshtml
@{
    ViewData["Title"] = " Fabulous Flame";
}

<h2>My Candel List</h2>

7. add this property 
<title>@ViewData["Title"] - Candel App</title>

8. Change Welcome method code in CandelController.cs as..
public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }

9. Create new File in Candel Foler name Welcome.cshtml and add context as..
@{
    ViewData["Title"] = "Welcome";
}

<h2>Welcome</h2>

<ul>
    @for (int i = 0; i < (int)ViewData["NumTimes"]; i++)
    {
        <li>@ViewData["Message"]</li>
    }
</ul>

-----------------------------Part 4 Add a data Model----------------------------
1. add class file in Models Folder as Candel.cs

2. update file..
public class Candel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
        public string MadeFrom { get; set; }
        public string Fragrance { get; set; }

        [DataType(DataType.Date)]
        public DateTime ExpiryDate { get; set; }
        public decimal Price { get; set; }
    }

3. add package..
    Install-Package Microsoft.EntityFrameworkCore.SqlServer

4. update Packages

5. create a class name MvcCandelContext.cs 

6. Add content as..

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcCandel.Models;

namespace MvcCandel.Data
{
    public class MvcCandelContext
   : DbContext
    {
        public MvcCandelContext(DbContextOptions<MvcCandelContext> options)
            : base(options)
        {
        }

        public DbSet<Candel> Candel { get; set; }
    }
}

7. update Startup.cs with..
services.AddControllersWithViews();

            services.AddDbContext<MvcCandelContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("MvcCandelContext")));
8. Add Scaffold page..
