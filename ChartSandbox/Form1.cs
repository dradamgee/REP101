using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraCharts;

namespace ChartSandbox {
    public static class WodeColorMapper {
        public static Color ToColor(this Side side) {
            switch (side)
            {
                    case Side.Buy:
                        return Color.Green;
                    case Side.Sell:
                        return Color.Red;
                    case Side.Pay:
                        return Color.Yellow;
                    case Side.Receive:
                        return Color.RoyalBlue;
                    default:
                        return Color.Black;
            }
        }
    }

    public partial class Form1 : Form {

        public Order[] Orders
        {
            get
            {
                return new Order[]
                {
                    new Order(1, 2, 3, Side.Buy),
                    new Order(12, 23, 32, Side.Buy),
                    new Order(33, 42,22, Side.Sell),

                    new Order(7, 2,22, Side.Pay),
                    new Order(7, 2,32, Side.Receive),
                };
            }
        }

        Series series = new Series("Parent Orders", ViewType.Bubble);
        public Form1() {
            InitializeComponent();

            var bubbleChart = new ChartControl();

           
            
            foreach (var order in Orders) {
                var p = new SeriesPoint(order.ExecutedPercent, order.TradedConsideration, order.Quantity) { Color = order.Side.ToColor() };
                p.NumericalArgument = (double)order.ExecutedPercent;
                p.Values = new[] { (double)order.TradedConsideration, (double)order.Quantity };
                series.Points.Add(new SeriesPoint(order.ExecutedPercent, order.TradedConsideration, order.Quantity){Color = order.Side.ToColor()});
            }

            // Add both series to the chart.
            bubbleChart.Series.Add(series);
            bubbleChart.Click += bubbleChart_Click;
            series.ArgumentScaleType = ScaleType.Numerical;

            
            ((BubbleSeriesView)series.View).MaxSize = 20;
            ((BubbleSeriesView)series.View).MinSize = 1;
            ((BubbleSeriesView)series.View).BubbleMarkerOptions.Kind = MarkerKind.Circle;



            //((XYDiagram)bubbleChart.Diagram).DefaultPane.

            // Access the type-specific options of the diagram.
            ((XYDiagram)bubbleChart.Diagram).EnableAxisXZooming = true;
            ((XYDiagram)bubbleChart.Diagram).EnableAxisYZooming = true;

            // Hide the legend (if necessary).
            bubbleChart.Legend.Visible = false;

            // Add the chart to the form.
            bubbleChart.Dock = DockStyle.Fill;

            Controls.Add(bubbleChart);



            

        }

        int s = 10;

        void bubbleChart_Click(object sender, EventArgs e) {
            int x = 1;
            foreach(var p in series.Points) {
                ((SeriesPoint)p).Values = new double[] { 100, s *x};
                x++;
            }
            --s;
            
        }
    }
}
