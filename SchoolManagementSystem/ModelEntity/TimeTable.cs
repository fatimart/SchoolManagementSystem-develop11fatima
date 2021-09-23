//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SchoolManagementSystem.ModelEntity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TimeTable
    {
        public int TimeTableID { get; set; }
        public int UserID { get; set; }
        public int CourseID { get; set; }
        public int SectionID { get; set; }
        public string RoomNo { get; set; }
        public int Year { get; set; }
        public string TeacherName { get; set; }
        public string CourseName { get; set; }
        public string Time { get; set; }
        public string CourseCode { get; set; }
        public int SectionNo { get; set; }
        public System.DateTime Examdate { get; set; }
    
        public virtual Course Course { get; set; }
        public virtual Section Section { get; set; }
        public virtual User User { get; set; }
    }
}
