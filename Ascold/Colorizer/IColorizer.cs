using SkiaSharp;

namespace Ascold.Colorizer;

public interface IColorizer
{
    public string Colorize(SKColor color, string value);
}