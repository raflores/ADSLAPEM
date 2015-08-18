﻿using ADS.LAPEM.Entities;
using ADS.LAPEM.Services.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADS.LAPEM.Web.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            Models.HomeViewModel model = new Models.HomeViewModel { };
            model.Id = 10;
            model.Nombre = "hola";

            return View(model);
        }        

    }
}
