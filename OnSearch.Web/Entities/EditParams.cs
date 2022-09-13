using System.Collections.Generic;

namespace OnSearch.Web.Entities
{
    public class EditParams
    {
        public string key { get; set; }
        public string action { get; set; }
        public List<ScheduleData> added { get; set; }
        public List<ScheduleData> changed { get; set; }
        public List<ScheduleData> deleted { get; set; }
        public ScheduleData value { get; set; }
    }
}
