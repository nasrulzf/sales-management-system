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
    
    public partial class T_M_AREA
    {
        public T_M_AREA()
        {
            this.T_M_STORE = new HashSet<T_M_STORE>();
        }
    
        public int AR_ID { get; set; }
        public string AR_NAME { get; set; }
    
        public virtual ICollection<T_M_STORE> T_M_STORE { get; set; }
    }
}
