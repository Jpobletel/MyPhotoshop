using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace MyPhotoshop.Effects;

public class Darken:IPhotoEffect
{
    private readonly string _description = "Oscurece la foto.";

    public string Description => _description;

    public Image<Rgb24> Apply(Image<Rgb24> originalImage)
    {
        int width = originalImage.Width;
        int height = originalImage.Height;
        
        Image<Rgb24> darkenImage = new Image<Rgb24>(width, height); 
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                int r = originalImage[i, j].R;
                int g = originalImage[i, j].G;
                int b = originalImage[i, j].B;

                int dR = r - 20;
                int dG = g - 20;
                int dB = b - 20;
                
                if (dR < 0) dR = 0;
                if (dG < 0) dG = 0;
                if (dB < 0) dB = 0;

                Byte darkerColorR = (Byte)(dR);
                Byte darkerColorG = (Byte)(dG);
                Byte darkerColorB = (Byte)(dB);
                
                darkenImage[i, j] = new Rgb24(darkerColorR, darkerColorG, darkerColorB);
            }   
        }

        return darkenImage;
    }
}