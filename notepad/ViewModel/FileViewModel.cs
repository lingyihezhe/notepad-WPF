using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using notepad.Model;
using System.IO;
using System.Text;
using System.Windows.Controls;
using Microsoft.Win32;
namespace notepad.ViewModel;

public partial class FileViewModel(DocumentModel DocumentM): ObservableObject
{
    [RelayCommand]
    private void OpenFile()
    {
        var openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "文本文件 (*.txt)|*.txt|所有文件 (*.*)|*.*";
    
        if (openFileDialog.ShowDialog() == true)
        {
            DocumentM.DocPath = openFileDialog.FileName;
            DocumentM.DocName = Path.GetFileName(DocumentM.DocPath);
            using (var reader = new StreamReader(DocumentM.DocPath, Encoding.Default, detectEncodingFromByteOrderMarks: true))
            {
                reader.Peek(); // 触发编码检测
                DocumentM.DocEncoding = reader.CurrentEncoding;
            }
            DocumentM.DocString = File.ReadAllText(DocumentM.DocPath, DocumentM.DocEncoding);
            DocumentM.IsModified = false;
            DocumentM.DocLength = DocumentM.DocString.Length;
            DocumentM.DocCurrentColumn = 1;
            DocumentM.DocCurrentLine = 1;
        }
    }

    [RelayCommand]
    private void CloseFile()
    {
        DocumentM.DocPath = string.Empty;
        DocumentM.DocName = "无标题";
        DocumentM.DocEncoding = Encoding.UTF8;
        DocumentM.DocString = string.Empty;
        DocumentM.IsModified = true; 
        DocumentM.DocLength = 0;
        DocumentM.DocCurrentColumn = 1;
        DocumentM.DocCurrentLine = 1;
    }

    [RelayCommand]
    private void SaveFile(TextBox MainTextBox)
    {
        if (DocumentM.DocPath == "LICENSE")
        {
            return;
        }

        if (DocumentM.DocPath == string.Empty)
        {
            SaveAsFile(MainTextBox);
        }
        else
        {
            MainTextBox.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
            File.WriteAllText(DocumentM.DocPath, DocumentM.DocString, DocumentM.DocEncoding);
            DocumentM.IsModified = false;
            DocumentM.DocCurrentColumn = 1;
            DocumentM.DocCurrentLine = 1;
        }
    }

    [RelayCommand]
    private void SaveAsFile(TextBox MainTextBox)
    {
        MainTextBox.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
        
        var saveDialog = new SaveFileDialog();
        saveDialog.Filter = "文本文件|*.txt|所有文件|*.*";
        if (saveDialog.ShowDialog() == true)
        {
            DocumentM.DocPath = saveDialog.FileName;
            DocumentM.DocName = Path.GetFileName(DocumentM.DocPath);
            File.WriteAllText(DocumentM.DocPath, DocumentM.DocString, DocumentM.DocEncoding);
            DocumentM.IsModified = false;
            DocumentM.DocCurrentColumn = 1;
            DocumentM.DocCurrentLine = 1;
        }
    }
    
    [RelayCommand]
    private void OnTextChanged(int length)
    {
        DocumentM.IsModified = true;
        DocumentM.DocLength = length;
    }
    
    [RelayCommand]
    private void UpdateCaretPosition(TextBox textBox)
    {
        int caretIndex = textBox.CaretIndex;
        // 获取光标所在行索引
        int lineIndex = textBox.GetLineIndexFromCharacterIndex(caretIndex);
        // 行号 = 行索引 + 1
        DocumentM.DocCurrentLine = lineIndex + 1;
        // 获取该行第一个字符的索引
        int lineStartIndex = textBox.GetCharacterIndexFromLineIndex(lineIndex);
        // 列号 = 光标索引 - 行首索引 + 1
        DocumentM.DocCurrentColumn = caretIndex - lineStartIndex + 1;
    }

    [RelayCommand]
    private void OpenLicense()
    {
        DocumentM.DocPath = "LICENSE";
        DocumentM.DocName = "LICENSE";
        using (var reader = new StreamReader(DocumentM.DocPath, Encoding.Default, detectEncodingFromByteOrderMarks: true))
        {
            reader.Peek(); // 触发编码检测
            DocumentM.DocEncoding = reader.CurrentEncoding;
        }
        DocumentM.DocString = File.ReadAllText(DocumentM.DocPath, DocumentM.DocEncoding);
        DocumentM.IsModified = false;
        DocumentM.DocLength = DocumentM.DocString.Length;
        DocumentM.DocCurrentColumn = 1;
        DocumentM.DocCurrentLine = 1;
    }
}