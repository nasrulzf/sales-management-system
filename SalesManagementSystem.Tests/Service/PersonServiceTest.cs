using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesManagementSystem.Service;
using System.Collections;
using System.Collections.Generic;

namespace SalesManagementSystem.Tests.Service
{
    [TestClass]
    public class PersonServiceTest
    {
        [TestMethod]
        public void Find_SingleFoundCase()
        {
            T_M_PERSON expectedResult = new T_M_PERSON { P_ID = 2, P_FIRST_NAME = "NASRUL", P_LAST_NAME = "AZIZ" };

            PersonService personService = new PersonService(new SMS_DBEntities());

            T_M_PERSON testResult = personService.Find(2);

            Assert.AreEqual(expectedResult.P_ID, testResult.P_ID);
            Assert.AreEqual(expectedResult.P_FIRST_NAME, testResult.P_FIRST_NAME);
            Assert.AreEqual(expectedResult.P_LAST_NAME, testResult.P_LAST_NAME);

        }

        [TestMethod]
        public void Find_SingleLikeFoundCase()
        {
            IList<T_M_PERSON> expectedResult = new List<T_M_PERSON>();
            expectedResult.Add(new T_M_PERSON { P_ID = 2, P_FIRST_NAME = "NASRUL", P_LAST_NAME = "AZIZ" });

            PersonService personService = new PersonService(new SMS_DBEntities());
            IList<T_M_PERSON> testResult = personService.Find(new T_M_PERSON { P_FIRST_NAME = "Nasr" });

            for(int i = 0; i < expectedResult.Count; i++)
            {
                Assert.AreEqual(expectedResult[i].P_FIRST_NAME, testResult[i].P_FIRST_NAME);
            }
        }

        [TestMethod]
        public void Find_AllCase()
        {
            IList<T_M_PERSON> expectedResult = new List<T_M_PERSON>();
            expectedResult.Add(new T_M_PERSON { P_ID = 1, P_FIRST_NAME = "MIFTAH", P_LAST_NAME = "FARIDZ" });
            expectedResult.Add(new T_M_PERSON { P_ID = 2, P_FIRST_NAME = "NASRUL", P_LAST_NAME = "AZIZ" });

            PersonService personService = new PersonService(new SMS_DBEntities());
            IList<T_M_PERSON> testResult = personService.FindAll();

            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.AreEqual(expectedResult[i].P_FIRST_NAME, testResult[i].P_FIRST_NAME);
            }

        }

        [TestMethod]
        public void Insert_NormalCase()
        {
            IList<T_M_PERSON> expectedResult = new List<T_M_PERSON>();
            expectedResult.Add(new T_M_PERSON { P_ID = 1, P_FIRST_NAME = "MIFTAH", P_LAST_NAME = "FARIDZ" });
            expectedResult.Add(new T_M_PERSON { P_ID = 2, P_FIRST_NAME = "NASRUL", P_LAST_NAME = "AZIZ" });
            expectedResult.Add(new T_M_PERSON { P_ID = 3, P_FIRST_NAME = "TEST_FIRSTNAME", P_LAST_NAME = "TEST_LASTNAME" });

            PersonService personService = new PersonService(new SMS_DBEntities());

            T_M_PERSON personInsert = new T_M_PERSON { P_ID = 3, P_FIRST_NAME = "TEST_FIRSTNAME", P_LAST_NAME = "TEST_LASTNAME" };

            personService.Insert(personInsert);

            IList<T_M_PERSON> testResult = personService.FindAll();

            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.AreEqual(expectedResult[i].P_FIRST_NAME, testResult[i].P_FIRST_NAME);
            }

        }

        [TestMethod]
        public void Update_NormalCase()
        {
            IList<T_M_PERSON> expectedResult = new List<T_M_PERSON>();
            expectedResult.Add(new T_M_PERSON { P_ID = 1, P_FIRST_NAME = "MIFTAH", P_LAST_NAME = "FARIDZ" });
            expectedResult.Add(new T_M_PERSON { P_ID = 2, P_FIRST_NAME = "NASRUL", P_LAST_NAME = "AZIZ" });
            expectedResult.Add(new T_M_PERSON { P_ID = 3, P_FIRST_NAME = "FIRSTNAME_UPDT", P_LAST_NAME = "LASTNAME_UPDT" });

            PersonService personService = new PersonService(new SMS_DBEntities());

            T_M_PERSON personInsert = new T_M_PERSON { P_ID = 3, P_FIRST_NAME = "FIRSTNAME_UPDT", P_LAST_NAME = "LASTNAME_UPDT" };

            personService.Update(personInsert);

            IList<T_M_PERSON> testResult = personService.FindAll();

            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.AreEqual(expectedResult[i].P_FIRST_NAME, testResult[i].P_FIRST_NAME);
            }

        }

        [TestMethod]
        public void Delete_NormalCase()
        {
            IList<T_M_PERSON> expectedResult = new List<T_M_PERSON>();
            expectedResult.Add(new T_M_PERSON { P_ID = 1, P_FIRST_NAME = "MIFTAH", P_LAST_NAME = "FARIDZ" });
            expectedResult.Add(new T_M_PERSON { P_ID = 2, P_FIRST_NAME = "NASRUL", P_LAST_NAME = "AZIZ" });

            PersonService personService = new PersonService(new SMS_DBEntities());

            personService.Delete(3);

            IList<T_M_PERSON> testResult = personService.FindAll();

            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.AreEqual(expectedResult[i].P_FIRST_NAME, testResult[i].P_FIRST_NAME);
            }

        }

    }
}
