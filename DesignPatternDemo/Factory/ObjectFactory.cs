namespace ObjectFactory;

public enum Theme
{
    Light,
    Dark,
    System
}

public interface ITheme
{
    Theme Theme { get; }
    void Apply();
}

public class LightTheme : ITheme
{
    public Theme Theme => Theme.Light;

    public void Apply()
    {
        Console.WriteLine($"Applying {Theme} {nameof(Theme)}");
    }
}

public class DarkTheme : ITheme
{
    public Theme Theme => Theme.Dark;

    public void Apply()
    {
        Console.WriteLine($"Applying {Theme} {nameof(Theme)}");
    }
}

public class SystemTheme : ITheme
{
    public Theme Theme => Theme.System;

    public void Apply()
    {
        Console.WriteLine($"Applying {Theme} {nameof(Theme)}");
    }
}

public class ThemeFactory
{
    public IEnumerable<ITheme> _themes;
    public ThemeFactory(IEnumerable<ITheme> themes)
    {
        _themes = themes;
    }
    public ITheme GetTheme(Theme theme)
    {
        return _themes.First(x => x.Theme == theme);
    }
}