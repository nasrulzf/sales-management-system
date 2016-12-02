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
    public class CategoryController : Controller
    {
        
        private CategoryService categoryService;

        public CategoryController()
        {
            categoryService = new CategoryService(new SMS_DBEntities());
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(CategoryViewModel categoryVM)
        {

            try
            {
                if (categoryVM.Search == null)
                {
                    categoryVM.Search.CAT_ID = "";
                    categoryVM.Search.CAT_NAME = "";
                    categoryVM.Lists = categoryService.FindAll();
                }
                else if (String.IsNullOrEmpty(categoryVM.Search.CAT_ID) && String.IsNullOrEmpty(categoryVM.Search.CAT_NAME))
                {
                    categoryVM.Search.CAT_ID = "";
                    categoryVM.Search.CAT_NAME = "";
                    categoryVM.Lists = categoryService.FindAll();
                }
                else
                {
                    categoryVM.Lists = categoryService.Find(categoryVM.Search);
                }

                Session["SearchCatID"] = categoryVM.Search.CAT_ID;
                Session["SearchCatName"] = categoryVM.Search.CAT_NAME;

                return PartialView("CategoryDetailView", categoryVM);
            }
            catch(Exception e)
            {
                return PartialView("~/Views/Shared/Error.cshtml");
            }

        }

        [HttpPost]
        public ActionResult GoBack()
        {
            CategoryViewModel cvm = new CategoryViewModel();

            try
            {
                cvm.Search = new T_M_CATEGORY
                {
                    CAT_ID = (String)Session["SearchCatID"],
                    CAT_NAME = (String)Session["SearchCatName"]
                };
            }
            catch
            {
                cvm.Search = null;
            }

            return Search(cvm);

        }

        [HttpPost]
        public ActionResult Add(CategoryViewModel categoryVM)
        {
            categoryVM.error = new List<ErrorModel>();
            try
            {
                if (categoryVM.Dto != null)
                {
                    categoryService.Insert(categoryVM.Dto);
                    return Json(new { status = 1, message = "Item has been sucessfully Added" });
                }
                return PartialView("CategoryDetailForm", new CategoryViewModel());
            }
            catch (DbEntityValidationException dbEx)
            { 
                foreach(DbEntityValidationResult validationResult in dbEx.EntityValidationErrors)
                {
                    categoryVM.error.Add(new ErrorModel { ErrorMessage = validationResult.ValidationErrors.First().ErrorMessage });
                }
            }
            catch (Exception e)
            {
                categoryVM.error.Add(new ErrorModel { ErrorMessage = e.Message });                
            }

            return PartialView("CategoryDetailForm", categoryVM);

        }

        [HttpPost]
        public ActionResult Edit(CategoryViewModel categoryVm)
        {
            categoryVm.error = new List<ErrorModel>();
            try
            {
                if (categoryVm.Dto != null)
                {
                    categoryService.Update(categoryVm.Dto);
                    return Json(new { status = 1, message = "Item has been successfully Updated" });
                }
                categoryVm.error.Add(new ErrorModel { ErrorMessage = "Failed to update an Item" });
            }
            catch(DbEntityValidationException dbEx)
            {
                foreach (DbEntityValidationResult validationResult in dbEx.EntityValidationErrors)
                {
                    categoryVm.error.Add(new ErrorModel { ErrorMessage = validationResult.ValidationErrors.First().ErrorMessage });
                }
            }
            catch(Exception e)
            {
                categoryVm.error.Add(new ErrorModel { ErrorMessage = e.Message }); 
            }

            return Json(new { status = 0, categoryVm.error });

        }

    }
}
