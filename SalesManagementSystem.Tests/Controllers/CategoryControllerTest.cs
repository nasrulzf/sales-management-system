using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using SalesManagementSystem.Controllers;
using System.Web.Mvc;
using SalesManagementSystem.Models;

namespace SalesManagementSystem.Tests.Controllers
{
    [TestClass]
    public class CategoryControllerTest
    {
        [TestMethod]
        public void Index()
        {
            
            IList<T_M_CATEGORY> categoryTestCase = new List<T_M_CATEGORY>();
            categoryTestCase.Add(new T_M_CATEGORY { CAT_ID = "CAKE", CAT_NAME = "CAKE" });
            categoryTestCase.Add(new T_M_CATEGORY { CAT_ID = "MLN", CAT_NAME = "MOLEN" });
            categoryTestCase.Add(new T_M_CATEGORY { CAT_ID = "OTHR", CAT_NAME = "OTHER" });
            categoryTestCase.Add(new T_M_CATEGORY { CAT_ID = "PSTR", CAT_NAME = "PASTRY" });
            categoryTestCase.Add(new T_M_CATEGORY { CAT_ID = "ROTI", CAT_NAME = "ROTI" });
            categoryTestCase.Add(new T_M_CATEGORY { CAT_ID = "SNCK", CAT_NAME = "SNACK" });

            categoryTestCase.Add(new T_M_CATEGORY
            {
                CAT_ID = "TEST",
                CAT_NAME = "TEST NAME"
            });

            CategoryController categoryController = new CategoryController();
            ViewResult result = categoryController.Index(new CategoryViewModel()) as ViewResult;

            CategoryViewModel cvmResult = (CategoryViewModel) result.Model;

            IList<T_M_CATEGORY> categoryListResult = cvmResult.categories;
            
            // Category List Test

            for(int i = 0; i < categoryTestCase.Count; i++)
            {
                Assert.AreEqual(categoryTestCase[i].CAT_ID, categoryListResult[i].CAT_ID);
            }
                                                
        }

        [TestMethod]
        public void Add()
        {
            T_M_CATEGORY categoryTest = new T_M_CATEGORY
            {
              CAT_ID = "TEST", CAT_NAME = "TEST NAME"
            };

            CategoryViewModel cvm = new CategoryViewModel
            {
              categoryDTO = categoryTest
            };

            CategoryController controller = new CategoryController();
            ViewResult result = controller.Add(cvm) as ViewResult;

            Index();

        }

        [TestMethod]
        public void AddValidation_ConditionFalse()
        {
            CategoryViewModel cvm = new CategoryViewModel();

            CategoryController controller = new CategoryController();
            RedirectResult result = controller.Add(cvm) as RedirectResult;

            Assert.IsNull(result);
            
        }

        [TestMethod]
        public void AddValidation_ConditionTrue()
        {
            CategoryViewModel cvm = new CategoryViewModel
            {
                categoryDTO = new T_M_CATEGORY
                {
                    CAT_ID = "TINP",
                    CAT_NAME = "TEST INPUT"
                }
            };

            CategoryController controller = new CategoryController();
            RedirectToRouteResult result = controller.Add(cvm) as RedirectToRouteResult; 

            Assert.AreEqual(result.RouteValues["action"], "Index");

        }

        [TestMethod]
        public void Add_ConditionDuplicate()
        {

        }

    }
}
