using System.Collections.ObjectModel;
using magazine.Models;
using ReactiveUI;

namespace magazine.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private ObservableCollection<Product> _products;
    
    public ObservableCollection<Product> Products
    {
        get => _products;
        set => this.RaiseAndSetIfChanged(ref _products, value);
    }

    public ObservableCollection<Product> Cart
    {
        get => _products;
        set => this.RaiseAndSetIfChanged(ref _products, value);
    }

    public MainWindowViewModel()
    {
        Products = new() { new Product() { Name = "ASD", Price = 111, Quantity = 5 } };
        
    }
    
}