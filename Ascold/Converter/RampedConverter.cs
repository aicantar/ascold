using Ascold.Extensions;
using SkiaSharp;

namespace Ascold.Converter;

public class RampedConverter(string ramp) : IConverter
{
    public string BitmapToAscii(SKBitmap bitmap) => RampCharacterForLuminance(bitmap.AverageLuminance());

    private string RampCharacterForLuminance(double luminance) =>
        ramp[Convert.ToInt32(Math.Ceiling((ramp.Length - 1) * luminance / 255))].ToString();
}