using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnSearch.Web.Entities
{
    public class ScheduleData
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
