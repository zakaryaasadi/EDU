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
    
    public partial class IN_OUT_BOX
    {
        public int in_out_box_id { get; set; }
        public int from_user_id { get; set; }
        public int to_user_id { get; set; }
        public int message_id { get; set; }
        public System.DateTime date { get; set; }
        public bool is_delete { get; set; }
    
        public virtual MESSAGE MESSAGE { get; set; }
        public virtual USER USER { get; set; }
        public virtual USER USER1 { get; set; }
    }
}
