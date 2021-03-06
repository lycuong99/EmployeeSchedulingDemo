using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSchedulingDemo.data
{
    public class Demand
    {
        public int Quantity { set; get; }
        public Session Session { set; get; }
    }

    public class DemandByDay
    {
        public int Day { set; get; }
        public DemandBySkill[] DemandBySkills { get; set; }
    }

    public class DemandBySkill
    {
        public Skill Skill { set; get; }
        public Demand[] Demands { get; set; }
    }
}
