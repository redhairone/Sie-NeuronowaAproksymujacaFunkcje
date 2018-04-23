using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IADZadaniePierwsze
{
    public static class Chart
    {
        public static PlotView plot;
        public static PlotModel model;
        public static PlotView Chart1(string _tytul, double[,] data)
        {
            var plot = new PlotView
            {
                Dock = DockStyle.Fill,
                Size = new Size(500, 500)
            };
            
            var model = new PlotModel { Title = _tytul };
            var scatterSeries = new ScatterSeries() { MarkerType = MarkerType.Circle, MarkerSize = 0.01, MarkerFill = OxyColors.Aqua };

            for (var i = 0; i < Program.TestDane.Length / 2; i++)
            {
                var x = Program.TestDane[0, i];
                var y = Program.TestDane[1, i];
                scatterSeries.Points.Add(new ScatterPoint(x, y, 2));
            }

            var lineSeries = new LineSeries() {  };
            for (var i = 0; i < data.Length / 2; i++)
            {
                lineSeries.Points.Add(new DataPoint(data[0, i], data[1, i]));
            }
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Minimum = -5, Maximum = 5 });
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Minimum = -8, Maximum = 5 });
            model.Series.Add(scatterSeries);
            model.Series.Add(lineSeries);
            plot.Model = model;

            plot.InvalidatePlot(true);
            model.InvalidatePlot(true);

            return plot;
        }
    }
}
