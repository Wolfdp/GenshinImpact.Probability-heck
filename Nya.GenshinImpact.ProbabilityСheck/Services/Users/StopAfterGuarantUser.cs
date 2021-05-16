using Nya.GenshinImpact.ProbabilityСheck.Services.Models;
using System;

namespace Nya.GenshinImpact.ProbabilityСheck.Services
{
    public class StopAfterGuarantUser : BaseUser
    {
        public StopAfterGuarantUser(int availableAttempts, int? preset)
            : base(availableAttempts, preset)
        { }

        public override void Play(Func<Win?> action)
        {
            while (availableAttempts-- > 0 && action() != Win.FiveStart) ;
        }
    }
}
