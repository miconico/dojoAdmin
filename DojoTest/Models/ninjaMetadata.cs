using System;
using System.ComponentModel.DataAnnotations;

namespace DojoTest
{
    [MetadataType(typeof(ninjaMetadata))]
    public partial class ninja
    {
    }

    public partial class ninjaMetadata
    {
        [Required(ErrorMessage = "Please enter : ninjaId")]
        [Display(Name = "ninjaId")]
        public int ninjaId { get; set; }

        [Display(Name = "ninjaName")]
        [MaxLength(100)]
        public string ninjaName { get; set; }

        [Display(Name = "classId")]
        public int classId { get; set; }

        [Display(Name = "bio")]
        [MaxLength(5000)]
        public string bio { get; set; }

        [Display(Name = "joined")]
        public DateTime joined { get; set; }

        [Display(Name = "websiteUrl")]
        [MaxLength(250)]
        public string websiteUrl { get; set; }

        [Required(ErrorMessage = "Please enter : active")]
        [Display(Name = "active")]
        public bool active { get; set; }

        [Display(Name = "DOB")]
        public DateTime DOB { get; set; }

        [Display(Name = "badgeStepsAchieveds")]
        public badgeStepsAchieved badgeStepsAchieveds { get; set; }

        [Display(Name = "ninjaAttendance")]
        public ninjaAttendance ninjaAttendance { get; set; }

    }
}
