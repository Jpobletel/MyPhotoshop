using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace MyPhotoshop.Effects;

public class Reflect:IPhotoEffect
{
    private readonly string _description = "Refleja la foto.";
    
    public string Description => _description;

    public Image<Rgb24> Apply(Image<Rgb24> originalImage)
    {
        int width = originalImage.Width;
        int height = originalImage.Height;
        Image<Rgb24> reflectImage = new Image<Rgb24>(width, height); 
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                reflectImage[width-i-1, j] = new Rgb24(originalImage[i, j].R, originalImage[i, j].G, originalImage[i, j].B);
            }   
        }

        return reflectImage;
    }
}