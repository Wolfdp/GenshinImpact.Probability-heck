using Nya.GenshinImpact.ProbabilityСheck.Services;
using Nya.GenshinImpact.ProbabilityСheck.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Nya.GenshinImpact.ProbabilityСheck
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EmulatorService _emulatorService;
        private OptionsModel optionsModel;
        private CanvasModel canvasModel;

        public MainWindow()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            _emulatorService = new EmulatorService(new StatisticsService(), new LuckCalculationService());
            chart.DataContext = canvasModel = new();
            gridOptions.DataContext = optionsModel = new()
            {
                Repeat = 10,
                GuarantFiveWin = 90,
                ChanceFiveWinPercente = 0.6M,
                GuarantFourWin = 10,
                ChanceFourWinPercente = 5.1M,
                UserOptionsAttemptsMax = 100,
                UserOptionsAttemptsMin = 50,
                UserOptionsCount = 18000,
                UserOptionsPresetMax = 89,
                UserOptionsPresetMin = 0,
                StopAfterGuarantUserOptionsAttemptsMax = 100,
                StopAfterGuarantUserOptionsAttemptsMin = 50,
                StopAfterGuarantUserOptionsCount = 20000,
                StopAfterGuarantUserOptionsPresetMax = 89,
                StopAfterGuarantUserOptionsPresetMin = 0,
                StopAfterGuarantWithLargePresetUserOptionsAttemptsMax = 100,
                StopAfterGuarantWithLargePresetUserOptionsAttemptsMin = 50,
                StopAfterGuarantWithLargePresetUserOptionsCount = 20000,
                StopAfterGuarantWithLargePresetUserOptionsPresetMax = 70,
                StopAfterGuarantWithLargePresetUserOptionsPresetMin = 50,
                StopAfterGuarantWithoutLimitUserOptionsCount = 2000,
                StopAfterGuarantWithoutLimitUserOptionsPresetMax = 89,
                StopAfterGuarantWithoutLimitUserOptionsPresetMin = 0,
                StopBeforeGuarantUserOptionsAttemptsMax = 100,
                StopBeforeGuarantUserOptionsAttemptsMin = 50,
                StopBeforeGuarantUserOptionsCount = 20000,
                StopBeforeGuarantUserOptionsPresetMax = 70,
                StopBeforeGuarantUserOptionsPresetMin = 0,
                StopBeforeGuarantUserOptionsStopIndexMax = 80,
                StopBeforeGuarantUserOptionsStopIndexMin = 60,
                ExpectationFourWinUserOptionsAttemptsMax = 100,
                ExpectationFourWinUserOptionsAttemptsMin = 50,
                ExpectationFourWinUserOptionsCount = 20000,
                ExpectationFourWinUserOptionsPresetMax = 89,
                ExpectationFourWinUserOptionsPresetMin = 0,
                ExpectationFourWinUserOptionsCountMax = 10,
                ExpectationFourWinUserOptionsCountMin = 3
            };

            Button_Click(null, null);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            runButton.IsEnabled = false;
            chart.ClearChart();
            try
            {
                if (!Validation.GetHasError(gridOptions)
                    && gridOptions.Children.Cast<Control>().All(x => !Validation.GetHasError(x)))
                {
                    var result = await Task.Run(() => _emulatorService.Run(optionsModel.Options));
                    canvasModel.Lines = CanvasModel.GetLines(result);
                }
                else
                {
                    throw new Exception("ошибка в опциях");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, ex.GetType().Name, MessageBoxButton.OK, MessageBoxImage.Error);
            }

            runButton.IsEnabled = true;
        }
    }
}
