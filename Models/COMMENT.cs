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
    
    public partial class COMMENT
    {
        public long COMMENTID { get; set; }
        public long IDEAID { get; set; }
        public long REPLYFOR { get; set; }
        public string CONTENT { get; set; }
        public string PRIVACY { get; set; }
    
        public virtual IDEA IDEA { get; set; }
        public virtual USER USER { get; set; }
    }
}
