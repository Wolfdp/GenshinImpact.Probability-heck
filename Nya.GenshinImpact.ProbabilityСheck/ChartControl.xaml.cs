using Nya.GenshinImpact.ProbabilityСheck.ViewModels;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Nya.GenshinImpact.ProbabilityСheck
{
    /// <summary>
    /// Interaction logic for ChartControl.xaml
    /// </summary>
    public partial class ChartControl : UserControl
    {
        private CanvasModel Model;

        public ChartControl()
        {
            InitializeComponent();

            this.DataContextChanged += ChartControl_DataContextChanged;
        }

        private void ChartControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Model != null)
                Model.PropertyChanged -= SetLines;
            Model = e.NewValue as CanvasModel;
            if (Model != null)
                Model.PropertyChanged += SetLines;
        }

        private void SetLines(object sender, PropertyChangedEventArgs e)
        {
            ClearChart();
            foreach (var line in Model.Lines)
                canvas.Children.Add(new Polyline{ Points = line.Points, Stroke = line.Color });
        }

        public void ClearChart()
            => canvas.Children.Clear();
    }
}
