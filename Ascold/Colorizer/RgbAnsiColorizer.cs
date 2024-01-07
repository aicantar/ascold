using SkiaSharp;

namespace Ascold.Colorizer;

public class RgbAnsiColorizer : IColorizer
{
    public string Colorize(SKColor color, string value)
    {
        return $"\x1b[38;2;{color.Red};{color.Green};{color.Blue}m{value}\x1b[0m";
    }
}