using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using InnovativeToDo.Avalonia.ViewModels;

namespace InnovativeToDo.Avalonia.Views;

public partial class ToDoView : UserControl
{
    public ToDoView(ToDoViewModel toDoViewModel)
    {
        InitializeComponent();

        DataContext = toDoViewModel;
    }
}