using kursach_mvvm.Models;

namespace kursach_mvvm.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private string _id = ParseAPI.id;
    public string Path => $"/Users/aleksej/Desktop/kursach_mvvm/kursach_mvvm/kursach_mvvm/Assets/{_id}@2x.png";
}