//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CourseDatabase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Student
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string teacher { get; set; }
        public int lesson_id { get; set; }
        public int duration { get; set; }
    
        public virtual Lesson Lesson { get; set; }
    }
}