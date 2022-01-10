using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System;

class GFG
{
    public int PowerMod(int p, int e, int n)
    {
        int r2 = 1;
        int r1 = 0;
        int Q = 0;
        int R = 0;

        while (e != 0)
        {
            R = (e % 2);
            Q = ((e - R) / 2);

            r1 = ((p * p) % n);

            if (R == 1)
            {
                r2 = ((r2 * p) % n);
            }
            p = r1;
            e = Q;
        }
        return r2;
    }

    public Bitmap Encrypt(string filePath, int e, int n)
    {
        Bitmap img = new Bitmap(filePath);

        Bitmap newImg = new Bitmap(img.Width, img.Height);
        StreamWriter sw = new StreamWriter("D:\\Output.txt");

        for (int i = 0; i < img.Width; i++)
        {
            for (int j = 0; j < img.Height; j++)
            {
                Color pixel = img.GetPixel(i, j);

                int r = PowerMod(pixel.R, e, n);
                int b = PowerMod(pixel.B, e, n); 
                int g = PowerMod(pixel.G, e, n);
                
                sw.WriteLine((r / 256).ToString() + ' ' + (b / 256).ToString() + ' ' + (g / 256).ToString());

                r = r % 256;
                b = b % 256;
                g = g % 256;

                Color newColor = Color.FromArgb(r, g, b);
                newImg.SetPixel(i, j, newColor);
            }
        }
        sw.Close();
        newImg.Save("D:\\Output.png");
        return newImg;
    }

    public Bitmap Decrypt(string filePath, int d, int n)
    {
        
        StreamReader sr = new StreamReader("D:\\Output.txt");

        Bitmap img = new Bitmap(filePath);
        Bitmap newImg = new Bitmap(img.Width, img.Height);

        string line;
        for (int i = 0; i < img.Width; i++)
        {
            for (int j = 0; j < img.Height; j++)
            {
                Color pixel = img.GetPixel(i, j);
                line = sr.ReadLine();
                string[] with = line.Split(' ');
                int r1 = int.Parse(with[0]);
                int r2 = int.Parse(with[1]);
                int r3 = int.Parse(with[2]);

                int r = pixel.R + (256 * r1);
                int b = pixel.B + (256 * r2);
                int g = pixel.G + (256 * r3);

                r = PowerMod(r, d, n);
                b = PowerMod(b, d, n);
                g = PowerMod(g, d, n);

                r = r % 256;
                b = b % 256;
                g = g % 256;

                Color newColor = Color.FromArgb(r, g, b);
                newImg.SetPixel(i, j, newColor);
            }
        }
        sr.Close();
        newImg.Save("D:\\Output1.png");
        return newImg;
    }
}