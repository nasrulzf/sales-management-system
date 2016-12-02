using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesManagementSystem.Models
{
    public class CommonViewModel <T>
    {
        public IList<T> Lists { get; set; }
        public T Search { get; set; }
        public T Dto { get; set; }
        public IList<ErrorModel> error;
    }

    public class ErrorModel
    {
        public String ErrorCode { get; set; }
        public String ErrorMessage { get; set; }
    }
}