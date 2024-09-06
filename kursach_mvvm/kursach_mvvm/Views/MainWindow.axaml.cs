using Avalonia.Controls;
using Avalonia.Interactivity;
using kursach_mvvm.Models;
using kursach_mvvm.ViewModels;

namespace kursach_mvvm.Views;

public partial class MainWindow : Window
{
    
    public MainWindow()
    {
        InitializeComponent();
    }
    private void SearchButton_OnClick(object? sender, RoutedEventArgs e)
    {
        ParseAPI answer = new ParseAPI(Search.Text);
        answer.API();
        City.Text = ParseAPI.City;
        MainWindowViewModel viewModel = new MainWindowViewModel();
        this.DataContext = viewModel;
        WeatherInfo.Text = ParseAPI.WeatherInfo;
        CurrentTemp.Text = ParseAPI.CurrentTemp.ToString() + " \u00b0";
        Temp.Text = ParseAPI.Temp.ToString() + " \u00b0";
        MaxTemp.Text = ParseAPI.MaxTemp.ToString() + " \u00b0";
        MinTemp.Text = ParseAPI.MinTemp.ToString() + " \u00b0";
        Wind.Text = ParseAPI.Wind.ToString() + " м/c";
        Humidity.Text = ParseAPI.Humidity.ToString() + " %";
        Pressure.Text = ParseAPI.Pressure.ToString() + " мм рт.ст.";
        Sunset.Text = ParseAPI.timeSunset;
        Sunrise.Text = ParseAPI.timeSunrise;
    }
}