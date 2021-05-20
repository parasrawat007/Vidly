﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        List<Customer> customers = new List<Customer>()
            {
                new Customer(){Id=1,Name="John Smith"},
                new Customer(){Id=2,Name="Marry Williams"}
            };

        // GET: Customers
        public ActionResult Index()
        {
            
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer =customers.SingleOrDefault(x => x.Id == id);
            if(customer==null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
    }
}