using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using notepad.Message;

namespace notepad.ViewModel;

public partial class ViewViewModel: ObservableObject
{
    [RelayCommand]
    private void ShowFont()
    {
        WeakReferenceMessenger.Default.Send(new ShowFontMessage());
    }
}