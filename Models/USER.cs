//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GREENWICH.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class USER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USER()
        {
            this.COMMENTs = new HashSet<COMMENT>();
            this.REACTIONs = new HashSet<REACTION>();
            this.IDEAs = new HashSet<IDEA>();
        }
    
        public long USERID { get; set; }
        public string USERNAME { get; set; }
        public string USEREMAIL { get; set; }
        public string USERPASSWORD { get; set; }
        public string FIRSTNAME { get; set; }
        public string LASTNAME { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string GENDER { get; set; }
        public Nullable<long> ROLEID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COMMENT> COMMENTs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REACTION> REACTIONs { get; set; }
        public virtual ROLE ROLE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IDEA> IDEAs { get; set; }
    }
}