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
    
    public partial class dojoClass
    {
        public dojoClass()
        {
            this.mentorAttendances = new HashSet<mentorAttendance>();
            this.ninjaAttendances = new HashSet<ninjaAttendance>();
        }
    
        public int classId { get; set; }
        public string className { get; set; }
        public string classDesc { get; set; }
        public int mentorId { get; set; }
        public System.DateTime dateCommenced { get; set; }
        public string classUrl { get; set; }
        public bool active { get; set; }
    
        public virtual mentor mentor { get; set; }
        public virtual ICollection<mentorAttendance> mentorAttendances { get; set; }
        public virtual ICollection<ninjaAttendance> ninjaAttendances { get; set; }
    }
}
