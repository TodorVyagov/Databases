//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TelerikAcademy.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class WorkHour
    {
        public WorkHour()
        {
            this.WorkHoursLogs = new HashSet<WorkHoursLog>();
        }
    
        public int WorkHoursID { get; set; }
        public int EmployeeID { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Task { get; set; }
        public Nullable<int> Hours { get; set; }
        public string Comments { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual ICollection<WorkHoursLog> WorkHoursLogs { get; set; }
    }
}
