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
    
    public partial class badgeStepsAchieved
    {
        public int stepAchievedId { get; set; }
        public int badgeStepId { get; set; }
        public int ninjaId { get; set; }
    
        public virtual badgeStep badgeStep { get; set; }
        public virtual ninja ninja { get; set; }
    }
}