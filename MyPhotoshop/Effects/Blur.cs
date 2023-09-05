using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace MyPhotoshop.Effects;

public class Blur:IPhotoEffect
{
    private readonly string _description = "Difumina la foto.";
    
    public string Description => _description;

    public Image<Rgb24> Apply(Image<Rgb24> originalImage)
    {
        int width = originalImage.Width;
        int height = originalImage.Height;
        Image<Rgb24> blurImage = new Image<Rgb24>(width, height); 
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            { 
                List<int>[] posiciones = new List<int>[9];
                posiciones[0] = new List<int> {i--, j--};
                posiciones[1] = new List<int> {i--, j};
                posiciones[2] = new List<int> {i--, j++};
                posiciones[3] = new List<int> {i, j--};
                posiciones[4] = new List<int> {i, j};
                posiciones[5] = new List<int> {i, j++};
                posiciones[6] = new List<int> {i++, j--};
                posiciones[7] = new List<int> { i++, j };
                posiciones[8] = new List<int> { i++, j++ };
                
                List<int[]> posFiltradas = new List<int[]>();
                
                foreach(var list in posiciones)
                {
                    if (list[0] > 0 && list[1] <= height && list[0] <= width && list[1] > 0)
                    {
                        int[] pain = new int[2] {list[0], list[1]};
                        posFiltradas.Add(pain);
                    }
                }

                int rPromedio = 0;
                int gPromedio = 0;
                int bPromedio = 0;
                
                foreach (var hola in posFiltradas)
                {
                    int r = originalImage[hola[0], hola[1]].R;
                    int g = originalImage[hola[0], hola[1]].G;
                    int b = originalImage[hola[0], hola[1]].B;

                    rPromedio += r;
                    gPromedio += g;
                    bPromedio += b;

                }

                Byte averageColorR = (Byte)( rPromedio / 9);
                Byte averageColorG = (Byte)( gPromedio / 9);
                Byte averageColorB = (Byte)( bPromedio / 9);
                blurImage[i, j] = new Rgb24(averageColorR,averageColorG,averageColorB);
            }   
        }

        return blurImage;
    }
}