namespace Nya.GenshinImpact.ProbabilityСheck.Services.Models
{
    public class BaseUserOptions
    {
        public int Count { get; set; }
        public int AttemptsMin { get; set; }
        public int AttemptsMax { get; set; }
        public int? PresetMin { get; set; }
        public int? PresetMax { get; set; }
    }
}
