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
    
    public partial class SESSION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SESSION()
        {
            this.TIME_SCHEDULE = new HashSet<TIME_SCHEDULE>();
        }
    
        public int session_id { get; set; }
        public string session_name { get; set; }
        public bool is_delete { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TIME_SCHEDULE> TIME_SCHEDULE { get; set; }
    }
}
