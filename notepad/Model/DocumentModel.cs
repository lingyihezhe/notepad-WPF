using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Media;
namespace notepad.Model;
using System.IO;

public partial class DocumentModel: ObservableObject
{
    // 视图-状态栏-勾选框，是否显示状态栏：IsStatusBarVisible
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(StatusBarVisible))]
    private bool _isStatusBarVisible = true;
    
    // 状态栏-可见性，是否显示状态栏：StatusBarVisible
    public Visibility StatusBarVisible => IsStatusBarVisible?Visibility.Visible :Visibility.Hidden ;
    
    // 视图-自动换行-勾选框：IsWrapped
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(TextWrap))]
    private bool _isWrapped = true;
    
    // 编辑区-自动换行属性：TextWrap
    public TextWrapping TextWrap => IsWrapped?TextWrapping.Wrap:TextWrapping.NoWrap ;
    
    // 编辑区-字体大小：FontSize
    [ObservableProperty]
    private int _fontSize = 12;

    // 视图-字体-字体对话框-字体家族选项
    [ObservableProperty]
    private ObservableCollection<FontFamily> _systemFontFamilies  = 
        new ObservableCollection<FontFamily>(Fonts.SystemFontFamilies.OrderBy(f => f.Source));
    
    // 默认字体
    public FontFamily FontDefault => SystemFonts.MessageFontFamily;
    
    // 编辑区-使用字体
    [ObservableProperty]
    private FontFamily _fontFamily = SystemFonts.MessageFontFamily;
    
    // 文件路径
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(DocTitle))]
    private string _docPath = string.Empty;
    
    // 标题
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(DocTitle))]
    private string _docName = "无标题";
    
    // 标题+保存状态
    public string DocTitle => DocName  +
                              ((DocPath == "LICENSE") ? "（只读）" : "") + "-" +
                              (IsModified ? "未保存" : "已保存");
    
    // 编码格式
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(DocEncodingName))]
    private Encoding _docEncoding = Encoding.UTF8;

    // 状态栏-编码格式
    public string DocEncodingName => DocEncoding.EncodingName;
    
    // textbox.text 缓存文本
    [ObservableProperty]
    private string _docString = string.Empty;

    // 修改状态
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(DocTitle))]
    private bool _isModified = true;

    // 总字数
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(DocLengthStatus))]
    private int _docLength = 0;
    
    // 状态栏-总字数
    public string DocLengthStatus => DocLength.ToString() + "字";
    
    // 当前行
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(DocCurrentPosition))]
    private int _docCurrentLine = 1;

    // 当前列
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(DocCurrentPosition))]
    private int _docCurrentColumn = 1;
    
    public string DocCurrentPosition => "第" + DocCurrentLine.ToString()+"行，"
                                        + "第" + DocCurrentColumn.ToString() + "列";
}