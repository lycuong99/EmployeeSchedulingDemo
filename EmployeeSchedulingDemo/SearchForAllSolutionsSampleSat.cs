using Google.OrTools.Sat;
using System;

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
}

public class SearchForAllSolutionsSampleSat
{
    /*    static void Main()
        {
            // Creates the model.
            CpModel model = new CpModel();

            // Creates the variables.
            int num_vals = 3;

            IntVar x = model.NewIntVar(0, num_vals - 1, "x");
            IntVar y = model.NewIntVar(0, num_vals - 1, "y");
            IntVar z = model.NewIntVar(0, num_vals - 1, "z");

            // Adds a different constraint.
            model.Add(x != y);

            // Creates a solver and solves the model.
            CpSolver solver = new CpSolver();
            VarArraySolutionPrinter cb = new VarArraySolutionPrinter(new IntVar[] { x, y, z });
            solver.SearchAllSolutions(model, cb);

            Console.WriteLine(String.Format("Number of solutions found: {0}", cb.SolutionCount()));
        }*/
}