//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class T_T_SALES_ORDR
    {
        public T_T_SALES_ORDR()
        {
            this.T_T_SALES_ORDR_DETAIL = new HashSet<T_T_SALES_ORDR_DETAIL>();
            this.T_T_SALES_RTN = new HashSet<T_T_SALES_RTN>();
        }
    
        public int SLS_ORDER_ID { get; set; }
        public System.DateTime SLS_ORDER_DT { get; set; }
        public Nullable<System.DateTime> SLS_DELIVERY_REQ_DT { get; set; }
        public Nullable<System.DateTime> SLS_DELIVERY_DT { get; set; }
        public string STORE_ID { get; set; }
        public string CREATED_BY { get; set; }
        public Nullable<System.DateTime> CREATED_DT { get; set; }
        public string UPDATED_BY { get; set; }
        public Nullable<System.DateTime> UPDATED_DT { get; set; }
    
        public virtual T_M_STORE T_M_STORE { get; set; }
        public virtual ICollection<T_T_SALES_ORDR_DETAIL> T_T_SALES_ORDR_DETAIL { get; set; }
        public virtual ICollection<T_T_SALES_RTN> T_T_SALES_RTN { get; set; }
    }
}