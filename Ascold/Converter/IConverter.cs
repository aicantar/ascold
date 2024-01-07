using SkiaSharp;

namespace Ascold.Converter;

public interface IConverter
{
    public string BitmapToAscii(SKBitmap bitmap);
}