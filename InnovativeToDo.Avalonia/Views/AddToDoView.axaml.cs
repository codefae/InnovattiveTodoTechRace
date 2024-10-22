using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using InnovativeToDo.Avalonia.ViewModels;

namespace InnovativeToDo.Avalonia.Views;

public partial class AddToDoView : UserControl
{
    public AddToDoView(AddToDoViewModel addToDoViewModel)
    {
        InitializeComponent();

        DataContext = addToDoViewModel;
    }
}