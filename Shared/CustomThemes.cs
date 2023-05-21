using MudBlazor;

namespace Pharmatic.Shared
{
    public class CustomThemes
    {
        public static Palette PharmaticPalette { get; } = new Palette()
        {
            Primary = "#17ACBE",
            Surface = "#ECF1FF",
            White = "#ECF1FF",
            Background = "#ECF1FF",
            BackgroundGrey = "#ECF1FF",
            PrimaryDarken = "#17ACBE",
            PrimaryLighten = "#17ACBE",
            AppbarBackground = "#E6E6E6"
        };

        public static MudTheme PharmaticTheme { get; } = new MudTheme()
        {
            Palette = PharmaticPalette,
        };

        public static MudTheme PharmaticThemeRounded { get; } = new MudTheme()
        {
            Palette = PharmaticPalette,
            LayoutProperties = new LayoutProperties()
            {
                AppbarHeight = "100px",
                DefaultBorderRadius = "24px",
            }
        };
    }
}
