using Nya.GenshinImpact.ProbabilityСheck.Services.Models;
using System;

namespace Nya.GenshinImpact.ProbabilityСheck.Services
{
    public class StopBeforeGuarantUser : BaseUser
    {
        private int stopBeforeGuarant { get; set; }

        public StopBeforeGuarantUser(int availableAttempts, int stopBeforeGuarant, int? preset)
            : base(availableAttempts, preset)
        {
            this.stopBeforeGuarant = stopBeforeGuarant;
        }

        public override void Play(Func<Win?> action)
        {
            while (availableAttempts-- > 0 && LastWin[Win.FiveStart] <= stopBeforeGuarant) 
                action();
        }
    }
}
