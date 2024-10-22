using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InnovativeToDo.Avalonia.Models;
using InnovativeToDo.Avalonia.Repositories;

namespace InnovativeToDo.Avalonia.ViewModels;

public partial class AddToDoViewModel : ViewModelBase
{
    [ObservableProperty] 
    private ObservableCollection<ToDoModel> toDoList = [];
    
    private readonly IRepository<ToDoModel> _repository;

    public AddToDoViewModel(IRepository<ToDoModel> repository)
    {
        _repository = repository;
        populateToDoList();
    }
    
    private async void populateToDoList()
    {
        ToDoList =  new ObservableCollection<ToDoModel>(await _repository.GetAllAsync());
    }

    [ObservableProperty]
    private string newTitle = string.Empty;
    
    [ObservableProperty]
    private string newDescription = string.Empty;
    
    [ObservableProperty]
    private DateTime toDoDate = DateTime.Now;
     
    [RelayCommand]
    public async Task AddToDoButtonClick()
    {
        var newToDo = new ToDoModel
        {
            UpdatedAt = ToDoDate,
            Title = newTitle,
            Description = newDescription
        };

        await _repository.AddAsync(newToDo);
        ToDoList.Add(newToDo); // Add to the list

        // Reset the form
        NewTitle = string.Empty;
        NewDescription = string.Empty;
    }
    
    [RelayCommand]
    public async Task DeleteToDoAsync(int id)
    {
        await _repository.DeleteAsync(id);
        var itemToRemove = ToDoList.FirstOrDefault(todo => todo.Id == id);
        if (itemToRemove != null)
        {
            ToDoList.Remove(itemToRemove);
        }
    }
    
}