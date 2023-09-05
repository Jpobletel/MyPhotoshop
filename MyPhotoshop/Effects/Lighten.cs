using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace MyPhotoshop.Effects;

public class Lighten:IPhotoEffect
{
    private readonly string _description = "Aclara la foto.";
    
    public string Description => _description;

    public Image<Rgb24> Apply(Image<Rgb24> originalImage)
    {
        int width = originalImage.Width;
        int height = originalImage.Height;
        Image<Rgb24> lightenImage = new Image<Rgb24>(width, height); 
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                int r = originalImage[i, j].R;
                int g = originalImage[i, j].G;
                int b = originalImage[i, j].B;

                int lR = r + 20;
                int lG = g + 20;
                int lB = b + 20;
                
                if (lR > 255) lR = 255;
                if (lG > 255) lG = 255;
                if (lB > 255) lB = 255;


                Byte lighterColorR = (Byte)(lR);
                Byte lighterColorG = (Byte)(lG);
                Byte lighterColorB = (Byte)(lB);
                lightenImage[i, j] = new Rgb24(lighterColorR, lighterColorG, lighterColorB);
            }   
        }

        return lightenImage;
    }
}