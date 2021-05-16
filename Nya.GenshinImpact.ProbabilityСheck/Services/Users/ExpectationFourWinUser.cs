using Nya.GenshinImpact.ProbabilityСheck.Services.Models;
using System;

namespace Nya.GenshinImpact.ProbabilityСheck.Services
{
    public class ExpectationFourWinUser : BaseUser
    {
        private int count;

        public ExpectationFourWinUser(int availableAttempts, int? preset) 
            : base(availableAttempts, preset)
        { }

        public override void Play(Func<Win?> action)
        {
            while (availableAttempts-- > 0 && count > 0)
            {
                if (action() == Win.FourStars)
                    count--;

            }
        }
    }
}
