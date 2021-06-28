using System.Collections.Generic;

namespace EmployeeSchedulingDemo.data
{
    public class Staff
    {
        private int _id;
        private bool _isFulltime;

        public int Id { get => _id; set => _id = value; }
        public string Name { get; set; }
        public AvailableTime[] Availables { get; set; }//[day][timeIndex]
        public Skill[] Skills { get; set; }
        public bool IsFulltime { get => _isFulltime; set => _isFulltime = value; }
    }
}
