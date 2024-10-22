using Avalonia.Controls;
using InnovativeToDo.Avalonia.ViewModels;

namespace InnovativeToDo.Avalonia.Views;

public partial class MainWindow : Window
{
    public MainWindow(MainWindowViewModel viewModel)
    {
        InitializeComponent();
        
        DataContext = viewModel;
    }
}