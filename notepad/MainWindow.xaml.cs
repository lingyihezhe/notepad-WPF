using System.Windows;
using CommunityToolkit.Mvvm.Messaging;
using notepad.Message;
using notepad.Service;
using notepad.View;
using notepad.ViewModel;

namespace notepad;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        // 通过服务获取全局唯一ViewModelLocator实例，已传参
        // 可以通过ViewModelLocator实例间接访问全部vm和v
        DataContext = ServiceLocator.GetService<ViewModelLocator>();

        //  消息处理
        RegisterMessages();
    }
    
    // 消息处理函数
    private void RegisterMessages()
    {
        // 注册和处理ShowAboutMessage消息，创建AboutDialog对话窗口
        WeakReferenceMessenger.Default.Register<ShowAboutMessage>(this, 
            (r, m) => new AboutDialog { Owner = this }.ShowDialog());
        
        // 注册和处理ShowFontMessage消息，创建FontDialog对话窗口
        WeakReferenceMessenger.Default.Register<ShowFontMessage>(this, 
            (r, m) => new FontDialog { Owner = this }.ShowDialog());
        
    }
}