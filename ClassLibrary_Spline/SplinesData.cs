using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
namespace ClassLibrary_Spline
{
    public enum SPf
    {
        Function,
        Cubic,
        Random,
    };


    public class SplinesData
    {
        public MeasuredData Me_Data;
        public SplineParameters Sp_Parameters;
        public SplinesData(MeasuredData md, SplineParameters sp)
        {
            Me_Data = md;
            Sp_Parameters = sp;
        }
       
        public double[] deriv1 
        { 
            get; 
            set; 
        }
        public double[] deriv2 
        { 
            get; 
            set; 
        }
        public double[] deriv3 
        { 
            get; 
            set; 
        }
        public double[] deriv_1ab_h 
        { 
            get; 
            set; 
        }
        public double[] deriv_2ab_h 
        { 
            get; 
            set; 
        }
        public double[] deriv_3ab_h 
        { 
            get; 
            set; 
        }
        public double[] Values1 
        { 
            get; 
            set; 
        }
        public double[] Values2 
        { 
            get; 
            set; 
        }
        public double[] Values3 
        { 
            get;
            set; 
        }
        public double[] spline_Values 
        { 
            get;
            set; 
        }
        public void MKL()
        {

            try
            {
                double[] result1 = new double[Sp_Parameters.count_points];
                double[] result2 = new double[Sp_Parameters.count_points];
                double[] result3 = new double[Sp_Parameters.count_points];

                double[] coeff = new double[(Me_Data.count_points - 1) * 4];
                deriv1 = new double[6];
                deriv2 = new double[6];
                deriv3 = new double[6];
                deriv_1ab_h = new double[6];
                deriv_2ab_h = new double[6];
                deriv_3ab_h = new double[6];
                int error = 0;
                Calculate_MKL(Me_Data.count_points, Me_Data.uneven_grid, Me_Data.measured_values , Sp_Parameters.count_points, result1, result2, result3, Sp_Parameters.Derivative1, Sp_Parameters.Derivative2, deriv1, deriv2, deriv3, deriv_1ab_h, deriv_2ab_h, deriv_3ab_h, ref error, coeff);
                Values1 = result1;
                Values2 = result2;
                Values3 = result3;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [DllImport("..\\..\\..\\..\\x64\\DEBUG\\Dll_Spline.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern
        bool Calculate_MKL(int count_nodes, double[] x, double[] y, int N, double[] values1, double[] values2, double[] values3, double[] Derivative1, double[] Derivative2, double [] deriv1, double[] deriv2, double[] deriv3, double[] deriv_1ab_h, double[] deriv_2ab_h, double[] deriv_3ab_h, ref int error, double[] coeff);

    }
}
