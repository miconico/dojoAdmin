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
    
    public partial class ninjaAttendance
    {
        public int ninjaId { get; set; }
        public int classId { get; set; }
        public System.DateTime classDate { get; set; }
    
        public virtual dojoClass dojoClass { get; set; }
        public virtual ninja ninja { get; set; }
    }
}
