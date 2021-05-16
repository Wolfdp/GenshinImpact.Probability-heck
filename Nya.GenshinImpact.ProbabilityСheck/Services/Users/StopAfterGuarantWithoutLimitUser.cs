using Nya.GenshinImpact.ProbabilityСheck.Services.Models;
using System;

namespace Nya.GenshinImpact.ProbabilityСheck.Services
{
    public class StopAfterGuarantWithoutLimitUser : BaseUser
    {
        public StopAfterGuarantWithoutLimitUser(int? preset)
            : base(0, preset)
        { }

        public override void Play(Func<Win?> action)
        {
            while (action() != Win.FiveStart) ;
        }
    }
}
