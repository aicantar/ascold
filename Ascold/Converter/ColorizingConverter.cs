using Ascold.Colorizer;
using Ascold.Extensions;
using SkiaSharp;

namespace Ascold.Converter;

public class ColorizingConverter(IColorizer colorizer, IConverter baseConverter) : IConverter
{
    public string BitmapToAscii(SKBitmap bitmap)
    {
        return colorizer.Colorize(bitmap.AverageColor(), baseConverter.BitmapToAscii(bitmap));
    }
}