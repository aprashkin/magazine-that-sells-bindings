using System;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using magazine.Models;
using magazine.ViewModels;

namespace magazine.Views;

public partial class MainWindow : Window
{
    private TextBlock _summa;
    public MainWindow(object dataContext)
    {
        InitializeComponent();
        DataContext = dataContext;
        _summa = summa;
        
        Update();
        
        ProductChanges();
    }

    
    private void ProductChanges()
    {
        var viewModel = DataContext as MainWindowViewModel;
        if (viewModel != null)
        {
            viewModel.Products.CollectionChanged += (sender, args) => { Update(); };
        }
    }

    private void add_product(object? sender, RoutedEventArgs e)
    {
        var addProd = new AddProductWindow(DataContext as MainWindowViewModel);
        addProd.Show();
    }

    private void Update()
    {
        var viewmodel = DataContext as MainWindowViewModel;
        if (viewmodel != null)
        {
            var totalPrice = viewmodel.Cart.Sum(product => product.Price * product.Quantity);
            summa.Text = $"Итого: {totalPrice} \u20bd";
        }
    }

    private void delete_product(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var selectedItems = ProductsList.SelectedItems.OfType<Product>().ToList();
        var viewModel = DataContext as MainWindowViewModel;

        if (viewModel != null)
        {
            foreach (var selectedItem in selectedItems)
            {
                viewModel.Cart.Remove(selectedItem);
            }
            Update();
        }
    }

    private void xdd(object? sender, RoutedEventArgs e)
    {
        Environment.Exit(666);
    }
}