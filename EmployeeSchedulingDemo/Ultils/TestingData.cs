using System;
namespace EmployeeSchedulingDemo.Ultils
{
    public class TestingData
    {
        public TestingData()
        {
        }

        public static ConstraintData SampleConstraintData()
        {
            return new ConstraintData
            {
                MaxDayOff = 3,
                MinDayOff = 1,

                MaxFTWorkingTimeOnWeek = 58,
                MinFTWorkingTimeOnWeek = 40,

                MaxPTWorkOnWeek = 58,
                MinPTWorkOnWeek = 20,

                MaxFTWorkingTimeInDay = 12,
                MaxPTWorkingTimeInDay = 8,

                MaxNormalHour = 8,

                MaxFTSessionDuration = 12,
                MinFTSessionDuration = 8,

                MaxPTSessionDuration = 8,
                MinPTSessionDuration = 5,

                MaxShiftInDay = 2,

                TimeStart = 7,
                TimeEnd = 22
            };
        }
    }
}
