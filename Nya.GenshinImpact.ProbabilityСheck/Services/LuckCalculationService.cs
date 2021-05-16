using Nya.GenshinImpact.ProbabilityСheck.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace Nya.GenshinImpact.ProbabilityСheck.Services
{
    public class LuckCalculationService
    {
        private Dictionary<int, Win?> chances;
        private Dictionary<Win, int> guarants;
        private int totalNext;

        public (Win? win, int index) DiceRoll(BaseUser user, Random random)
        {
            var win = chances[random.Next(totalNext)];
            foreach (var key in guarants.Keys)
            {
                var value = ++user.LastWin[key];
                if (guarants[key] <= value && win != Win.FiveStart)
                    win = key;
            }

            var index = 0;
            if (win.HasValue)
            {
                index = user.LastWin[win.Value];
                user.LastWin[win.Value] = 0;
            }
            return (win, index);
        }

        public void SetOptions(Options options)
        {
            chances = InitChances(options.Chances);
            guarants = InitGuarants(options.Guarants);
        }

        private Dictionary<int, Win?> InitChances(IEnumerable<Chance> chances)
        {
            if (chances.Sum(x => x.Percent) > 100 || chances.GroupBy(x => x.Win).Any(x => x.Count() > 1))
                throw new Exception("Не коректно задана вероятность");

            var k = (int)Math.Pow(10, chances.Select(x => (x.Percent - Math.Truncate(x.Percent)).ToString().Length - 2)
                                             .Where(x => x > 0)
                                             .Max());
            totalNext = 100 * k;

            var dic = Enumerable.Range(0, totalNext)
                .ToDictionary(x => x, _ => default(Win?));
            var index = 0;
            foreach (var chance in chances)
                for (var i = 0; i < chance.Percent * k; i++)
                    dic[index++] = chance.Win;

            return dic;
        }

        private Dictionary<Win, int> InitGuarants(IEnumerable<Guarant> guarants)
            => guarants.ToDictionary(x => x.Win, x => x.Count);
    }
}
