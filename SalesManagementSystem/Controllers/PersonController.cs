using SalesManagementSystem.Models;
using SalesManagementSystem.Service;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalesManagementSystem.Controllers
{
    public class PersonController : Controller
    {

        private PersonService personService;

        public PersonController()
        {
            personService = new PersonService(new SMS_DBEntities());
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(PersonViewModel personVM)
        {

            try
            {
                if (personVM.Search == null)
                {
                    personVM.Search.P_FIRST_NAME = "";
                    personVM.Search.P_LAST_NAME = "";
                    personVM.Lists = personService.FindAll();
                }
                else if(String.IsNullOrEmpty(personVM.Search.P_FIRST_NAME) && String.IsNullOrEmpty(personVM.Search.P_LAST_NAME))
                {
                    personVM.Search.P_FIRST_NAME = "";
                    personVM.Search.P_LAST_NAME = "";
                    personVM.Lists = personService.FindAll();
                }
                else
                {
                    personVM.Lists = personService.Find(personVM.Search);
                }

                Session["SearchFirstName"] = personVM.Search.P_FIRST_NAME;
                Session["SearchLastName"] = personVM.Search.P_LAST_NAME;

                return PartialView("PersonDetailView", personVM);
            }
            catch(Exception e)
            {
                return PartialView("~/Views/Shared/Error.cshtml");
            }

        }

        [HttpPost]
        public ActionResult GoBack()
        {
            PersonViewModel pvm = new PersonViewModel();

            try
            {
                pvm.Search = new T_M_PERSON
                {
                    P_FIRST_NAME = (String)Session["SearchFirstName"],
                    P_LAST_NAME = (String)Session["SearchLastName"]
                };
            }
            catch
            {
                pvm.Search = null;
            }

            return Search(pvm);

        }

        [HttpPost]
        public ActionResult Add(PersonViewModel pesonVM)
        {
            pesonVM.error = new List<ErrorModel>();
            try
            {
                if (pesonVM.Dto != null)
                {
                    personService.Insert(pesonVM.Dto);
                    return Json(new { status = 1, message = "Item has been sucessfully Added" });
                }
                return PartialView("PersonDetailForm", new PersonViewModel());
            }
            catch (DbEntityValidationException dbEx)
            { 
                foreach(DbEntityValidationResult validationResult in dbEx.EntityValidationErrors)
                {
                    pesonVM.error.Add(new ErrorModel { ErrorMessage = validationResult.ValidationErrors.First().ErrorMessage });
                }
            }
            catch (Exception e)
            {
                pesonVM.error.Add(new ErrorModel { ErrorMessage = e.Message });                
            }

            return PartialView("PersonDetailForm", pesonVM);

        }

        [HttpPost]
        public ActionResult Edit(PersonViewModel personVm)
        {
            personVm.error = new List<ErrorModel>();
            try
            {
                if(personVm.Dto != null)
                {
                    personService.Update(personVm.Dto);
                    return Json(new { status = 1, message = "Item has been successfully Updated" });
                }
                personVm.error.Add(new ErrorModel { ErrorMessage = "Failed to update an Item" });
            }
            catch(DbEntityValidationException dbEx)
            {
                foreach (DbEntityValidationResult validationResult in dbEx.EntityValidationErrors)
                {
                    personVm.error.Add(new ErrorModel { ErrorMessage = validationResult.ValidationErrors.First().ErrorMessage });
                }
            }
            catch(Exception e)
            {
                personVm.error.Add(new ErrorModel { ErrorMessage = e.Message }); 
            }

            return Json(new { status = 0, personVm.error });

        }

    }
}
