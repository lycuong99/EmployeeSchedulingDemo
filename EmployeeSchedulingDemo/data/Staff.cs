using System.Collections.Generic;

namespace EmployeeSchedulingDemo.data
{
    class Staff
    {
        private int id;
        public string Name { get; set; }
        public AvailableTime[] Availables { get; set; }//[day][timeIndex]
        private bool isFulltime;
        public Skill[] Skills { get; set; }


        public int Id { get => id; set => id = value; }
     
        public bool IsFulltime { get => isFulltime; set => isFulltime = value; }
    }
}
