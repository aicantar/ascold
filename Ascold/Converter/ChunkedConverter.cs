using Ascold.Extensions;
using SkiaSharp;

namespace Ascold.Converter;

public class ChunkedConverter(IConverter baseConverter) : IConverter
{
    private const int ChunkWidth = 5, ChunkHeight = 12, ImageHeight = ChunkHeight * 40;

    public string BitmapToAscii(SKBitmap bitmap) =>
        string.Join(
            "",
            ResizeIfNeeded(bitmap)
                .Chunk(ChunkWidth, ChunkHeight)
                .Select((chunk, idx) =>
                {
                    var ascii = baseConverter.BitmapToAscii(chunk);
                    var nChunksW = bitmap.Width / ChunkWidth;

                    return string.Format(
                        "{0}{1}",
                        ascii,
                        (idx + 1) % nChunksW == 0
                            ? "\n"
                            : ""
                    );
                })
        );

    private SKBitmap ResizeIfNeeded(SKBitmap bitmap) =>
        bitmap.Height > ImageHeight
            ? bitmap.ResizeHWithAspectRatio(ImageHeight)
            : bitmap;
}