//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DojoTest
{
    using System;
    using System.Collections.Generic;
    
    public partial class mentor
    {
        public mentor()
        {
            this.dojoClasses = new HashSet<dojoClass>();
        }
    
        public int mentorId { get; set; }
        public string forename { get; set; }
        public string surname { get; set; }
        public string bio { get; set; }
        public string mentorUrl { get; set; }
        public System.DateTime dateJoined { get; set; }
        public bool active { get; set; }
    
        public virtual ICollection<dojoClass> dojoClasses { get; set; }
        public virtual mentorAttendance mentorAttendance { get; set; }
    }
}
