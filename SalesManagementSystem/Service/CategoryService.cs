using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace SalesManagementSystem.Service
{
    public class CategoryService : IService<T_M_CATEGORY>
    {

        private SMS_DBEntities SmsRepository;

        public CategoryService(SMS_DBEntities repo)
        {
            this.SmsRepository = repo;
        }

        public T_M_CATEGORY Find(string primaryKey)
        {
            try
            {
                return this.SmsRepository.T_M_CATEGORY.Single(category => category.CAT_ID == primaryKey);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public IList<T_M_CATEGORY> Find(T_M_CATEGORY categoryCriteria)
        {
            try
            {
                return (from category in this.SmsRepository.T_M_CATEGORY
                        where category.CAT_NAME.Contains(categoryCriteria.CAT_NAME)
                        select category).ToList();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public IList<T_M_CATEGORY> FindAll()
        {
            try
            {
                return this.SmsRepository.T_M_CATEGORY.OrderBy(category => category.CAT_NAME).ToList();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public bool Insert(T_M_CATEGORY obj)
        {
            try
            {
                this.SmsRepository.Entry<T_M_CATEGORY>(obj).State = System.Data.Entity.EntityState.Added;
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

        public bool Update(T_M_CATEGORY obj)
        {
            try
            {
                this.SmsRepository.Entry<T_M_CATEGORY>(obj).State = System.Data.Entity.EntityState.Modified;
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

        public bool Delete(string primaryKey)
        {
            try
            {
                T_M_CATEGORY category = this.SmsRepository.T_M_CATEGORY.Single(cat => cat.CAT_ID == primaryKey);
                this.SmsRepository.T_M_CATEGORY.Remove(category);
                return true;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}