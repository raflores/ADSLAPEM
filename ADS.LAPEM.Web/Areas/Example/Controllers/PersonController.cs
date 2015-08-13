using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADS.LAPEM.Services.Example;
using ADS.LAPEM.Web.Controllers;
using ADS.LAPEM.Entities.Example;
using Bsd.Common.Infrastructure.Web.Grid;
using ADS.LAPEM.Web.Infrastructure.Grid;
using ADS.LAPEM.Web.Areas.Example.Models;

namespace ADS.LAPEM.Web.Areas.Example.Controllers
{
    public class PersonController : BaseController
    {
        protected IPersonService PersonService { get; set; }

        //
        // GET: /Example/Person/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(GetModel(new Person()));
        }

        [HttpPost]
        public ActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                PersonService.CreatePerson(person);
                return RedirectToAction(INDEX_VIEW);
            }
            else
            {
                return View(GetModel(person));
            }
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            Person person = PersonService.ReadPersonById(id);
            return View(GetModel(person));
        }

        [HttpPost]
        public ActionResult Edit(Person person)
        {
            if (ModelState.IsValid)
            {
                PersonService.UpdatePerson(person);
                return RedirectToAction(INDEX_VIEW);
            }
            else
            {
                return View(GetModel(person));
            }
        }

        [HttpGet]
        public ActionResult Delete(long id)
        {
            Person person = PersonService.ReadPersonById(id);
            return PartialView(DELETE_PARTIAL_VIEW, GetModel(person));
        }

        [HttpPost]
        public ActionResult Delete(Person person)
        {
            PersonService.DeletePerson(person);
            return Json(JSON_SUCCESS, JsonRequestBehavior.AllowGet);
        }

        private PersonViewModel GetModel(Person person)
        {
            return new PersonViewModel(person);
        }

        [HttpGet]
        public ActionResult GetList(GridSettingsWeb grid)
        {
            GridResult<Person> result = PersonService.ReadPerson(grid);

            var jsonData = new
            {
                total = result.TotalPages,
                result.PageIndex,
                records = result.TotalRecords,
                rows = (
                    from p in result.Rows
                    select new
                    {
                        id = p.Id,
                        cell = new string[] { p.Firstname, p.Lastname, p.Email, p.Telephone, p.CreatedDate.ToString(), p.Id.ToString() }
                    }).ToArray()

            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
    }
}
