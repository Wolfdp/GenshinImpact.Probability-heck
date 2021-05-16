using Nya.GenshinImpact.ProbabilityСheck.Services.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Media;

namespace Nya.GenshinImpact.ProbabilityСheck.ViewModels
{
    public class CanvasModel : INotifyPropertyChanged
    {
        private static readonly Dictionary<int, Brush> colors = new()
        {
            { 0, Brushes.Red },
            { 1, Brushes.Blue },
            { 2, Brushes.Orange },
            { 3, Brushes.Green },
            { 4, Brushes.Yellow },
            { 5, Brushes.Aqua },
            { 6, Brushes.Magenta },
            { 7, Brushes.Indigo },
            { 8, Brushes.Peru },
            { 9, Brushes.Teal },
        };
        private IEnumerable<LineModel> lines;

        public IEnumerable<LineModel> Lines
        {
            get => lines; 
            set
            {
                lines = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Lines)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public static CanvasModel CreateForFiveWin(IEnumerable<StatisticsData> data)
            => new() { Lines = GetLines(data) };

        public static IEnumerable<LineModel> GetLines(IEnumerable<StatisticsData> data)
            => data.Where(x => x.WinType == Win.FiveStart)
                   .Select((x, i) => LineModel.Create(x.Points, colors[i % colors.Count]))
                   .ToArray();


    }
}
