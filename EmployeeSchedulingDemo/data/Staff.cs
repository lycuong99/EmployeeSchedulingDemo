using System.Collections.Generic;

namespace EmployeeSchedulingDemo.data
{
    class Staff
    {
        private int id;
        private int[][] availables; //[day][timeIndex]
        private bool isFulltime;
        private int[] positions;
        public int Id { get => id; set => id = value; }
        public int[][] Available { get => availables; set => availables = value; }
        public bool IsFulltime { get => isFulltime; set => isFulltime = value; }
    }
}
