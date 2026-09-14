using System;

namespace MyJournal.Services.Theming
{
    public enum AppThemeOption { Light, Dark, System }

    public interface IThemeService
    {
        AppThemeOption Current { get; }
        void SetTheme(AppThemeOption theme);
    }
}
