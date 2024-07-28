using System.Text;

namespace ObjectTrackingAndBulkReplacement;


public interface ILookAndFeel
{
    ConsoleColor TextColor { get; }
    ConsoleColor BackgroundColor { get; }
}

public class DarkUI : ILookAndFeel
{
    public ConsoleColor TextColor => ConsoleColor.White;

    public ConsoleColor BackgroundColor => ConsoleColor.DarkGray;
}

public class LightUI : ILookAndFeel
{
    public ConsoleColor TextColor => ConsoleColor.Black;

    public ConsoleColor BackgroundColor => ConsoleColor.White;
}

public class LookAndFeelTrackingFactory
{
    private readonly IList<WeakReference<ILookAndFeel>> _fetchedUIs;

    public LookAndFeelTrackingFactory()
    {
        _fetchedUIs = new List<WeakReference<ILookAndFeel>>();
    }
    public ILookAndFeel GetUI(bool isDark)
    {
        ILookAndFeel ui = isDark ? new DarkUI() : new LightUI();
        _fetchedUIs.Add(new WeakReference<ILookAndFeel>(ui));
        return ui;
    }

    public string Info
    {
        get
        {
            var sbr = new StringBuilder();
            foreach (var item in _fetchedUIs)
            {
                if (item.TryGetTarget(out var ui))
                {
                    var isDark = ui is DarkUI;
                    if (isDark) sbr.Append("Dark");
                    else sbr.Append("Light");
                    sbr.AppendLine(" UI Option Fetched.");
                }                
            }
            return sbr.ToString();
        }
    }
}


public class Ref<T> where T : class
{
    public T Value;

    public Ref(T value)
    {
        Value = value;
    }
}

public class LookAndFeelBulkReplacementFactory
{
    private readonly List<WeakReference<Ref<ILookAndFeel>>> _fetchedUIs;
    public LookAndFeelBulkReplacementFactory()
    {
        _fetchedUIs = new List<WeakReference<Ref<ILookAndFeel>>>();
    }

    public Ref<ILookAndFeel> GetUI(bool isDark)
    {
        ILookAndFeel ui = isDark ? new DarkUI() : new LightUI();
        var res = new Ref<ILookAndFeel>(ui);
        _fetchedUIs.Add(new WeakReference<Ref<ILookAndFeel>>(res));
        return res;
    }

    public void ReplaceAll(bool withDark)
    {
        ILookAndFeel ui = withDark ? new DarkUI() : new LightUI();
        foreach (var @ref in _fetchedUIs)
        {
            if (@ref.TryGetTarget(out var lastUi))
            {
                lastUi.Value = ui;
            }
        }
    }

    public string Info
    {
        get
        {
            var sbr = new StringBuilder();
            foreach (var item in _fetchedUIs)
            {
                if (item.TryGetTarget(out var ui))
                {
                    var isDark = ui.Value is DarkUI;
                    if (isDark) sbr.Append("Dark");
                    else sbr.Append("Light");
                    sbr.AppendLine(" UI Option Fetched.");
                }                
            }
            return sbr.ToString();
        }
    }
}