﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SalesManagementSystem
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SMS_DBEntities : DbContext
    {
        public SMS_DBEntities()
            : base("name=SMS_DBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<T_M_AREA> T_M_AREA { get; set; }
        public DbSet<T_M_CATEGORY> T_M_CATEGORY { get; set; }
        public DbSet<T_M_PERSON> T_M_PERSON { get; set; }
        public DbSet<T_M_PRODUCT> T_M_PRODUCT { get; set; }
        public DbSet<T_M_STORE> T_M_STORE { get; set; }
        public DbSet<T_T_SALES_ORDR> T_T_SALES_ORDR { get; set; }
        public DbSet<T_T_SALES_ORDR_DETAIL> T_T_SALES_ORDR_DETAIL { get; set; }
        public DbSet<T_T_SALES_RTN> T_T_SALES_RTN { get; set; }
        public DbSet<T_T_SALES_RTN_DETAIL> T_T_SALES_RTN_DETAIL { get; set; }
    }
}