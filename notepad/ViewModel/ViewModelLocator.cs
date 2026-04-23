using notepad.Model;

namespace notepad.ViewModel;

// 所有 ViewModel 一目了然
public class ViewModelLocator
{
    public DocumentModel DocumentM { get; }
    public AboutViewModel AboutVm { get; }
    public FontViewModel FontVm { get; }
    public ViewViewModel ViewVm { get; }
    
    public FileViewModel FileVm { get; }

    public ViewModelLocator(
        DocumentModel documentM,
        AboutViewModel aboutVm,
        FontViewModel fontVm,
        ViewViewModel viewVm,
        FileViewModel fileVm
        )
    {
        DocumentM = documentM;
        AboutVm = aboutVm;
        FontVm = fontVm;
        ViewVm = viewVm;
        FileVm = fileVm;
    }
}