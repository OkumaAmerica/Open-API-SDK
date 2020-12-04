
namespace EasyToolData_TestApp
{
    using System.IO;
    using System.Drawing;
    using System.Windows.Media.Imaging;


    public static class Extensions
    {
        public static BitmapImage PngToWpfImage(this System.Drawing.Image img)
        {
            Bitmap dImg = new System.Drawing.Bitmap(img);
            MemoryStream ms = new MemoryStream();
            dImg.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

            BitmapImage bImg = new System.Windows.Media.Imaging.BitmapImage();
            bImg.BeginInit();
            bImg.StreamSource = new MemoryStream(ms.ToArray());
            bImg.EndInit();
            return bImg;
        }


        public static BitmapImage BmpToWpfImage(this System.Drawing.Bitmap bmp)
        {
            MemoryStream ms = new MemoryStream(); 
            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);

            BitmapImage ix = new BitmapImage();
            ix.BeginInit();
            ix.CacheOption = BitmapCacheOption.OnLoad;
            ix.StreamSource = ms;
            ix.EndInit();
            return ix;
        }

    }
}
