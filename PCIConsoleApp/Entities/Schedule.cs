using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PCIApplication
{
    public class Schedule
    {
        public int Id { get; set; }
        public int ContractTimeMinutes { get; set; }
        public DateTime Date { get; set; }
        public bool IsFullDayAbsence { get; set; }
        public string Name { get; set; }
        public Guid PersonId { get; set; }
        public List<Projection> Projection { get; set; }

    }

    public class ScheduleResult
    {
        public Schedule[] Schedules { get; set; }
    }

    public class RootObject
    {
        public ScheduleResult ScheduleResult { get; set; }
    }
}
