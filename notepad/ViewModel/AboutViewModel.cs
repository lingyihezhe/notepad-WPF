using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using notepad.Message;

namespace notepad.ViewModel;

public partial class AboutViewModel: ObservableObject
{
    // 与菜单的关于Binding，启动关于对话菜单（发送消息到主窗口后端进行处理）
    [RelayCommand]
    private void ShowAbout()
    {
        WeakReferenceMessenger.Default.Send(new ShowAboutMessage());
    }
}