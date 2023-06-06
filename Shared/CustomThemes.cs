using MudBlazor;

namespace Pharmatic.Shared
{
    public class CustomThemes
    {
        public static PaletteLight PharmaticPalette { get; } = new PaletteLight()
        {
            Primary = "#17ACBE",
            PrimaryDarken = "#17ACBE",
            PrimaryLighten = "#17ACBE",
            AppbarBackground = "#E6E6E6",
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
