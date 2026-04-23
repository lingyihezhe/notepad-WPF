using System.Windows;
using notepad.Service;
using notepad.ViewModel;

namespace notepad.View;

public partial class AboutDialog : Window
{
    public AboutDialog()
    {
        InitializeComponent();
        
        DataContext = ServiceLocator.GetService<ViewModelLocator>();
        
    }

    private void OnMitLicenseClick(object sender, RoutedEventArgs e)
    {
        // 获取 MainWindow 实例（即当前对话框的 Owner）
        if (Owner is MainWindow mainWindow)
        {
            // 获取 MainWindow 的 DataContext（ViewModelLocator）
            if (mainWindow.DataContext is ViewModelLocator locator)
            {
                // 调用 FileViewModel 的 OpenLicenseCommand 命令
                locator.FileVm.OpenLicenseCommand.Execute(null);
            }
        }
        // 关闭关于对话框
        this.Close();
    }
}