using System.Collections.ObjectModel;
using System.Windows.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using notepad.Model;

namespace notepad.ViewModel;

public partial class FontViewModel(DocumentModel DocumentM): ObservableObject
{
    [RelayCommand]
    private void FontSizeIncrease()
    {
        DocumentM.FontSize += 1 ;
    }
    
    [RelayCommand]
    private void FontSizeDecrease()
    {
        DocumentM.FontSize -= 1 ;
    }

    [RelayCommand]
    private void FontSetDefault()
    {
        DocumentM.FontFamily = DocumentM.FontDefault;
    }
}