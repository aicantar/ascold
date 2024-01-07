using Ascold.Colorizer;
using Ascold.Converter;
using SkiaSharp;

const string Ramp = "$@B%8&WM#*oahkbdpqwmZO0QLCJUYXzcvunxrjft/|()1{}[]?-_+~<>i!lI;:,\"^`\\'. ";

// TODO(@aicantar): use proper DI container and argument parser, add `--no-color` argument, better edge case handling.

if (args.Length == 0)
{
    Console.Error.WriteLine("Must provide a file path for conversion.");
    return;
}

var filePath = args[0];

if (!File.Exists(filePath))
{
    Console.Error.WriteLine("File {0} does not exist.", filePath);
    return;
}

// Don't colorize output if redirected to file.
var converter = Console.IsOutputRedirected
    ? new ChunkedConverter(
        new RampedConverter(Ramp)
    )
    : new ChunkedConverter(
        new ColorizingConverter(
            new RgbAnsiColorizer(),
            new RampedConverter(Ramp)
        )
    );

using var file = File.OpenRead(filePath);
var bitmap = SKBitmap.Decode(file);

Console.WriteLine(converter.BitmapToAscii(bitmap));