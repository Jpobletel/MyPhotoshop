using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace MyPhotoshop.Effects;

public class Rotate:IPhotoEffect
{
    private readonly string _description = "Rota en 90º la foto.";
    
    public string Description => _description;

    public Image<Rgb24> Apply(Image<Rgb24> originalImage)
    {
        int width = originalImage.Width;
        int height = originalImage.Height;
        Image<Rgb24> rotateImage = new Image<Rgb24>(height, width);
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                rotateImage[height - j - 1, i] =
                    new Rgb24(originalImage[i, j].R, originalImage[i, j].G, originalImage[i, j].B);
            }
        }
        return rotateImage;
    }
}