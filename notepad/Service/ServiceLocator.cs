using Microsoft.Extensions.DependencyInjection;
using notepad.Model;
using notepad.ViewModel;

namespace notepad.Service;

public static class ServiceLocator
{
    // 使用 Lazy<T> 确保线程安全
    private static readonly Lazy<IServiceProvider> _serviceProvider = 
        new Lazy<IServiceProvider>(() =>
        {
            var services = new ServiceCollection();
            
            services.AddSingleton<DocumentModel>();
            services.AddSingleton<AboutViewModel>();
            services.AddSingleton<ViewViewModel>();
            services.AddSingleton<FontViewModel>();
            services.AddSingleton<FileViewModel>();
            services.AddSingleton<ViewModelLocator>();
            
            return services.BuildServiceProvider();
        });
    
    private static IServiceProvider ServiceProvider => _serviceProvider.Value;
    
    // 无需Configure方法，首次使用时自动初始化
    public static T GetService<T>() where T : class
    {
        return ServiceProvider.GetRequiredService<T>();
    }
}