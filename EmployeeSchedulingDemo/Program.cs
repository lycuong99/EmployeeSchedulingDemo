using Google.OrTools.Sat;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeSchedulingDemo
{
    class Program
    {

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

        static void Main(string[] args)
        {
          STS.Solve();
            //SolveShiftScheduling();
            LinearExpr sum = new LinearExpr();

            var model = new CpModel();
            int n = 10;
            var arr = new IntVar[n];
            var arrTemp = new IntVar[n + 1];
            var arrTemp1 = new IntVar[n + 1];
            var a = model.NewIntVar(0, 20, "a");
            var b = model.NewIntVar(0, 20, "b");
            /*            foreach (int d in Range(n))
                        {
                            arr[d] = model.NewIntVar(0, 20,$"d{d}");
                        }

                        foreach (int d in Range(n))
                        {
                          var w = model.NewBoolVar( $"w");
                            model.Add(w == d%2);
                            model.Add(arr[d] == w);
                            sum += arr[d];
                        }*/
            sum += a;
            //sum += b;
            var con = model.NewConstant(10);
            LinearExpr sum1 = new LinearExpr();
            sum1 += con;
        //    model.Add(LinearExpr.Sum(sum));


            // Creates a solver and solves the model.
            CpSolver solver = new CpSolver();
            CpSolverStatus status = solver.Solve(model);
         //   Console.WriteLine("a = " + solver.Value(sum));

            VarArraySolutionPrinter cb = new VarArraySolutionPrinter(arr);
           // solver.SearchAllSolutions(model, cb);

            //    Console.WriteLine(String.Format("Number of solutions found: {0}", cb.SolutionCount()));
            //Console.WriteLine("status" + status);

            /*   if (status == CpSolverStatus.Optimal)
               {
                   Console.WriteLine("a = " + solver.ResponseStats());
                   Console.WriteLine("a = " + solver.Value(a));
                  Console.WriteLine("y = " + solver.Value(b));

               }*/

        }
        static void SolveShiftScheduling()
        {
            Console.WriteLine("Hello World!");

            int num_nurses = 4;
            int num_shifts = 3;
            int num_days = 3;

            var shifts_str = new[] { "A", "B", "C" };

            var all_nurses = Enumerable.Range(0, num_nurses).ToArray();
            var all_shifts = Enumerable.Range(0, num_shifts).ToArray();
            var all_days = Enumerable.Range(0, num_days).ToArray();
            Console.WriteLine(all_nurses);

            IntVar[,,] shifts = new IntVar[num_nurses, num_days, num_shifts];
            var model = new CpModel();
            foreach (int n in all_nurses)
            {
                foreach (int d in all_days)
                {
                    foreach (int s in all_shifts)
                    {
                        shifts[n, d, s] = model.NewBoolVar($"shift_n{n}_d{d}_s{s}");
                    }
                }
            }

            foreach (int d in all_days)
            {
                foreach (int s in all_shifts)
                {
                    var temp = new IntVar[num_nurses];
                    foreach (int n in all_nurses)
                    {
                        temp[n] = shifts[n, d, s];
                    }

                    model.Add(LinearExpr.Sum(temp) == 1);
                }
            }

            foreach (int n in all_nurses)
            {
                foreach (int d in all_days)
                {
                    var temp = new IntVar[num_shifts];
                    foreach (int s in all_shifts)
                    {
                        temp[s] = shifts[n, d, s];
                    }

                    model.Add(LinearExpr.Sum(temp) <= 1);
                }
            }

            // Try to distribute the shifts evenly, so that each nurse works
            // min_shifts_per_nurse shifts. If this is not possible, because the total
            // number of shifts is not divisible by the number of nurses, some nurses will
            // be assigned one more shift.
            var min_shifts_per_nurse = (num_shifts * num_days) / num_nurses;
            var max_shifts_per_nurse = 0;
            if ((num_shifts * num_days) % num_nurses == 0)
            {
                max_shifts_per_nurse = min_shifts_per_nurse;
            }
            else
            {
                max_shifts_per_nurse = min_shifts_per_nurse + 1;
                foreach (int n in all_nurses)
                {
                    /*var num_shifts_worked = 0;*/
                    var num_shifts_worked = new IntVar[num_days * num_shifts];
                    int num = 0;
                    foreach (int d in all_days)
                    {
                        foreach (int s in all_shifts)
                        {
                            num_shifts_worked[d * num_days + s] = shifts[n, d, s];
                            // num += shifts[n, d, s];
                        }
                    }
                    model.Add(LinearExpr.Sum(num_shifts_worked) >= min_shifts_per_nurse);
                    model.Add(LinearExpr.Sum(num_shifts_worked) <= max_shifts_per_nurse);
                }
            }


            var a_few_solutions = Enumerable.Range(0, 5);
            CpSolver solver = new CpSolver();

            CpSolverStatus status = solver.Solve(model);
            Console.WriteLine(status);

            NursesPartialSolutionPrinter cb = new NursesPartialSolutionPrinter(shifts, num_nurses,
                                                    num_days, num_shifts,
                                                    a_few_solutions);
            solver.SearchAllSolutions(model, cb);

            Console.WriteLine(String.Format("Number of solutions found: {0}", cb.SolutionCount()));


            /*           solver.StringParameters = "num_search_workers:4, log_search_progress: true, max_time_in_seconds:30";

                       var status = solver.Solve(model);

                       if (status == CpSolverStatus.Optimal || status == CpSolverStatus.Feasible)
                       {
                           Console.WriteLine();
                           var header = "          ";
                           Console.WriteLine(header);

                           foreach (int n in all_nurses)
                           {
                               var schedule = "";
                               foreach (int d in all_days)
                               {

                                   foreach (int s in all_shifts)
                                   {
                                       if (solver.BooleanValue(shifts[n, d, s]))
                                       {
                                           schedule += shifts_str[s] + " ";
                                       }
                                   }


                               }
                               Console.WriteLine($"worker {n}: {schedule}");
                               Console.WriteLine();
                           }
                       }*/

        }
    }
    public class VarArraySolutionPrinter : CpSolverSolutionCallback
    {
        public VarArraySolutionPrinter(IntVar[] variables)
        {
            variables_ = variables;
          
        }

        public override void OnSolutionCallback()
        {
            {
                Console.WriteLine(String.Format("Solution #{0}: time = {1:F2} s", solution_count_, WallTime()));
              
                foreach (IntVar v in variables_)
                {
                    Console.WriteLine(String.Format("  {0} = {1}", v.ShortString(), Value(v)));
                }
                solution_count_++;
            }
        }

        public int SolutionCount()
        {
            return solution_count_;
        }

        private int solution_count_;
        private IntVar[] variables_;
        private IntVar count_;
    }


    class NursesPartialSolutionPrinter : CpSolverSolutionCallback
    {

        private IntVar[,,] shifts_;
        private IEnumerable<int> _sols;
        private int num_days_;
        private int num_nurses_;
        private int num_shifts;


        public NursesPartialSolutionPrinter(IntVar[,,] shifts, int num_nurses, int num_days, int num_shifts, IEnumerable<int> sols)
        {
            this.shifts_ = shifts;
            this.num_nurses_ = num_nurses;
            this.num_days_ = num_days;
            this.num_shifts = num_shifts;
            this._sols = sols;

        }

        public override void OnSolutionCallback()
        {

            if (_sols.Contains(solution_count_))
            {
                Console.WriteLine($"Solution {solution_count_}");

                foreach (int d in Enumerable.Range(0, num_days_).ToArray())
                {
                    Console.WriteLine($"Day {d}");
                    foreach (int n in Enumerable.Range(0, num_nurses_).ToArray())
                    {
                        bool is_working = false;
                        foreach (int s in Enumerable.Range(0, num_shifts).ToArray())
                        {
                            if (Value(shifts_[n, d, s]) == 1)
                            {
                                is_working = true;
                                Console.WriteLine($"Nurse {n} works shift {s}");

                            }

                            /*foreach (IntVar v in shifts_)
                            {
                              
                              *//*  Console.WriteLine(String.Format("  {0} = {1}", v.ShortString(), Value(v)));*//*
                            }*/

                        }
                        if (!is_working)
                        {
                            Console.WriteLine($"Nurse {n} does not work");
                        }

                    }
                    Console.WriteLine();
                }
                solution_count_++;
            }

        }



        private int solution_count_;
        public int SolutionCount()
        {
            return solution_count_;
        }


    }

}



