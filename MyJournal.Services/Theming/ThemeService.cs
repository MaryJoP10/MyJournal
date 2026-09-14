using Microsoft.Maui.Graphics;
using System;
using MyJournal.Services.Theming;
using Microsoft.Maui.Controls;

namespace MyJournal.Services.Theming
{
    public class ThemeService : IThemeService
    {
        public AppThemeOption Current { get; private set; } = AppThemeOption.Light;

        public void SetTheme(AppThemeOption theme)
        {
            Current = theme;
            try
            {
                if (Application.Current == null) return;

                if (theme == AppThemeOption.Light)
                {
                    Application.Current.Resources["PrimaryColor"] = Color.FromArgb("#E63946");
                    Application.Current.Resources["PrimaryVariant"] = Color.FromArgb("#6A3D9A");
                    Application.Current.Resources["AccentColor"] = Color.FromArgb("#F7E7A3");
                    Application.Current.Resources["BackgroundColor"] = Color.FromArgb("#F8F1E7");
                    Application.Current.Resources["SurfaceColor"] = Color.FromArgb("#FFF8EF");
                    Application.Current.Resources["TextColor"] = Color.FromArgb("#2A2030");
                }
                else if (theme == AppThemeOption.Dark)
                {
                    Application.Current.Resources["PrimaryColor"] = Color.FromArgb("#E63946");
                    Application.Current.Resources["PrimaryVariant"] = Color.FromArgb("#8E5BB5");
                    Application.Current.Resources["AccentColor"] = Color.FromArgb("#F7E7A3");
                    Application.Current.Resources["BackgroundColor"] = Color.FromArgb("#1B1222");
                    Application.Current.Resources["SurfaceColor"] = Color.FromArgb("#28182F");
                    Application.Current.Resources["TextColor"] = Color.FromArgb("#FFF8EF");
                }
            }
            catch
            {
                // no bloquear en caso de error
            }
        }
    }
}
