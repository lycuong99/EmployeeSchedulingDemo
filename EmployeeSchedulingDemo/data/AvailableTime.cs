using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSchedulingDemo.data
{
    public class AvailableTime
    {
        public int Day { get; set; }
        public Session[] Sessions { get; set; }
    }

    public class AvailablePool
    {
        public AvailableTime[] Availables { get; set; }//[day][timeIndex]

        /*   getAvailableTimeByDay()
           {

           }*/
    }
}
