using Nya.GenshinImpact.ProbabilityСheck.Services.Models;

namespace Nya.GenshinImpact.ProbabilityСheck.ViewModels
{
    public class OptionsModel
    {
        public int Repeat { get; set; }
        public decimal ChanceFiveWinPercente { get; set; }
        public decimal ChanceFourWinPercente { get; set; }
        public int GuarantFiveWin { get; set; }
        public int GuarantFourWin { get; set; }
        #region user options
        public int UserOptionsAttemptsMax { get; set; }
        public int UserOptionsAttemptsMin { get; set; }
        public int UserOptionsCount { get; set; }
        public int? UserOptionsPresetMax { get; set; }
        public int? UserOptionsPresetMin { get; set; }
        #endregion
        #region stop after guarant options
        public int StopAfterGuarantUserOptionsAttemptsMax { get; set; }
        public int StopAfterGuarantUserOptionsAttemptsMin { get; set; }
        public int StopAfterGuarantUserOptionsCount { get; set; }
        public int? StopAfterGuarantUserOptionsPresetMax { get; set; }
        public int? StopAfterGuarantUserOptionsPresetMin { get; set; }
        #endregion
        #region stop after guarant options
        public int StopAfterGuarantWithLargePresetUserOptionsAttemptsMax { get; set; }
        public int StopAfterGuarantWithLargePresetUserOptionsAttemptsMin { get; set; }
        public int StopAfterGuarantWithLargePresetUserOptionsCount { get; set; }
        public int? StopAfterGuarantWithLargePresetUserOptionsPresetMax { get; set; }
        public int? StopAfterGuarantWithLargePresetUserOptionsPresetMin { get; set; }
        #endregion
        #region stop after guarant without limit options
        public int StopAfterGuarantWithoutLimitUserOptionsCount { get; set; }
        public int? StopAfterGuarantWithoutLimitUserOptionsPresetMax { get; set; }
        public int? StopAfterGuarantWithoutLimitUserOptionsPresetMin { get; set; }
        #endregion
        #region stop before guarant
        public int StopBeforeGuarantUserOptionsAttemptsMax { get; set; }
        public int StopBeforeGuarantUserOptionsAttemptsMin { get; set; }
        public int StopBeforeGuarantUserOptionsCount { get; set; }
        public int? StopBeforeGuarantUserOptionsPresetMax { get; set; }
        public int? StopBeforeGuarantUserOptionsPresetMin { get; set; }
        public int StopBeforeGuarantUserOptionsStopIndexMax { get; set; }
        public int StopBeforeGuarantUserOptionsStopIndexMin { get; set; }
        #endregion
        #region expectation four win options
        public int ExpectationFourWinUserOptionsAttemptsMax { get; set; }
        public int ExpectationFourWinUserOptionsAttemptsMin { get; set; }
        public int ExpectationFourWinUserOptionsCount { get; set; }
        public int? ExpectationFourWinUserOptionsPresetMax { get; set; }
        public int? ExpectationFourWinUserOptionsPresetMin { get; set; }
        public int ExpectationFourWinUserOptionsCountMax { get; set; }
        public int ExpectationFourWinUserOptionsCountMin { get; set; }
        #endregion

        public Options Options
         => new()
         {
             Repeat = Repeat,
             UserOptions = new()
             {
                 AttemptsMax = UserOptionsAttemptsMax,
                 AttemptsMin = UserOptionsAttemptsMin,
                 Count = UserOptionsCount,
                 PresetMax = UserOptionsPresetMax,
                 PresetMin = UserOptionsPresetMin
             },
             StopAfterGuarantUserOptions = new()
             {
                 AttemptsMax = StopAfterGuarantUserOptionsAttemptsMax,
                 AttemptsMin = StopAfterGuarantUserOptionsAttemptsMin,
                 Count = StopAfterGuarantUserOptionsCount,
                 PresetMax = StopAfterGuarantUserOptionsPresetMax,
                 PresetMin = StopAfterGuarantUserOptionsPresetMin
             },
             StopAfterGuarantWithLargePresetUserOptions = new() 
             {
                 AttemptsMax = StopAfterGuarantWithLargePresetUserOptionsAttemptsMax,
                 AttemptsMin = StopAfterGuarantWithLargePresetUserOptionsAttemptsMin,
                 Count = StopAfterGuarantWithLargePresetUserOptionsCount,
                 PresetMax = StopAfterGuarantWithLargePresetUserOptionsPresetMax,
                 PresetMin = StopAfterGuarantWithLargePresetUserOptionsPresetMin
             },
             StopAfterGuarantWithoutLimitUserOptions = new()
             {
                 Count = StopAfterGuarantWithoutLimitUserOptionsCount,
                 PresetMax = StopAfterGuarantWithoutLimitUserOptionsPresetMax,
                 PresetMin = StopAfterGuarantWithoutLimitUserOptionsPresetMin
             },
             StopBeforeGuarantUserOptions = new()
             {
                 AttemptsMax = StopBeforeGuarantUserOptionsAttemptsMax,
                 AttemptsMin = StopBeforeGuarantUserOptionsAttemptsMin,
                 Count = StopBeforeGuarantUserOptionsCount,
                 PresetMax = StopBeforeGuarantUserOptionsPresetMax,
                 PresetMin = StopBeforeGuarantUserOptionsPresetMin,
                 StopIndexMax = GuarantFiveWin - StopBeforeGuarantUserOptionsStopIndexMin,
                 StopIndexMin = GuarantFiveWin - StopBeforeGuarantUserOptionsStopIndexMax
             },
             ExpectationFourWinUserOptions = new()
             {
                 AttemptsMax = ExpectationFourWinUserOptionsAttemptsMax,
                 AttemptsMin = ExpectationFourWinUserOptionsAttemptsMin,
                 Count = ExpectationFourWinUserOptionsCount,
                 PresetMax = ExpectationFourWinUserOptionsPresetMax,
                 PresetMin = ExpectationFourWinUserOptionsPresetMin,
                 CountMax = ExpectationFourWinUserOptionsCountMax,
                 CountMin = ExpectationFourWinUserOptionsCountMin
             },
             Chances = new Chance[]
             {
                 new Chance{ Win = Win.FiveStart, Percent = ChanceFiveWinPercente },
                 new Chance{ Win = Win.FourStars, Percent = ChanceFourWinPercente }
             },
             Guarants = new Guarant[]
             {
                 new Guarant{ Win = Win.FiveStart, Count = GuarantFiveWin },
                 new Guarant{ Win = Win.FourStars, Count = GuarantFourWin }
             }
         };
    }
}
