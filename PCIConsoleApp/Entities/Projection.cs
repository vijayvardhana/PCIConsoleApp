using System;

namespace PCIApplication
{
    public class Projection
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public int Minutes { get; set; }
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
    }
}
