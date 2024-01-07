using SkiaSharp;

namespace Ascold.Extensions;

public static class SKColorExtensions
{
    public static double Luminance(this SKColor color)
    {
        return 0.299 * color.Red + 0.587 * color.Green + 0.114 * color.Blue;
    }
}