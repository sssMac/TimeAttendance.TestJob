namespace TimeAttendance.TestJob.Server.Hubs.SignalRModels
{
    public class TaskR
    {
        public string taskName      { get; set; }
        public string project       { get; set; }
        public string startDate         { get; set; }
        public string endDate       { get; set; }
        public string commType      { get; set; }
        public byte[] comm          { get; set; }
    }
}
