using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InnovativeToDo.Avalonia.Models;
using InnovativeToDo.Avalonia.Repositories;
using InnovativeToDo.Avalonia.Views;

namespace InnovativeToDo.Avalonia.ViewModels;

public partial class MainWindowViewModel(IRepository<ToDoModel> todoRepository,
     
     AddToDoViewModel addToDoViewModel) : ViewModelBase
{
     [ObservableProperty]
     private UserControl userControl = new ToDoView(new ToDoViewModel(todoRepository));
     
     [RelayCommand]
     private void ChangeViewClick(string view)
     {
          UserControl = view switch
          {
               "ToDos" =>  new ToDoView(new ToDoViewModel(todoRepository)),
               "Create" => new AddToDoView(addToDoViewModel),
               _ => UserControl
          };
     }

}