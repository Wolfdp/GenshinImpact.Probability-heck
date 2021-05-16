namespace Nya.GenshinImpact.ProbabilityСheck.Services.Models
{
    public class Options
    {
        public int Repeat { get; set; }
        public BaseUserOptions UserOptions { get; set; }
        public BaseUserOptions StopAfterGuarantUserOptions { get; set; }
        public BaseUserOptions StopAfterGuarantWithLargePresetUserOptions { get; set; }
        public BaseUserOptions StopAfterGuarantWithoutLimitUserOptions { get; set; }
        public StopBeforeGuarantUserOptions StopBeforeGuarantUserOptions { get; set; }
        public ExpectationFourWinUserOptions ExpectationFourWinUserOptions { get; set; }
        public Chance[] Chances { get; set; }
        public Guarant[] Guarants { get; set; }
    }
}
