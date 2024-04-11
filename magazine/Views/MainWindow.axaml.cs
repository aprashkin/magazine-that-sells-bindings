using Avalonia.Controls;
using Avalonia.Interactivity;
using magazine.ViewModels;

namespace magazine.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void add_product(object? sender, RoutedEventArgs e)
    {
        var addProd = new AddProductWindow(DataContext as MainWindowViewModel);
        addProd.Show();
    }

    private void delete_product(object? sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }
}