using Nya.GenshinImpact.ProbabilityСheck.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nya.GenshinImpact.ProbabilityСheck.Services
{
    public abstract class BaseUser
    {
        public Dictionary<Win, int> LastWin { get; }

        protected int availableAttempts;

        public BaseUser(int availableAttempts, int? preset)
        {
            this.availableAttempts = availableAttempts;
            LastWin = WinHelper.WinTypes.ToDictionary(x => x, _ => 0);
            if(preset.HasValue)
                LastWin[Win.FiveStart] = preset.Value;
        }

        public abstract void Play(Func<Win?> action);
    }
}
