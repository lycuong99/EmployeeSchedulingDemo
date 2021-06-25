﻿using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeSchedulingDemo.data;
using EmployeeSchedulingDemo.Ultils;

namespace EmployeeSchedulingDemo
{
    public class DataInput
    {
        public List<Skill> Skills { get; set; }
        public Dictionary<TypeStaff, List<Staff>> StaffDic { get; set; }
        public DemandByDay[] Demand { get; set; }
        public int NumDay { get; set; }
        public int NumTimeFrame { get; set; }

        //Id Skills must be sequequce continues and start by 0
        public DataInput()
        {
            NumDay = 7;
            NumTimeFrame = 24;
        }
        public int GetTotalStaff()
        {
            return StaffDic[TypeStaff.FULL_TIME].Count + StaffDic[TypeStaff.PART_TIME].Count;
        }
        public int GetNumSkill()
        {
            return Skills.Count;
        }
        public int GetNumStaff(TypeStaff type)
        {
            return type switch
            {
                TypeStaff.FULL_TIME => StaffDic[TypeStaff.FULL_TIME].Count,
                TypeStaff.PART_TIME => StaffDic[TypeStaff.PART_TIME].Count,
                TypeStaff.All => StaffDic[TypeStaff.FULL_TIME].Count + StaffDic[TypeStaff.PART_TIME].Count,
                _ => 0,
            };
        }

        public int[,] GetSkillMatrixOf(TypeStaff type)
        {
            if (type == TypeStaff.FULL_TIME)
            {
                return ConvertSkillMatrix(StaffDic[TypeStaff.FULL_TIME], Skills);
            }
            else if (type == TypeStaff.PART_TIME)
            {
                return ConvertSkillMatrix(StaffDic[TypeStaff.PART_TIME], Skills);
            }

            return null;
        }

        public int[,,] GetAvailableMatrixOf(TypeStaff type)
        {
            if (type == TypeStaff.FULL_TIME)
            {
                return ConvertAvailableMatrix(StaffDic[TypeStaff.FULL_TIME], NumDay, NumTimeFrame);
            }
            else if (type == TypeStaff.PART_TIME)
            {
                return ConvertAvailableMatrix(StaffDic[TypeStaff.PART_TIME], NumDay, NumTimeFrame);
            }
            return null;
        }

        public int[,,] GetDemandMatrix()
        {
            return ConvertDemandMatrix(Demand, NumDay, NumTimeFrame, Skills);
        }
        public static int[,,] ConvertDemandMatrix(DemandByDay[] Demand, int TotalDay, int TotalTimeFrame, List<Skill> Skills)
        {
            int[,,] demandMatrix = new int[TotalDay, Skills.Count, TotalTimeFrame];
            foreach (int day in Helper.Range(TotalDay))
            {
                DemandByDay demandByDay = Demand.ToList().Find(e => e.Day == day);
                if (demandByDay == null) continue;
                foreach (int skill in Helper.Range(Skills.Count))
                {
                    DemandBySkill demandBySkill = demandByDay.DemandBySkills.ToList().Find(e => e.Skill.Equals(Skills.ElementAt(skill)));
                    Demand[] demands = demandBySkill.Demands;

                    for (int i = 0; i < demands.Length; i++)
                    {
                        int start = demands[i].Session.Start;
                        int end = demands[i].Session.End;
                        int quality = demands[i].Quantity;
                        for (int timeIndex = start; timeIndex <= end && timeIndex < TotalTimeFrame; timeIndex++)
                        {
                            demandMatrix[day, skill, timeIndex] = quality;
                        }
                    }
                }
            }
            return demandMatrix;
        }

        public static int[,,] ConvertAvailableMatrix(List<Staff> Staffs, int TotalDay, int TotalTimeFrame)
        {
            var availableMatrix = new int[Staffs.Count, TotalDay, TotalTimeFrame];

            foreach (int staffIndex in Helper.Range(Staffs.Count))
            {
                AvailableTime[] availables = Staffs.ElementAt(staffIndex).Availables;

                //flag  Day in availables
                int i = 0;

                foreach (int day in Helper.Range(TotalDay))
                {
                    if (i < availables.Length && availables[i].Day == day && availables[i].Sessions.Length != 0)
                    {
                        int[] tmp = new int[TotalTimeFrame];
                        var sessions = availables[i].Sessions;
                        for (int sessionIndex = 0; sessionIndex < sessions.Length; sessionIndex++)
                        {
                            int start = sessions[sessionIndex].Start;
                            int end = sessions[sessionIndex].End;
                            for (int timeIndex = start; timeIndex <= end; timeIndex++)
                            {
                                availableMatrix[staffIndex, day, timeIndex] = 1;
                            }
                        }

                        i++;
                    }
                }
            }

            /*            foreach (int staffIndex in Helper.Range(Staffs.Count))
                        {
                            Console.WriteLine("Staff " + Staffs.ElementAt(staffIndex).Name);
                            foreach (int day in Helper.Range(TotalDay))
                            {
                                Console.WriteLine("Day " + day);
                                foreach (int t in Helper.Range(TotalTimeFrame))
                                {

                                    Console.Write(availableMatrix[staffIndex, day, t] + ", ");

                                }
                                Console.WriteLine();

                            }
                        }*/
            return availableMatrix;
        }

        public static int[,] ConvertSkillMatrix(List<Staff> Staffs, List<Skill> Skills)
        {
            int NumStaffs = Staffs.Count;
            int NumSkills = Skills.Count;
            int[,] skillMatrixs = new int[NumStaffs, NumSkills];
            foreach (int staff in Helper.Range(NumStaffs))
            {
                foreach (int skill in Helper.Range(NumSkills))
                {
                    if (Staffs.ElementAt(staff).Skills.Contains(Skills.ElementAt(skill)))
                    {
                        skillMatrixs[staff, skill] = 1;
                    }
                    /*                    else
                                        {
                                            skillMatrixs[staff, skill] = 0;
                                        }*/
                }
            }
            return skillMatrixs;
        }
        /*        public static void Copy()
        {
            *//* Buffer.BlockCopy(
             src, // src
             0, // srcOffset
             availableMaxtrix, // dst
             destRow * availableMaxtrix.GetLength(1) * availableMaxtrix.GetLength(2) * sizeof(int), // dstOffset
             src.Length * sizeof(int)); // count*/
        /*            foreach (int i in Range(10))
                    {
                        Console.WriteLine("Staff "+i);
                        foreach (int j in Range(7))
                        {
                            Console.WriteLine("Day " + j);
                            foreach (int k in Range(24))
                            {
                                Console.Write(availableMaxtrix[i, j, k] + ", ");
                            }
                            Console.WriteLine();
                        }
                    }*//*
}*/
    }
}
