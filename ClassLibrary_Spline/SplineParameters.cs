using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_Spline
{
    public class SplineParameters
    {
        public int count_points
        { 
            get; 
            set;
        }
        
        public double a 
        { 
            get; 
            set; 
        }
        public double b 
        { 
            get; 
            set; 
        }

        public double[] Derivative1 
        { 
            get; 
            set; 
        }
       
        public double[] Derivative2 
        { 
            get; 
            set; 
        }
        public double[] nodes
        {
            get;
        }
        public SplineParameters()
        {   
            nodes = null;
            count_points = 100;
            Derivative1 = new double[2];
            Derivative2 = new double[2];

        }
        public SplineParameters(double left,double right,int count,double Der1left,double Der1right, double Der2left, double Der2right)
        {
            if(count<=2)
            {
                Console.WriteLine("count > 2");
                return;
            }
            a = left;
            b = right;
            Derivative1 = new double[2];
            Derivative2 = new double[2];
            count_points = count;
            Derivative1[0] = Der1left;
            Derivative1[1] = Der1right;

            Derivative2[0] = Der2left;
            Derivative2[1] = Der2right;
            nodes = new double[count];
            nodes[0] = a;
            nodes[count - 1] = b;
            double len = b - a;
            double h_x = len / (count - 1);
            for (int i = 0; i < count-1; i++)
            {
                this.nodes[i] = a + i * h_x;
            }
        }
    }
}
