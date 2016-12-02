using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesManagementSystem.Tests.Models
{
    [TestClass]
    public class CategoryViewModelTest
    {
        [TestMethod]
        public void IsValid_FalseCondition()
        {

            bool expectedResult = false;

            CategoryViewModel cvm = new CategoryViewModel();
            bool testResult = cvm.IsValid();

            Assert.AreEqual(testResult, expectedResult);

        }

        [TestMethod]
        public void IsValid_TrueCondition()
        {

            bool expectedResult = true;

            CategoryViewModel cvm = new CategoryViewModel
            {
                categoryDTO = new T_M_CATEGORY
                {
                    CAT_ID = "TEST", CAT_NAME = "TEST"
                }
            };
            bool testResult = cvm.IsValid();

            Assert.AreEqual(testResult, expectedResult);

        }

    }
}
