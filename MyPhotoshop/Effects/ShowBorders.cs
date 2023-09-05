using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace MyPhotoshop.Effects;

public class ShowBorders:IPhotoEffect
{
    private readonly string _description = "muestra los bordes de la foto.";
    
    public string Description
    {
        get { return _description; }
    }

    public Image<Rgb24> Apply(Image<Rgb24> originalImage)
    {
        int width = originalImage.Width;
        int height = originalImage.Height;
        Image<Rgb24> borderImage = new Image<Rgb24>(width, height); 
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
                    if (list[0] > 0 && list[1] < height && list[0] < width && list[1] > 0)
                    {
                        int[] pain = new int[2] {list[0], list[1]};
                        posFiltradas.Add(pain);
                    }
                }
                
                int r = originalImage[i, j].R;
                int g = originalImage[i, j].G;
                int b = originalImage[i, j].B;

                int rPromedio = 9*r ;
                int gPromedio = 9*g;
                int bPromedio = 9*b;
                    
                

                foreach (var hola in posFiltradas)
                {
                    int rChico = originalImage[hola[0], hola[1]].R;
                    int gChico = originalImage[hola[0], hola[1]].G;
                    int bChico = originalImage[hola[0], hola[1]].B;

                    rPromedio = rPromedio - rChico;
                    gPromedio = gPromedio - gChico;
                    bPromedio = bPromedio - bChico;

                }

                if (rPromedio < 0 )
                {
                    rPromedio = 0;
                }
                if (gPromedio < 0 )
                {
                    gPromedio = 0;
                }
                if (bPromedio < 0 )
                {
                    bPromedio = 0;
                }
                if (rPromedio > 255 )
                {
                    rPromedio = 255;
                }
                if (gPromedio > 255 )
                {
                    gPromedio = 255;
                }
                if (bPromedio > 255 )
                {
                    bPromedio = 255;
                }
                


                Byte averageColorR = (Byte)( rPromedio);
                Byte averageColorG = (Byte)( gPromedio);
                Byte averageColorB = (Byte)( bPromedio);
                borderImage[i, j] = new Rgb24(averageColorR,averageColorG,averageColorB);
            }   
        }

        return borderImage;
    }
}