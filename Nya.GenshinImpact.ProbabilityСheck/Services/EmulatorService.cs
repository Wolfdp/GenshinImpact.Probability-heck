using Nya.GenshinImpact.ProbabilityСheck.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nya.GenshinImpact.ProbabilityСheck.Services
{
    public class EmulatorService
    {
        private readonly Random _random;
        private readonly StatisticsService _statisticsService;
        private readonly LuckCalculationService _luckCalculationService;

        public EmulatorService(StatisticsService statisticsService, LuckCalculationService luckCalculationService)
        {
            _random = new();
            _statisticsService = statisticsService;
            _luckCalculationService = luckCalculationService;
        }

        public IEnumerable<StatisticsData> Run(Options options)
        {
            var result = new List<StatisticsData>();
            _luckCalculationService.SetOptions(options);
            for (var i = 0; i < options.Repeat; i++)
            {
                _statisticsService.Reset();
                var users = InitUsers(options);

                Parallel.ForEach(users, RunUser);
                result.AddRange(_statisticsService.GetData());
            }
            return result;
        }

        private void RunUser(BaseUser user)
        {
            var random = new Random();

            Win? action()
            {
                (var win, var index) = _luckCalculationService.DiceRoll(user, random);
                if (win.HasValue)
                    _statisticsService.Reg(win.Value, index);
                return win;
            }
            user.Play(action);
        }

        private IEnumerable<BaseUser> InitUsers(Options options)
        {
            return CreateBaseUsers(options.UserOptions, (availableAttempts, preset) => new User(availableAttempts, preset))
                .Concat(CreateBaseUsers(options.StopAfterGuarantUserOptions, (availableAttempts, preset) => new StopAfterGuarantUser(availableAttempts, preset)))
                .Concat(CreateBaseUsers(options.StopAfterGuarantWithLargePresetUserOptions, (availableAttempts, preset) => new StopAfterGuarantUser(availableAttempts, preset)))
                .Concat(CreateBaseUsers(options.StopAfterGuarantUserOptions, (availableAttempts, preset) => new StopAfterGuarantWithoutLimitUser(preset)))
                .Concat(CreateStopBeforeGuarantUsers(options.StopBeforeGuarantUserOptions));
        }

        private IEnumerable<BaseUser> CreateBaseUsers(BaseUserOptions options, Func<int, int?, BaseUser>creator)
        {
            var users = new BaseUser[options.Count];
            for (var i = 0; i < options.Count; i++)
            {
                var availableAttempts = _random.Next(options.AttemptsMin, options.AttemptsMax + 1);
                var preset = options.PresetMin.HasValue && options.PresetMax.HasValue
                    ? _random.Next(options.PresetMin.Value, options.PresetMax.Value + 1)
                    : default(int?);
                users[i] = creator(availableAttempts, preset);
            }
            return users;
        }

        private IEnumerable<BaseUser> CreateStopBeforeGuarantUsers(StopBeforeGuarantUserOptions options)
        {
            var users = new BaseUser[options.Count];
            for (var i = 0; i < options.Count; i++)
            {
                var availableAttempts = _random.Next(options.AttemptsMin, options.AttemptsMax + 1);
                var preset = options.PresetMin.HasValue && options.PresetMax.HasValue
                    ? _random.Next(options.PresetMin.Value, options.PresetMax.Value + 1)
                    : default(int?);
                users[i] = new StopBeforeGuarantUser(availableAttempts, _random.Next(options.StopIndexMin, options.StopIndexMax + 1), preset);
            }
            return users;
        }
    }
}
