//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SmartCalendar.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Users()
        {
            this.Users_Sources = new HashSet<Users_Sources>();
        }
    
        public int user_id { get; set; }
        public string user_tz { get; set; }
        public string user_phone { get; set; }
        public string user_email { get; set; }
        public bool user_isRegistered { get; set; }
        public string user_firstname { get; set; }
        public string user_lastname { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Users_Sources> Users_Sources { get; set; }
    }
}
