using Google.OrTools.Sat;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EmployeeSchedulingDemo
{
    public class STS
    {
        static int numTimeFrames;
        static int numFTStaffs;
        static int numPTStaffs;
        static int numWeeks;
        static int numDays;
        static int numDayOffs;

        //constrains about fulltime on day
        static int minFTWorkOnWeek;
        static int maxFTWorkOnWeek;

        //constrains about parttime on day
        static int minPTWorkOnWeek;
        static int maxPTWorkOnWeek;

        //constrains about shift duration
        static int minShiftDuration;
        static int maxShiftDuration;

        static int minFTShiftDuration;

        // static int[][][] demands;
        static int[,,] demands;
        static int maxFTWorkingTimeInDay = 12;
        static int maxPTWorkingTimeInDay;

        static int numPosition;
        static int maxNormalHours = 8;

        static string[] skillStrings;

        static void Init()
        {
            skillStrings = new string[] { "Pha che", "Thu ngan", "Phuc vu" };

            numTimeFrames = 24;
            numFTStaffs = 4;
            numPTStaffs = 8;
            numWeeks = 1;
            numDays = numWeeks * 7;
            numDayOffs = 1;

            //constrains about fulltime on day
            minFTWorkOnWeek = 48;
            maxFTWorkOnWeek = 58;

            //constrains about parttime on day
            minPTWorkOnWeek = 30;
            maxPTWorkOnWeek = 48;

            //constrains about shift duration
            minShiftDuration = 5;

            minFTShiftDuration = 8;

            maxShiftDuration = 24;

            maxFTWorkingTimeInDay = 12;
            maxPTWorkingTimeInDay = 8;

            // 0: bartender,1: cashier,2: waiter
            numPosition = 3;

            //date - time - skill
            // demands = new int[][][] {

            //   };
            //date - skill - time
            demands = new int[,,]
           {     
             //Time: 0,    1,    2,    3,    4,    5,    6,    7,    8,    9,    10,   11,   12,   13,   14,   15,   16,   17,   18,   19,   20,   21,   22,   23,   24, 

                //t2
                { 
                    // 0: bartender,1: cashier,2: waiter
                    {0,   0,    0,    0,    0,    0,    0,    2,    2,    2,    2,    2,    2,    2,    2,    2,    2,    2,    3,    3,    3,    3,    2,    0,    0,  },
                    {0,   0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0,    0,  },
                    {0,   0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    2,    2,    2,    2,    2,    2,    0,    0,  }
                },
                //t3
                {
                    {0,   0,    0,    0,    0,    0,    0,    2,    2,    2,    2,    2,    2,    2,    2,    2,    2,    2,    3,    3,    3,    3,    2,    0,    0,  },
                    {0,   0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0,    0,  },
                    {0,   0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    2,    2,    2,    2,    2,    2,    0,    0,  }
                },
                //t4
                {   {0,   0,    0,    0,    0,    0,    0,    2,    2,    2,    2,    2,    2,    2,    2,    2,    2,    2,    3,    3,    3,    3,    2,    0,    0,  },
                    {0,   0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0,    0,  },
                    {0,   0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    2,    2,    2,    2,    2,    2,    0,    0,  }

                },
                //t5
                {
                    {0,   0,    0,    0,    0,    0,    0,    2,    2,    2,    2,    2,    2,    2,    2,    2,    2,    2,    3,    3,    3,    3,    2,    0,    0, },
                    {0,   0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0,    0,  },
                    {0,   0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    2,    2,    2,    2,    2,    2,    0,    0,  }
                 },
                //t6
                {   {0,   0,    0,    0,    0,    0,    0,    2,    2,    2,    2,    2,    2,    2,    2,    2,    2,    2,    4,    4,    4,    4,    2,    0,    0,  },
                    {0,   0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0,    0,  },
                    {0,   0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    2,    2,    2,    2,    2,    2,    0,    0,  }
                },
                //t7
                {
                    {0,   0,    0,    0,    0,    0,    0,    2,    2,    2,    2,    2,    2,    2,    2,    2,    2,    2,    4,    4,    4,    4,    2,    0,    0,  },
                    {0,   0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0,    0,  },
                    {0,   0,    0,    0,    0,    0,    0,    2,    2,    2,    2,    2,    2,    2,    2,    2,    2,    2,    2,    2,    2,    2,    2,    0,    0,  }
                },
                //cn
                {   {0,   0,    0,    0,    0,    0,    0,    2,    2,    2,    2,    2,    2,    2,    2,    2,    2,    2,    4,    4,    4,    4,    2,    0,    0, },
                    {0,   0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0,    0, },
                    {0,   0,    0,    0,    0,    0,    0,    2,    2,    2,    2,    2,    2,    2,    2,    2,    2,    2,    2,    2,    2,    2,    2,    0,    0,  }
                 }
           };



        }

        public static void Solve()
        {
            Init();
            var totalStaff = numFTStaffs + numPTStaffs;
            //day time pos
            var underCoverPenalties = new int[][][] { };
            var overCoverPenalties = new int[][][] { };

            //7h
            int timeStart = 6;

            //23h
            int timeEnd = 23;

            int maxShiftsInDay = 2;

            //staff - skill
            var skillFTStaffs = new int[,]
            {
                {1,1,1 },
                {1,1,1 },
                {1,1,1 },
                {1,1,1 },
            };

            var skillPTStaffs = new int[,]
            {
                {1,1,0},
                {0,1,1 },
                {1,1,1 },
                {1,1,1 },
                {0,1,0 },
                {0,1,0 },
                //add more
                {1,1,1 },
                {1,1,1 },

            };

            var availableFT = new int[,,] // [staff][day][time]
            {
               {
                        {1,   1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,  },
                        {1,   1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,  },
                        {1,   1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,  },
                        {1,   1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,  },
                        {1,   1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,  },
                        {1,   1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,  },
                        {1,   1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,  }

                },
               {        {1,   1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,  },
                        {0,   0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,  },
                        {1,   1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,  },
                        {1,   1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,  },
                        {1,   1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,  },
                        {1,   1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,  },
                        {1,   1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,  }
                },
               {
                        {1,   1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,  },
                        {1,   1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,  },
                        {0,   0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,  },
                        {1,   1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,  },
                        {1,   1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,  },
                        {1,   1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,  },
                        {1,   1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,  }
                },
               {        {1,   1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,  },
                        {1,   1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,  },
                        {1,   1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,  },
                        {1,   1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,  },
                        {0,   0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,  },
                        {1,   1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,  },
                        {1,   1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,  }
                }
            };

            var availablePT = new int[,,] // [staff][day][time]
          {
               {
                        {0,    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0,    0,},
                        {0,    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0,    0,},
                        {0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0,    0,},
                        {0,    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,},
                        {0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,},
                        {0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    1,    0,    0,},
                        {0,    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0,    0,},
                },
               {
                        {0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0, },
                        {0,    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0,    0,    0,    0,    0,    0,    0,    0, },
                        {0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0,    0, },
                        {0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0, },
                        {0,    0,    0,    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0,    0,    0,    0,    0, },
                        {0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    0,    0, },
                        {0,    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0,    0, },

                },
               {
                        {0,    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    1,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0, },
                        {0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0,    0, },
                        {0,    0,    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0,    0, },
                        {0,    0,    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0,    0,    0,    0,    0,    0,    0, },
                        {0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    0,    0, },
                        {0,    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0,    0, },
                        {0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0,    0, },

                },
               {
                        {0,    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0,    0,    0,    0,    0,    0,    0, },
                        {0,    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0,    0, },
                        {0,    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0,    0,    0,    0,    0,    0,    0, },
                        {0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0, },
                        {0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0,    0, },
                        {0,    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0, },
                        {0,    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0,    0, },
                },
              {
                        {0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0, },
                        {0,    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0,    0, },
                        {0,    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0,    0,    0,    0,    0,    0,    0, },
                        {0,    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0, },
                        {0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0, },
                        {0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0,    0, },
                        {0,    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0,    0, },

              },
              {
                        {0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0,    0, },
                        {0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0,    0, },
                        {0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0,    0, },
                        {0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0, },
                        {0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0, },
                        {0,    0,    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    0,    0, },
                        {0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0,    0, },
              },
              //add more
               {
                        {0,    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0,    0, },
                        {0,    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0,    0, },
                        {0,    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0,    0,    0,    0,    0,    0,    0, },
                        {0,    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0,    0, },
                        {0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0,    0, },
                        {0,    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0, },
                        {0,    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0,    0, },
                },
              {
                        {0,    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0,    0, },
                        {0,    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0,    0, },
                        {0,    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0,    0,    0,    0,    0,    0,    0, },
                        {0,    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0, },
                        {0,    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0,    0, },
                        {0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0,    0, },
                        {0,    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0,    0, },

              },
          };


            var model1 = new CpModel();
            //var model1 = new CpModel();

            //Define matrix

            IntVar[,,,] work_ft = new IntVar[numFTStaffs, numPosition, numDays, numTimeFrames];
            int[,,,] sch_ft = new int[numFTStaffs, numPosition, numDays, numTimeFrames];

            IntVar[,,,] work_pt = new IntVar[numPTStaffs, numPosition, numDays, numTimeFrames];
            int[,,,] sch_pt = new int[numPTStaffs, numPosition, numDays, numTimeFrames];

            var objIntVars = new List<IntVar>();
            var objIntCoeffs = new List<int>();

            var objIntVars2 = new List<IntVar>();
            var objIntCoeffs2 = new List<int>();

            foreach (int s in Range(numFTStaffs))
            {
                foreach (int p in Range(numPosition))
                {
                    foreach (int d in Range(numDays))
                    {
                        foreach (int t in Range(numTimeFrames))
                            work_ft[s, p, d, t] = model1.NewBoolVar($"workFT{s}_{p}_{d}_{t}");
                    }
                }
            }

            foreach (int s in Range(numPTStaffs))
            {
                foreach (int p in Range(numPosition))
                {
                    foreach (int d in Range(numDays))
                    {
                        foreach (int t in Range(numTimeFrames))
                            work_pt[s, p, d, t] = model1.NewBoolVar($"workPT{s}_{p}_{d}_{t}");
                    }
                }
            }


            //Nhân viên làm việc trong khoảng thời gian rãnh
            AddWokingInAvailableTimeConstrain(model1, work_ft, availableFT, numFTStaffs, numPosition, numDays, numTimeFrames);

            //Nhân viên làm việc trong khoảng thời gian rãnh
            AddWokingInAvailableTimeConstrain(model1, work_pt, availablePT, numPTStaffs, numPosition, numDays, numTimeFrames);

            //Tổng thời gian làm việc 1 tuần của nhân viên Fulltime, PartTime làm việc luôn nằm trong khoảng (min, max)
            foreach (int s in Range(numFTStaffs))
            {
                AddLimitWokingTimeByWeekConstraint(model1, work_ft, s, numPosition, numDays, numTimeFrames, minFTWorkOnWeek, maxFTWorkOnWeek);
            }

            foreach (int s in Range(numPTStaffs))
            {
                AddLimitWokingTimeByWeekConstraint(model1, work_pt, s, numPosition, numDays, numTimeFrames, minPTWorkOnWeek, maxPTWorkOnWeek);
            }

            //Constrains Ca làm việc có thể bắt đầu từ timeStart và kết thúc trước timeEnd
            AddDomainWokingTimeConstraints(model1, work_ft, numFTStaffs, numPosition, numDays, numTimeFrames, timeStart, timeEnd);
            AddDomainWokingTimeConstraints(model1, work_pt, numPTStaffs, numPosition, numDays, numTimeFrames, timeStart, timeEnd);

            //Tổng thời gian làm việc 1 ngày < maxHoursInDay
            AddMaxWorkingTimeInDayConstraints(model1, work_ft, numFTStaffs, numPosition, numDays, numTimeFrames, maxFTWorkingTimeInDay);
            AddMaxWorkingTimeInDayConstraints(model1, work_pt, numPTStaffs, numPosition, numDays, numTimeFrames, maxPTWorkingTimeInDay);

            //Mỗi nhân viên chỉ làm việc tại 1 ngày 1 vị trí 1 thời gian:
            AddUniqueWorkConstraint(model1, work_ft, numFTStaffs, numPosition, numDays, numTimeFrames);
            AddUniqueWorkConstraint(model1, work_pt, numPTStaffs, numPosition, numDays, numTimeFrames);

            //Nhân viên Fulltime được nghỉ ít nhất n ngày trong tuần
            AddMinDayOffConstrains(model1, work_ft, numFTStaffs, numPosition, numDays, numTimeFrames, numDayOffs);

            //Nhân viên e chỉ có thể làm việc tại các vị trí mà người đó đã đăng kí sẵn trong hợp đồng
            AddWorkBySkillConstraint(model1, work_ft, numFTStaffs, numPosition, numDays, numTimeFrames, skillFTStaffs);
            AddWorkBySkillConstraint(model1, work_pt, numPTStaffs, numPosition, numDays, numTimeFrames, skillPTStaffs);

            //Ca làm việc là những khoảng thời gian liên tục lớn hơn minShift

            //Có tối đa maxShiftsInDay
            foreach (int s in Range(numFTStaffs))
            {
                foreach (int d in Range(numDays))
                {
                    var countShifts_Day = model1.NewIntVar(0, maxShiftsInDay * 2, $"count_shift_day(day={d},staff={s}");
                    var countShift_Pos_s = new IntVar[numPosition];
                    foreach (int p in Range(numPosition))
                    {
                        var works = new IntVar[numTimeFrames];
                        foreach (int t in Range(numTimeFrames))
                        {
                            works[t] = work_ft[s, p, d, t];
                        }

                        //đếm số ca làm việc = countShift_Pos/2
                        //countShift_Pos = số ca làm việc * 2
                        var countShift_Pos = model1.NewIntVar(0, maxShiftsInDay * 2, $"count_shift_pos");
                        countShift_Pos_s[p] = countShift_Pos;

                        //xác định có làm việc không tại day d, staff s, pos p
                        var isDontWortAt = model1.NewBoolVar($"prod");
                        AddSequenceConstraint(model1, works, maxShiftsInDay, minFTShiftDuration, numTimeFrames, countShift_Pos, isDontWortAt);

                    }
                    model1.Add(countShifts_Day == LinearExpr.Sum(countShift_Pos_s));
                }
            }

            foreach (int s in Range(numPTStaffs))
            {
                foreach (int d in Range(numDays))
                {
                    var countShifts_Day = model1.NewIntVar(0, maxShiftsInDay * 2, $"count_shift_day(day={d},staff={s}");
                    var countShift_Pos_s = new IntVar[numPosition];
                    foreach (int p in Range(numPosition))
                    {
                        var works = new IntVar[numTimeFrames];
                        foreach (int t in Range(numTimeFrames))
                        {
                            works[t] = work_pt[s, p, d, t];
                        }

                        //đếm số ca làm việc = countShift_Pos/2
                        //countShift_Pos = số ca làm việc * 2
                        var countShift_Pos = model1.NewIntVar(0, maxShiftsInDay * 2, $"count_shift_pos");
                        countShift_Pos_s[p] = countShift_Pos;

                        //xác định có làm việc không tại day d, staff s, pos p
                        var isDontWortAt = model1.NewBoolVar($"prod");
                        AddSequenceConstraint(model1, works, maxShiftsInDay, minShiftDuration, numTimeFrames, countShift_Pos, isDontWortAt);

                    }
                    model1.Add(countShifts_Day == LinearExpr.Sum(countShift_Pos_s));
                }
            }

            /*
                        // = 1 nếu ngày đó nhân viên làm và ngược lại
                        // var workDays = new IntVar[numFTStaffs, numDays];
            */

            //cover constraints for fulltime
            foreach (int d in Range(numDays))
            {
                foreach (int t in Range(numTimeFrames))
                {
                    if (t <= timeStart || t >= timeEnd)
                    {
                        continue;
                    }

                    foreach (int p in Range(numPosition))
                    {

                        var works = new List<IntVar>();

                        foreach (int s in Range(numFTStaffs))
                        {
                            works.Add(work_ft[s, p, d, t]);
                        }

                        foreach (int s in Range(numPTStaffs))
                        {
                            works.Add(work_pt[s, p, d, t]);
                        }

                        int demand = demands[d, p, t];

                        int overCoverPenalty = d == 5 || d == 6 ? 2 : 1;
                        int underCoverPenalty = d == 5 || d == 6 ? 6 : 3;

                        //đếm số nhân viên làm việc tại khoảng thời gian t ngày d

                        var worked = model1.NewIntVar(1, totalStaff, "");
                        model1.Add(LinearExpr.Sum(works) == worked);

                        var name = $"excessPanalty_demand(shift={t}, position={p}, day={d}";
                        var excessPanalty = model1.NewIntVar(0, 100, name);
                        var excess = model1.NewIntVar(-totalStaff, totalStaff, "excess");
                        var excessAbs = model1.NewIntVar(0, totalStaff, "excessAbs");

                        //hệ số xác định tình trạng ca là under / over
                        var a = model1.NewIntVar(0, totalStaff, "alpha");
                        // b = reality - demand
                        // a = (b + |b|)/2 => a = 0 if under || a = b if over
                        // excess panalty = a*overPanalty + (|b| - a)*underPanalty
                        model1.Add(excess == worked - demand);
                        model1.AddAbsEquality(excessAbs, excess);
                        model1.Add(2 * a == (excess + excessAbs));
                        model1.Add(excessPanalty == a * overCoverPenalty + (excessAbs - a) * underCoverPenalty);

                        objIntVars.Add(excessPanalty);
                        objIntCoeffs.Add(1);

                    }
                }
            }

            //OT minimize
            foreach (int s in Range(numFTStaffs))
            {
                foreach (int d in Range(numDays))
                {

                    var works = new List<IntVar>();
                    foreach (int p in Range(numPosition))
                    {
                        foreach (int t in Range(numTimeFrames))
                        {
                            works.Add(work_ft[s, p, d, t]);
                        }

                    }

                    //đếm số giờ làm việc
                    var workedTimesInday = model1.NewIntVar(0, numTimeFrames, "");
                    model1.Add(LinearExpr.Sum(works) == workedTimesInday);

                    var oT = model1.NewIntVar(-numTimeFrames, numTimeFrames, "ot");
                    var oT_Abs = model1.NewIntVar(0, numTimeFrames, "ot_Abs");
                    //hệ số xác định số giờ OT

                    var a = model1.NewIntVar(0, numTimeFrames, "oT_Times");

                    // số giờ làm việc - 8 => 
                    model1.Add(oT == workedTimesInday - maxNormalHours);
                    model1.AddAbsEquality(oT_Abs, oT);
                    model1.Add(2 * a == (oT + oT_Abs));

                    objIntVars.Add(a);
                    objIntCoeffs.Add(1);

                }
            }

            // Objective
            var objIntSum = LinearExpr.ScalProd(objIntVars, objIntCoeffs);

            model1.Minimize(objIntSum);

            CpSolver solver = new CpSolver();
            // Adds a time limit. Parameters are stored as strings in the solver.
            solver.StringParameters = "num_search_workers:8, log_search_progress: true, max_time_in_seconds:120";
            CpSolverStatus status1 = solver.Solve(model1);


            using StreamWriter writer = new StreamWriter("D:\\STS\\outGop2.csv");
            Console.SetOut(writer);
            Console.WriteLine("Statistics");
            Console.WriteLine($"  - status          : {status1}");
            Console.WriteLine($"  - conflicts       : {solver.NumConflicts()}");
            Console.WriteLine($"  - branches        : {solver.NumBranches()}");
            Console.WriteLine($"  - wall time       : {solver.WallTime()}");

            //work_ft[s, p, d, t] = model1.NewBoolVar($"workFT{s}_{p}_{d}_{t}");
            if (status1 == CpSolverStatus.Optimal || status1 == CpSolverStatus.Feasible)
            {
                foreach (int s in Range(numFTStaffs))
                {
                    //Console.WriteLine($"Staff {s}:");
                    foreach (int d in Range(numDays))
                    {
                        // Console.WriteLine($"\tDay {d}:");
                        foreach (int p in Range(numPosition))
                        {

                            // Console.Write($",,");
                            foreach (int t in Range(numTimeFrames))
                            {
                                // Console.Write($"{solver.Value(work_ft[s, p, d, t])},");
                                sch_ft[s, p, d, t] = (int)solver.Value(work_ft[s, p, d, t]);
                            }
                            //Console.WriteLine();
                        }
                    }
                }

                foreach (int d in Range(numDays))
                {
                    Console.WriteLine($"\tDay {d}:");
                    foreach (int p in Range(numPosition))
                    {
                        Console.WriteLine($"Skill {skillStrings[p]}:");


                        foreach (int s in Range(numFTStaffs))
                        {
                            Console.WriteLine($"Staff {s}:");
                            Console.Write($",,");
                            foreach (int t in Range(numTimeFrames))
                            {
                                Console.Write($"{sch_ft[s, p, d, t]},");
                                //sch_ft[s, p, d, t] = (int)solver.Value(work_ft[s, p, d, t]);
                            }
                            Console.WriteLine();
                        }

                        foreach (int s in Range(numPTStaffs))
                        {
                            Console.WriteLine($"Staff {s + numFTStaffs}/ s:");
                            Console.Write($",,");
                            foreach (int t in Range(numTimeFrames))
                            {
                                Console.Write($"{solver.Value(work_pt[s, p, d, t])},");
                                sch_pt[s, p, d, t] = (int)solver.Value(work_pt[s, p, d, t]);
                            }
                            Console.WriteLine();
                        }
                    }
                }
            }
        }

        /// <summary>
        ///    Nhân viên chỉ làm việc trong khoảng thời gian availableTimes cho trước
        /// </summary>
        /// <param name="model"></param>
        /// <param name="work_sche"></param>
        /// <param name="availableTimes"></param>
        /// <param name="numStaffs"></param>
        /// <param name="numPosition"></param>
        /// <param name="numDays"></param>
        /// <param name="numTimeFrames"></param>
        static void AddWokingInAvailableTimeConstrain(CpModel model, IntVar[,,,] work_sche, int[,,] availableTimes,
                                                        int numStaffs, int numPosition, int numDays, int numTimeFrames)
        {
            foreach (int e in Range(numStaffs))
            {
                foreach (int d in Range(numDays))
                {
                    foreach (int p in Range(numPosition))
                    {
                        foreach (int t in Range(numTimeFrames))
                        {
                            model.Add(work_sche[e, p, d, t] <= availableTimes[e, d, t]);
                        }
                    }

                }
            }
        }
        static void AddLimitWokingTimeByWeekConstraint(CpModel model, IntVar[,,,] work_ft, int staffIndex, int numPosition, int numDays, int numTimeFrames, int min, int max)
        {
            var sumWorkTimeByWeek = new List<IntVar>();
            foreach (int d in Range(numDays))
            {
                foreach (int p in Range(numPosition))
                {

                    foreach (int t in Range(numTimeFrames))
                    {
                        sumWorkTimeByWeek.Add(work_ft[staffIndex, p, d, t]);
                    }
                }
            }
            model.AddLinearConstraint(LinearExpr.Sum(sumWorkTimeByWeek), min, max);
            // model.Add(LinearExpr.Sum(sumWorkTimeByWeek) >= min);
            // model.Add(sumWorkTimeByWeek <= max);
        }

        static void AddWorkBySkillConstraint(CpModel model, IntVar[,,,] work_ft,
                                                 int numStaffs, int numPosition, int numDays, int numTimeFrames, int[,] skillStaffs)
        {
            foreach (int s in Range(numStaffs))
            {
                foreach (int p in Range(numPosition))
                {
                    if (skillStaffs[s, p] == 0)
                    {
                        var sequence = new List<ILiteral>();
                        foreach (int d in Range(numDays))
                        {
                            foreach (int t in Range(numTimeFrames))
                            {

                                sequence.Add(work_ft[s, p, d, t].Not());

                            }
                        }

                        model.AddBoolOr(sequence);
                    }
                }
            }
        }
        static void AddUniqueWorkConstraint(CpModel model, IntVar[,,,] work_ft,
                                                 int numStaffs, int numPosition, int numDays, int numTimeFrames)
        {
            foreach (int s in Range(numStaffs))
            {
                foreach (int d in Range(numDays))
                {
                    foreach (int t in Range(numTimeFrames))
                    {
                        var sum = new IntVar[numPosition];
                        foreach (int k in Range(numPosition))
                        {
                            sum[k] = work_ft[s, k, d, t];
                        }

                        model.Add(LinearExpr.Sum(sum) <= 1);

                    }
                }
            }
        }
        static void AddDomainWokingTimeConstraints(CpModel model, IntVar[,,,] work_ft,
                                                 int numStaffs, int numPosition, int numDays, int numTimeFrames, int timeStart, int timeEnd)
        {
            foreach (int s in Range(numStaffs))
            {
                foreach (int d in Range(numDays))
                {
                    var sumStart = new List<IntVar>();
                    var sumEnd = new List<IntVar>();
                    foreach (int p in Range(numPosition))
                    {
                        foreach (int t in Range(numTimeFrames))
                        {
                            if (t <= timeStart)
                            {
                                sumStart.Add(work_ft[s, p, d, t]);
                            }

                            if (t >= timeEnd)
                            {
                                sumStart.Add(work_ft[s, p, d, t]);
                            }
                        }
                    }
                    model.Add(LinearExpr.Sum(sumStart) == 0);
                    model.Add(LinearExpr.Sum(sumEnd) == 0);
                }
            }
        }
        static void AddMaxWorkingTimeInDayConstraints(CpModel model, IntVar[,,,] work_sch,
                                                 int numStaffs, int numPosition, int numDays, int numTimeFrames, int maxWorkingTimeInDay)
        {
            foreach (int s in Range(numStaffs))
            {
                foreach (int d in Range(numDays))
                {
                    var sumWorkTimeByDay = new List<IntVar>();
                    foreach (int p in Range(numPosition))
                    {
                        foreach (int t in Range(numTimeFrames))
                        {
                            sumWorkTimeByDay.Add(work_sch[s, p, d, t]);
                        }
                    }
                    model.Add(LinearExpr.Sum(sumWorkTimeByDay) <= maxWorkingTimeInDay);
                }
            }
        }

        static void AddMinDayOffConstrains(CpModel model, IntVar[,,,] work,
                                                 int numStaffs, int numPosition, int numDays, int numTimeFrames, int mindayOff)
        {
            foreach (int s in Range(numStaffs))
            {
                //Giá trị của dayWork = 1 nếu ngày d có làm và ngược lại
                IntVar[] dayWorks = new IntVar[numDays];
                foreach (int d in Range(numDays))
                {
                    var name = $"workDay(staff={s},day={d})";
                    dayWorks[d] = model.NewBoolVar(name);

                    //var sequence = new List<ILiteral>();
                    var temp = new List<IntVar>();
                    foreach (int t in Range(numTimeFrames))
                    {
                        foreach (int k in Range(numPosition))
                        {
                            temp.Add(work[s, k, d, t]);
                        }
                    }
                    model.AddMaxEquality(dayWorks[d], temp);
                    //workDays[s, d] = dayWorks[d];
                }

                // tổng ngày làm việc ít hơn tổng ngày trong tuần trừ số ngày nghỉ tối thiểu
                model.Add(LinearExpr.Sum(dayWorks) <= numDays - mindayOff);
            }
        }

        static void countSubSequence(CpModel model)
        {

        }
        static void AddSequenceConstraint(CpModel model, IntVar[] works, int maxShiftsInDay, int minShiftDuration, int numTimeFrames, IntVar count,
            IntVar isWortAt)
        {
            //Đếm số sub-sequence(ca làm việc)

            var n = numTimeFrames;
            var arrTemp = new IntVar[n + 1];
            var arrTemp1 = new IntVar[n + 1];
            foreach (int t in Range(n + 1))
            {
                arrTemp[t] = model.NewIntVar(0, 2, $"d_subsequence{t}");
                arrTemp1[t] = model.NewIntVar(0, 2, $"d_mod{t}");
            }

            //count
            foreach (int t in Range(n + 1))
            {
                var start = t - 1;
                var lenght = 2;
                // cặp 2 phần từ liên tiếp
                //nếu 2 phần từ liên tiếp khác nhau => có sự bắt đầu ca hoặc kết thúc ca
                var transition = new List<IntVar>();
                foreach (var i in Range(lenght))
                {
                    //trường hợp đặc biệt
                    // phần từ đầu tiên
                    if (start == -1 && i == 0)
                    {
                        continue;
                    }

                    // phần từ đầu cuối cùng
                    if (start == n - 1 && i == lenght - 1)
                    {
                        continue;
                    }
                    transition.Add(works[start + i]);
                }
                model.Add(arrTemp[t] == LinearExpr.Sum(transition));
                model.AddModuloEquality(arrTemp1[t], arrTemp[t], 2);
            }

            //count subsequence

            model.Add(count == LinearExpr.Sum(arrTemp1));
            //model.Add(count <= maxShiftsInDay * 2);

            //Mỗi (ca làm việc) bao gồm những những sub-sequence liên tục có độ dài > minShift
            //check các element sub-sequence tất cả có = 0 <=>không có ca làm nào tại vị trí đó vào ngày hôm đó không           
            model.AddMaxEquality(isWortAt, works);
            ILiteral check = isWortAt;

            // cấm các ca làm việc có thời gian nhỏ hơn minShiftDuration hoặc không có ca nào diễn ra
            foreach (var length in Range(1, minShiftDuration))
            {
                foreach (var start in Range(works.Length - length + 1))
                {
                    model.AddBoolOr(NegatedBoundedSpan(works, start, length)).OnlyEnforceIf(check);
                }
            }
        }

        /// <summary>
        /// Filters an isolated sub-sequence of variables assigned to True.
        /// Extract the span of Boolean variables[start, start + length), negate them,
        /// and if there is variables to the left / right of this span, surround the
        /// span by them in non negated form.
        /// </summary>
        /// <param name="works">A list of variables to extract the span from.</param>
        /// <param name="start">The start to the span.</param>
        /// <param name="length">The length of the span.</param>
        /// <returns>An array of variables which conjunction will be false if the
        /// sub-list is assigned to True, and correctly bounded by variables assigned
        /// to False, or by the start or end of works.</returns>
        static ILiteral[] NegatedBoundedSpan(IntVar[] works, int start, int length)
        {
            var sequence = new List<ILiteral>();

            if (start > 0)
                sequence.Add(works[start - 1]);

            foreach (var i in Range(length))
                sequence.Add(works[start + i].Not());

            if (start + length < works.Length)
                sequence.Add(works[start + length]);

            return sequence.ToArray();
        }

        /// <summary>
        /// C# equivalent of Python range (start, stop)
        /// </summary>
        /// <param name="start">The inclusive start.</param>
        /// <param name="stop">The exclusive stop.</param>
        /// <returns>A sequence of integers.</returns>
        static IEnumerable<int> Range(int start, int stop)
        {
            foreach (var i in Enumerable.Range(start, stop - start))
                yield return i;
        }

        /// <summary>
        /// C# equivalent of Python range (stop)
        /// </summary>
        /// <param name="stop">The exclusive stop.</param>
        /// <returns>A sequence of integers.</returns>
        static IEnumerable<int> Range(int stop)
        {
            return Range(0, stop);
        }
    }

    class STSSolutionPrinter : CpSolverSolutionCallback
    {

        private IntVar[,,,] work_sch;
        private IEnumerable<int> _sols;
        private int numDays;
        private int numStaffs;
        private int numTimeFrames;
        private int numPosition;
        private List<IntVar> objIntVars;
        private List<int> objIntCoeffs;

        public STSSolutionPrinter(IntVar[,,,] work_sch, int numStaffs, int num_days, int numTimeFrames, int numPositions, IEnumerable<int> sols, List<IntVar> objIntVars, List<int> objIntCoeffs)
        {
            this.work_sch = work_sch;
            this.numStaffs = numStaffs;
            this.numDays = num_days;
            this.numTimeFrames = numTimeFrames;
            this.numPosition = numPositions;
            this._sols = sols;
            this.objIntVars = objIntVars;
            this.objIntCoeffs = objIntCoeffs;
        }

        public override void OnSolutionCallback()
        {

            if (_sols.Contains(solution_count_))
            {
                Console.WriteLine($"Solution {solution_count_}");

                foreach (int s in Range(numStaffs))
                {
                    Console.WriteLine($"Staff {s}:");
                    foreach (int d in Range(numDays))
                    {
                        Console.WriteLine($"\tDay {d}:");
                        foreach (int p in Range(numPosition))
                        {

                            Console.Write($",,");
                            foreach (int t in Range(numTimeFrames))
                            {
                                Console.Write($"{Value(work_sch[s, p, d, t])},");
                            }
                            Console.WriteLine();
                        }
                    }


                    foreach (var (i, var) in objIntVars.Select((x, i) => (i, x)))
                    {
                        
                        if (Value(var) > 0)
                        {
                            Console.WriteLine(
                                $"  {var.Name()} violated by {Value(var)}, linear penalty={objIntCoeffs[i]}");
                        }
                    }
                    solution_count_++;
                    if (solution_count_ == 10)
                    {
                        StopSearch();
                    }
                }

            }


        }

        /// <summary>
        /// C# equivalent of Python range (start, stop)
        /// </summary>
        /// <param name="start">The inclusive start.</param>
        /// <param name="stop">The exclusive stop.</param>
        /// <returns>A sequence of integers.</returns>
        static IEnumerable<int> Range(int start, int stop)
        {
            foreach (var i in Enumerable.Range(start, stop - start))
                yield return i;
        }

        /// <summary>
        /// C# equivalent of Python range (stop)
        /// </summary>
        /// <param name="stop">The exclusive stop.</param>
        /// <returns>A sequence of integers.</returns>
        static IEnumerable<int> Range(int stop)
        {
            return Range(0, stop);
        }
        private int solution_count_;
        public int SolutionCount()
        {
            return solution_count_;
        }


    }


}
