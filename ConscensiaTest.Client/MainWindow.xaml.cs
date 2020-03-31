using System;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Newtonsoft.Json;

namespace ConscensiaTest.Client
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly String BaseUrl = ConfigurationManager.AppSettings["baseUrl"];
        private const String RandomNumberPath = "Conscensia/GetRandomNumber";
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly Slider _slider;

        public MainWindow()
        {
            var timer = new DispatcherTimer {Interval = TimeSpan.FromSeconds(1)};
            InitializeComponent();

            _slider = Slider;
            timer.Tick += OnTick;
            timer.Start();
        }

        private async void OnTick(Object sender, EventArgs args)
        {
            _slider.Value = await GetRandomNumberAsync();
        }

        private async Task<Int32> GetRandomNumberAsync()
        {
            using var response = await _httpClient.GetAsync(BuildUrl(RandomNumberPath));
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Int32>(content);
        }

        private static String BuildUrl(String path)
        {
            return BaseUrl + path;
        }
    }
}