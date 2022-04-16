using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary_Spline;

namespace WPF
{
    class ViewData : IDataErrorInfo, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void PropertiesChanged()
        {
            PropertyChanged(this, new PropertyChangedEventArgs("Measured_n"));
            PropertyChanged(this, new PropertyChangedEventArgs("Measured_a"));
            PropertyChanged(this, new PropertyChangedEventArgs("Measured_b"));
            PropertyChanged(this, new PropertyChangedEventArgs("Spline_N"));
            PropertyChanged(this, new PropertyChangedEventArgs("D1_0"));
            PropertyChanged(this, new PropertyChangedEventArgs("D1_1")); 
            PropertyChanged(this, new PropertyChangedEventArgs("D2_0"));
            PropertyChanged(this, new PropertyChangedEventArgs("D2_1"));

        }
        public SplineParameters Spline_Parameters
        { 
            get; 
            set; 
        }
        public SplinesData Splines_Data
        { 
            get; 
            set; 
        }
        public ObservableCollection<string> Measured_Items 
        { 
            get; 
            set; 
        }
        public double[] Deriv { get; set; } = new double[6];
        public ObservableCollection<string> Spline_Derivative
        { 
            get; 
            set; 
        }
        public MeasuredData Measured { get; set; }
        public double[] Measured_n_a_b 
        { 
            get; 
            set; 
        } 
        public double Measured_n
        {
            get
            {
              return  Measured_n_a_b[0];
            }
            set
            {
                Measured_n_a_b[0] = value;
            }
        }
        public double Measured_a
        {
            get
            {
               return Measured_n_a_b[1];
            }
            set
            {
                Measured_n_a_b[1] = value;
                PropertiesChanged();
            }
        }
        public double Measured_b
        {
            get 
            { 
                return Measured_n_a_b[2]; 
            }
            set
            {
                Measured_n_a_b[2] = value;
                PropertiesChanged();
            }
        }
        public int Spline_N
        {
            get
            {
               return  Spline_Parameters.count_points;
            }
            set
            {
                Spline_Parameters.count_points = value;
            }
        }
     
        public double D1_0
        {
            get
            {
                return Spline_Parameters.Derivative1[0];
            }
            set
            {
                Spline_Parameters.Derivative1[0] = value;
                PropertiesChanged();
            }
        }

        public double D1_1
        {
            get
            {
                return Spline_Parameters.Derivative1[1];
            }
            set
            {
                Spline_Parameters.Derivative1[1] = value;
                PropertiesChanged();
            }
        }
        public double D2_0
        {
            get
            {
                return Spline_Parameters.Derivative2[0];
            }
            set
            {
                Spline_Parameters.Derivative2[0] = value;
                PropertiesChanged();
            }
        }
        public double D2_1
        {
            get
            {
                return Spline_Parameters.Derivative2[1];
            }
            set
            {
                Spline_Parameters.Derivative2[1] = value;
                PropertiesChanged();
            }
        }

        public SPf F_Fun 
        { 
            get; 
            set; 
        }
        
        public double Test 
        { 
            get; 
            set; 
        }

        public ViewData()
        {
            Measured_Items = new ObservableCollection<string>();
            Spline_Parameters = new SplineParameters();
            Spline_Derivative = new ObservableCollection<string>();
            Measured_n_a_b = new double[3] { 10, 0, 1 };
            Spline_Parameters.Derivative1 = new double[2] { -3 , 3};
            Spline_Parameters.Derivative2 = new double[2] {  3 , -3};

        }
        public string this[string property]
        {
            get
            {
                string str = null;
                if (property == "Measured_a")
                {
                    if (Measured_a >= Measured_b)
                    {
                        str = "a<b";
                    }
                }
                else if (property == "Measured_b")
                {
                    if (Measured_b <= Measured_a)
                    {
                        str = "b>a";
                    }
                }
                else if (property == "Measured_n")
                {
                    if (Measured_n <= 2)
                    {
                        str = "n>2";
                    }
                }
                else if(property == "Spline_N")
                {
                    if (Spline_N<=2)
                    {
                        str = "Spline_N>2";
                    }
                }
                else if (property == "D1_0")
                {
                    
                }
                else if (property == "D1_1")
                {
                   
                }
                else if (property == "D2_0")
                {

                }
                else if (property == "D2_1")
                {

                }
                return str;


            }
        }
        public string Error
        {
            get
            {
                string str = "Error occurred";
                return str;
            }
        }

    }

}
