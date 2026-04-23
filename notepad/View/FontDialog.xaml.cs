using System.Windows;
using notepad.Service;
using notepad.ViewModel;

namespace notepad.View;

public partial class FontDialog : Window
{
    public FontDialog()
    {
        InitializeComponent();
        
        DataContext = ServiceLocator.GetService<ViewModelLocator>();
    }
}