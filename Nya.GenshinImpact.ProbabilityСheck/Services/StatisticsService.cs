using Nya.GenshinImpact.ProbabilityСheck.Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace Nya.GenshinImpact.ProbabilityСheck.Services
{
    public class StatisticsService
    {
        private readonly object _locker;
        public readonly Dictionary<Win, Dictionary<int, int>> _statistics;

        public StatisticsService()
        {
            _locker = new object();
            _statistics = WinHelper.WinTypes.ToDictionary(x => x, _ => new Dictionary<int, int>());
        }

        public void Reg(Win win, int index)
        {
            lock (_locker)
            {
                var dic = _statistics[win];
                if (dic.ContainsKey(index))
                    dic[index]++;
                else
                    dic.Add(index, 1);
            }
        }

        public void Reset()
        {
            foreach (var dic in _statistics.Values)
                dic.Clear();
        }

        public StatisticsData[] GetData()
            => _statistics.Select(x => new StatisticsData
            {
                WinType = x.Key,
                Points = x.Value
                    .OrderBy(v => v.Key)
                    .Select(v => new DataPoint(v.Key, v.Value))
                    .ToArray()
            })
            .ToArray();
    }
}
