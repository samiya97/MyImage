//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace myimage.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int order_id { get; set; }
        public string Email_id { get; set; }
        public Nullable<int> No_print { get; set; }
        public Nullable<decimal> credit_cardNo { get; set; }
        public Nullable<int> Total_Payment { get; set; }
        public string Delievery_status { get; set; }
    }
}
