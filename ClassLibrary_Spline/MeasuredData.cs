using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ClassLibrary_Spline
{
    public class MeasuredData
    {
        public int count_points  // number of nodes
        { 
            get; 
            set; 
        }
        public double a  //leftpoint
        { 
            get;
            set; 
        } 
        
        public double b //right point
        { 
            get; 
            set; 
        } 
        
        public SPf sPf;
        public double[] uneven_grid  // arrary for x
        {
            get;
        }
        public double[] measured_values // arrary for y
        {
            get;
            set;
        }
        public MeasuredData(int count, double left, double right, SPf arg_sPf)
        {

            if (count <= 2)
            {
                Console.WriteLine("count must be >2");
                return;
            }
            Random rd = new Random();
            a = left;
            b = right;
            double len = b - a;
            count_points = count;
            sPf =arg_sPf;
            uneven_grid = new double[count];  // x
            measured_values = new double[count]; // y
            uneven_grid[0] = a;
            uneven_grid[count - 1] = b;
            for (int i = 1; i < count - 1; i++)
            {
                uneven_grid[i] = len * rd.NextDouble() + uneven_grid[0];
            }
            Array.Sort(uneven_grid);


            if (arg_sPf == SPf.Cubic) 
            {
 
                for (int i = 0; i < count; i++)
                {
                    measured_values[i] = 4*uneven_grid[i] * uneven_grid[i] * uneven_grid[i] + 2 * uneven_grid[i] * uneven_grid[i] +1;
                }
            }
            else if (arg_sPf == SPf.Function)
            {
                for (int i = 0; i < count; i++)
                {
                    measured_values[i] = 0.05*uneven_grid[i] + 2;    
                }
            }
            else if (arg_sPf == SPf.Random)
            {
                for (int i = 0; i < count; i++)
                {
                    Random rd2 = new Random();
                    measured_values[i] =rd2.NextDouble() * 8;
                }

      
            }
        }
        public override string ToString()
        {
            string str="";
            str += "a= " + a + " \n";
            str += "b= " + b + " \n";
            str += "number of nodes= " + count_points+" \n";
            str += "SPf= " + sPf + " \n";
            return str;
        }
    }
}
