using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace SalesManagementSystem.Service
{
    public class PersonService : IService<T_M_PERSON>
    {

        private SMS_DBEntities SmsRepository;

        public PersonService(SMS_DBEntities repo)
        {
            this.SmsRepository = repo;
        }

        public T_M_PERSON Find(int primaryKey)
        {
            try
            {
                return this.SmsRepository.T_M_PERSON.Single(person => person.P_ID == primaryKey);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public IList<T_M_PERSON> Find(T_M_PERSON personCriteria)
        {
            try
            {
                return (from person in this.SmsRepository.T_M_PERSON
                        where person.P_FIRST_NAME.Contains(personCriteria.P_FIRST_NAME) || person.P_LAST_NAME.Contains(personCriteria.P_LAST_NAME)
                        select person).ToList();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public IList<T_M_PERSON> FindAll()
        {
            try
            {
                return this.SmsRepository.T_M_PERSON.OrderBy(person => person.P_ID).ToList();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public bool Insert(T_M_PERSON obj)
        {
            try
            {
                this.SmsRepository.Entry<T_M_PERSON>(obj).State = System.Data.Entity.EntityState.Added;
                this.SmsRepository.SaveChanges();
                return true;
            }
            catch (DbEntityValidationException dbEx)
            {
                throw dbEx;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public bool Update(T_M_PERSON obj)
        {
            try
            {
                this.SmsRepository.Entry<T_M_PERSON>(obj).State = System.Data.Entity.EntityState.Modified;
                this.SmsRepository.SaveChanges();
                return true;
            }
            catch(DbEntityValidationException dbEx)
            {
                throw dbEx;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public bool Delete(int primaryKey)
        {
            try
            {
                T_M_PERSON person = this.SmsRepository.T_M_PERSON.Single(pers => pers.P_ID == primaryKey);
                this.SmsRepository.T_M_PERSON.Remove(person);
                return true;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}