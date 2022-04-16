using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Legends;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary_Spline;
using OxyPlot.Axes;
namespace WpfApp_Spline
{
    public class OxyPlotData
    {
        public SplinesData data = null;
        public PlotModel plotModel 
        { 
            get; 
            private set; 
        }
        public OxyPlotData(SplinesData data)
        {
            this.data = data;
            this.plotModel = new PlotModel();
            if(data.Me_Data.sPf==SPf.Cubic)
            {
                plotModel.Title = "Cubic curve's nodes y=4x^3+2x^2+1";
            }
            else if (data.Me_Data.sPf == SPf.Function)
            {
                plotModel.Title = "Defined function's nodes y=0.05x+2";
            }
            else if (data.Me_Data.sPf == SPf.Random)
            {
                plotModel.Title = "Randomly generated nodes";
            }
                AddMeasured();
                
            if (data.Sp_Parameters.nodes != null)
            {
                AddSpline();
            }
        }
        public void AddMeasured()
        {
            this.plotModel.Series.Clear();
            OxyColor color = OxyColors.Blue;
            LineSeries lineSeries = new LineSeries();
            for (int j = 0; j < data.Me_Data.count_points; j++)
            {
                lineSeries.Points.Add(new DataPoint(data.Me_Data.uneven_grid[j], data.Me_Data.measured_values[j]));
            }
            lineSeries.Color = color;
            lineSeries.MarkerType = MarkerType.Circle;
            lineSeries.MarkerSize = 3;
            lineSeries.MarkerStroke = color;
            lineSeries.MarkerFill = color;
            lineSeries.LineStyle = LineStyle.None;
            lineSeries.Title = "Measured";
            Legend legend = new Legend();
            plotModel.Legends.Add(legend);
            this.plotModel.Series.Add(lineSeries);
            AddAxes(plotModel);
        }
        public void AddSpline()
        {
            OxyColor color1 = OxyColors.DarkOrange;
            LineSeries lineSeries1 = new LineSeries();
            for (int j = 0; j < data.Sp_Parameters.count_points; j++)
            {
                lineSeries1.Points.Add(new DataPoint(data.Sp_Parameters.nodes[j], data.Values1[j]));
            }
            lineSeries1.Color = color1;
            lineSeries1.MarkerType = MarkerType.Circle;
            lineSeries1.MarkerSize = 0;
            lineSeries1.MarkerStroke = color1;
            lineSeries1.MarkerFill = color1;
            lineSeries1.LineStyle = LineStyle.Solid;
            lineSeries1.Title = "Spline1";
            OxyColor color2 = OxyColors.Turquoise;
            LineSeries lineSeries2 = new LineSeries();
            for (int j = 0; j < data.Sp_Parameters.count_points; j++)
            {
                lineSeries2.Points.Add(new DataPoint(data.Sp_Parameters.nodes[j], data.Values2[j]));
            }
            lineSeries2.Color = color2;
            lineSeries2.MarkerType = MarkerType.Circle;
            lineSeries2.MarkerSize = 0;
            lineSeries2.MarkerStroke = color2;
            lineSeries2.MarkerFill = color2;
            lineSeries2.LineStyle = LineStyle.Solid;
            lineSeries2.Title = "Spline2";
            OxyColor color3 = OxyColors.DeepPink;
            LineSeries lineSeries3 = new LineSeries();
            for (int j = 0; j < data.Sp_Parameters.count_points; j++)
            {
                lineSeries3.Points.Add(new DataPoint(data.Sp_Parameters.nodes[j], data.Values3[j]));
            }
            lineSeries3.Color = color3;
            lineSeries3.MarkerType = MarkerType.Circle;
            lineSeries3.MarkerSize = 0;
            lineSeries3.MarkerStroke = color2;
            lineSeries3.MarkerFill = color2;
            lineSeries3.LineStyle = LineStyle.Solid;
            lineSeries3.Title = "Spline3-Free end";
            plotModel.Series.Add(lineSeries1);
            plotModel.Series.Add(lineSeries2);
            plotModel.Series.Add(lineSeries3);
        }
        private static void AddAxes(PlotModel plotModel)
        {
            plotModel.Axes.Add(new LinearAxis
            {
                Title = "X-axis",
                TitleFontSize = 14,
                TitleFontWeight = FontWeights.Bold,
                AxisTitleDistance = 15,
                Position = AxisPosition.Bottom,
            });
            plotModel.Axes.Add(new LinearAxis
            {
                Title = "Y-axis",
                TitleFontSize = 14,
                TitleFontWeight = FontWeights.Bold,
                AxisTitleDistance = 15,
                Position = AxisPosition.Left
            });
        }
    }
}
