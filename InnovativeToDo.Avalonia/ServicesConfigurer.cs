using System.Threading.Tasks;
using InnovativeToDo.Avalonia.Models;
using InnovativeToDo.Avalonia.Repositories;
using InnovativeToDo.Avalonia.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace InnovativeToDo.Avalonia;

public static class ServicesConfigurer
{
    public static void ConfigureServices(this ServiceCollection collection)
    {
        collection.AddSingleton<IRepository<ToDoModel>, Repository<ToDoModel>>();
        collection.AddSingleton<AddToDoViewModel>();
        collection.AddScoped<ToDoViewModel>();
        collection.AddSingleton<MainWindowViewModel>();
    }
}