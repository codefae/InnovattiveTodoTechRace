using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InnovativeToDo.Avalonia.Models;
using InnovativeToDo.Avalonia.Repositories;

namespace InnovativeToDo.Avalonia.ViewModels;

public partial class ToDoViewModel : ViewModelBase
{
    [ObservableProperty] 
    private ObservableCollection<ToDoModel> toDoList = [];
    private readonly IRepository<ToDoModel> _repository;
    
    [RelayCommand]
    private async void MarkToDoAsDone(int id)
    {
        var toDoItem = ToDoList.FirstOrDefault(todo => todo.Id == id);
        if (toDoItem != null)
        {
            toDoItem.IsDone = true;
            await _repository.UpdateAsync(toDoItem);
        }
    }
   
    
    
    public ToDoViewModel(IRepository<ToDoModel> repository)
    {
        _repository = repository;
        populateToDoList();
    }
    
    private async void populateToDoList()
    {
        ToDoList =  new ObservableCollection<ToDoModel>(await _repository.GetAllAsync());
    }
}