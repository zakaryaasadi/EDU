//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EDU.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class INTERACTIVE
    {
        public int interactive_id { get; set; }
        public int user_id { get; set; }
        public int news_id { get; set; }
        public int interactive_type_id { get; set; }
        public System.DateTime date { get; set; }
        public bool is_delete { get; set; }
    
        public virtual INTERACTIVE_TYPE INTERACTIVE_TYPE { get; set; }
        public virtual NEWS NEWS { get; set; }
        public virtual USER USER { get; set; }
    }
}
