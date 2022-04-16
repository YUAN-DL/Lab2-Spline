using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClassLibrary_Spline;
using WPF;

namespace WpfApp_Spline
{    
    public partial class MainWindow : Window
    {
        public static RoutedCommand MakeMeasured = new RoutedCommand("Measured", typeof(WpfApp_Spline.MainWindow));
        public static RoutedCommand MakeSpline = new RoutedCommand("Measured", typeof(WpfApp_Spline.MainWindow));
        ViewData Item = new ViewData();
        OxyPlotData OxyPlot;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = Item;
            MeasureData_Input.DataContext = Item;
        }
        private void Button_Make_Measured(object sender, RoutedEventArgs e)
        {
            try
            {
                Item.Measured = new MeasuredData((int)Item.Measured_n_a_b[0], Item.Measured_n_a_b[1], Item.Measured_n_a_b[2], Item.F_Fun);
                Item.Measured_Items.Clear();
                for (int i = 0; i < Item.Measured.count_points; i++)
                {
                    Item.Measured_Items.Add($"x[{i}]: {Item.Measured.uneven_grid [i].ToString("F3")}   y[{i}]: {Item.Measured.measured_values[i].ToString("F3")}");
                }
                Item.Splines_Data = new SplinesData(Item.Measured, new SplineParameters());
                OxyPlot = new OxyPlotData(Item.Splines_Data);
                Oxy.DataContext = OxyPlot;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Button_Make_Spline(object sender, RoutedEventArgs e)
        {
            try
            {

                Item.Splines_Data.Sp_Parameters = new SplineParameters(Item.Splines_Data.Me_Data.a, Item.Splines_Data.Me_Data.b, Item.Spline_Parameters.count_points, Item.Spline_Parameters.Derivative1[0], Item.Spline_Parameters.Derivative1[1], Item.Spline_Parameters.Derivative2[0], Item.Spline_Parameters.Derivative2[1]);
                Item.Splines_Data.MKL();
                Item.Spline_Derivative.Clear();
                Item.Spline_Derivative.Add($"Заданные значения:");
                Item.Spline_Derivative.Add($"Первая производная левых концов");
                Item.Spline_Derivative.Add($"Сплайн 1= {Item.D1_0}");
                Item.Spline_Derivative.Add($"Сплайн 2= {Item.D2_0}");
                Item.Spline_Derivative.Add($"Первая производная правых концов");
                Item.Spline_Derivative.Add($"Сплайн 1= {Item.D1_1}");
                Item.Spline_Derivative.Add($"Сплайн 2= {Item.D2_1}");
                Item.Spline_Derivative.Add($"Вычисленные значения Сплайн 1:");
                Item.Spline_Derivative.Add($"Значание в узле a= {Item.Splines_Data.deriv1[0].ToString("F3")}");
                Item.Spline_Derivative.Add($"Первая производная в узле a= {Item.Splines_Data.deriv1[1].ToString("F3")}");
                Item.Spline_Derivative.Add($"Значание в узле a+h= {Item.Splines_Data.deriv_1ab_h[0].ToString("F3")}");
                Item.Spline_Derivative.Add($"Первая производная в узле a+h= {Item.Splines_Data.deriv_1ab_h[1].ToString("F3")}");
                Item.Spline_Derivative.Add($"Значание в узле b-h= {Item.Splines_Data.deriv_1ab_h[3].ToString("F3")}");
                Item.Spline_Derivative.Add($"Первая производная в узле b-h= {Item.Splines_Data.deriv_1ab_h[4].ToString("F3")}");
                Item.Spline_Derivative.Add($"Значание в узле b= {Item.Splines_Data.deriv1[3].ToString("F3")}");
                Item.Spline_Derivative.Add($"Первая производная в узле b= {Item.Splines_Data.deriv1[4].ToString("F3")}");
                Item.Spline_Derivative.Add($"Вычисленные значения Сплайн 2:");
                Item.Spline_Derivative.Add($"Значание в узле a= {Item.Splines_Data.deriv2[0].ToString("F3")}");
                Item.Spline_Derivative.Add($"Первая производная в узле a= {Item.Splines_Data.deriv2[1].ToString("F3")}");
                Item.Spline_Derivative.Add($"Значание в узле a+h= {Item.Splines_Data.deriv_2ab_h[0].ToString("F3")}");
                Item.Spline_Derivative.Add($"Первая производная в узле a+h= {Item.Splines_Data.deriv_2ab_h[1].ToString("F3")}");
                Item.Spline_Derivative.Add($"Значание в узле b-h= {Item.Splines_Data.deriv_2ab_h[3].ToString("F3")}");
                Item.Spline_Derivative.Add($"Первая производная в узле b-h= {Item.Splines_Data.deriv_2ab_h[4].ToString("F3")}");
                Item.Spline_Derivative.Add($"Значание в узле b= {Item.Splines_Data.deriv2[3].ToString("F3")}");
                Item.Spline_Derivative.Add($"Первая производная в узле b= {Item.Splines_Data.deriv2[4].ToString("F3")}");
                Item.Spline_Derivative.Add($"Вычисленные значения Сплайн без граничных условий:");
                Item.Spline_Derivative.Add($"Значание в узле a= {Item.Splines_Data.deriv3[0].ToString("F3")}");
                Item.Spline_Derivative.Add($"Первая производная в узле a= {Item.Splines_Data.deriv3[1].ToString("F3")}");
                Item.Spline_Derivative.Add($"Значание в узле a+h= {Item.Splines_Data.deriv_2ab_h[0].ToString("F3")}");
                Item.Spline_Derivative.Add($"Первая производная в узле a+h= {Item.Splines_Data.deriv_3ab_h[1].ToString("F3")}");
                Item.Spline_Derivative.Add($"Значание в узле b-h= {Item.Splines_Data.deriv_2ab_h[3].ToString("F3")}");
                Item.Spline_Derivative.Add($"Первая производная в узле b-h= {Item.Splines_Data.deriv_3ab_h[4].ToString("F3")}");
                Item.Spline_Derivative.Add($"Значание в узле b= {Item.Splines_Data.deriv3[3].ToString("F3")}");
                Item.Spline_Derivative.Add($"Первая производная в узле b= {Item.Splines_Data.deriv3[4].ToString("F3")}");
                OxyPlot = new OxyPlotData(Item.Splines_Data);
                Oxy.DataContext = OxyPlot;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CanMakeMeasured(object sender, CanExecuteRoutedEventArgs e)
        {
            if (Validation.GetHasError(TextBox_Measured_n) || Validation.GetHasError(TextBox_Measured_a) || Validation.GetHasError(TextBox_Measured_b))
            {
                e.CanExecute = false;
                return;
            }
            e.CanExecute = true;
        }
        private void CanMakeSpline(object sender, CanExecuteRoutedEventArgs e)
        {
            if (Validation.GetHasError(N_Splines) || Validation.GetHasError(D1_left) || Validation.GetHasError(D1_right) || Validation.GetHasError(D2_left) ||  Validation.GetHasError(D2_right))
            {
                e.CanExecute = false;
                return;
            }
            if (Item.Measured_Items.Count == 0)
            {
                e.CanExecute = false;
                return;
            }

            e.CanExecute = true;
        }
        private void DoMakeMeasured(object sender, ExecutedRoutedEventArgs e)
        {
            Button_Make_Measured(sender, e);
        }
        private void DoMakeSpline(object sender, ExecutedRoutedEventArgs e)
        {
            Button_Make_Spline(sender, e);
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
