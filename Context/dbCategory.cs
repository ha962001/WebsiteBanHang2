//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebsiteBanHang.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class dbCategory
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string Slug { get; set; }
        public Nullable<bool> ShowOnHomePage { get; set; }
        public Nullable<int> DisplayOder { get; set; }
        public Nullable<System.DateTime> CreatedOnUtc { get; set; }
        public Nullable<System.DateTime> UpdateOnUtc { get; set; }
        public Nullable<bool> Deleted { get; set; }
    }
}
