using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using InnovativeToDo.Avalonia.ViewModels;
using InnovativeToDo.Avalonia.Views;
using Microsoft.Extensions.DependencyInjection;

namespace InnovativeToDo.Avalonia;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Line below is needed to remove Avalonia data validation.
            // Without this line you will get duplicate validations from both Avalonia and CT
            BindingPlugins.DataValidators.RemoveAt(0);
            var collection = new ServiceCollection();
            collection.ConfigureServices();
            var services = collection.BuildServiceProvider();
            var vm = services.GetRequiredService<MainWindowViewModel>();
            desktop.MainWindow = new MainWindow(vm);
        }

        base.OnFrameworkInitializationCompleted();
    }
}

