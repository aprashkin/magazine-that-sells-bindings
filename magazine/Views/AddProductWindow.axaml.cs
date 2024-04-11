using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Threading.Tasks;
using Avalonia.Markup.Xaml;
using magazine.Models;
using magazine.ViewModels;

namespace magazine.Views;

public partial class AddProductWindow : Window
{
    private MainWindowViewModel viewModel;
    public AddProductWindow(MainWindowViewModel viewModel)
    {
        InitializeComponent();
        this.viewModel = viewModel;
    }
    

    private async void Add_product(object? sender, RoutedEventArgs e)
    {
        if (
            string.IsNullOrWhiteSpace(nm.Text) || 
            string.IsNullOrWhiteSpace(pr.Text) ||
            string.IsNullOrWhiteSpace(ct.Text))
        {
            Error.Text = "Заполните все поля!";
            await Task.Delay(3000);
            Error.Text = string.Empty;
            return;
        }

        if (
            !int.TryParse(pr.Text, out int price))
        {
            Error.Text = "Введите корректную цену!";
            await Task.Delay(3000);
            Error.Text = string.Empty;
            return;
        }

        if (
            !int.TryParse(ct.Text, out int count))
        {
            Error.Text = "Введите корректное количество!";
            await Task.Delay(3000);
            Error.Text = string.Empty;
            return;
        }

        var newProduct = new Product
        {
            Name = nm.Text,
            Price = price,
            Quantity = count
        };
        
        viewModel.Products.Add(newProduct);
        
        nm.Text = String.Empty;
        pr.Text = String.Empty;
        ct.Text = String.Empty;
        this.Close();
        
        
        
    }
}