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
    
    public partial class ninja
    {
        public ninja()
        {
            this.badgeStepsAchieveds = new HashSet<badgeStepsAchieved>();
        }
    
        public int ninjaId { get; set; }
        public string ninjaName { get; set; }
        public int classId { get; set; }
        public string bio { get; set; }
        public System.DateTime joined { get; set; }
        public string websiteUrl { get; set; }
        public bool active { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
    
        public virtual ICollection<badgeStepsAchieved> badgeStepsAchieveds { get; set; }
        public virtual ninjaAttendance ninjaAttendance { get; set; }
        public virtual dojoClass dojoClass { get; set; }
    }
}
