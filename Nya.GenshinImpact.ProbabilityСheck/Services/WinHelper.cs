using Nya.GenshinImpact.ProbabilityСheck.Services.Models;
using System;
using System.Linq;

namespace Nya.GenshinImpact.ProbabilityСheck.Services
{
    public static class WinHelper
    {
        public static readonly Win[] WinTypes;

        static WinHelper()
        {
            WinTypes = Enum.GetValues(typeof(Win))
                .Cast<Win>()
                .ToArray();
        }
    }
}
