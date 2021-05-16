using Nya.GenshinImpact.ProbabilityСheck.Services.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace Nya.GenshinImpact.ProbabilityСheck.ViewModels
{
    public class LineModel
    {
        public Brush Color { get; private set; }
        public PointCollection Points { get; private set; }

        public static LineModel Create(IEnumerable<DataPoint> points, Brush color)
            => new()
            {
                Color = color,
                Points = new PointCollection(points.Select(x => new Point(x.Value * 12, 800 - x.Count)))
            };
    }
}
