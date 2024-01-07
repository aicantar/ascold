using SkiaSharp;

namespace Ascold.Extensions;

public static class SKBitmapExtensions
{
    /// <summary>
    /// Calculates average color of the bitmap.
    /// </summary>
    public static SKColor AverageColor(this SKBitmap bitmap)
    {
        return new SKColor(
            Convert.ToByte(bitmap.Pixels.Average(pixel => pixel.Red)),
            Convert.ToByte(bitmap.Pixels.Average(pixel => pixel.Green)),
            Convert.ToByte(bitmap.Pixels.Average(pixel => pixel.Blue))
        );
    }

    /// <summary>
    /// Calculates average luminance of the bitmap.
    /// </summary>
    public static double AverageLuminance(this SKBitmap bitmap)
    {
        return bitmap.Pixels.Average(pixel => pixel.Luminance());
    }

    /// <summary>
    /// Resizes bitmap by height while maintaining the aspect ratio.
    /// </summary>
    /// <returns>Resized bitmap.</returns>
    public static SKBitmap ResizeHWithAspectRatio(this SKBitmap bitmap, int newHeight)
    {
        var aspectRatio = bitmap.Width * 1.0 / bitmap.Height;
        var newWidth = Convert.ToInt32(newHeight * aspectRatio);

        return bitmap.Resize(new SKSizeI(newWidth, newHeight), SKFilterQuality.High);
    }

    /// <summary>
    /// Returns an enumerable of bitmaps each representing a chunk of the given width and height.
    /// </summary>
    public static IEnumerable<SKBitmap> Chunk(this SKBitmap bitmap, int chunkWidth, int chunkHeight)
    {
        var nChunksW = bitmap.Width / chunkWidth;
        var nChunksH = bitmap.Height / chunkHeight;

        for (var i = 0; i < nChunksH; i++)
        {
            for (var j = 0; j < nChunksW; j++)
            {
                var chunkBitmap = new SKBitmap(chunkWidth, chunkHeight);
                using var chunkCanvas = new SKCanvas(chunkBitmap);

                chunkCanvas.DrawBitmap(
                    bitmap,
                    new SKRect(
                        j * chunkWidth,
                        i * chunkHeight,
                        j * chunkWidth + chunkWidth,
                        i * chunkHeight + chunkHeight
                    ),
                    new SKRect(0, 0, chunkWidth, chunkHeight)
                );

                yield return chunkBitmap;
            }
        }
    }
}