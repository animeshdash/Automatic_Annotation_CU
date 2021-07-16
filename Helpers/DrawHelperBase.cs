using System;
using System.Drawing;
using Automatic_Annotation_CU.Models;


namespace Automatic_Annotation_CU.Helpers
{
    public static class DrawHelperBase
    {

        public static Image DrawBoxes(AnnotationImage image)
        {
            try
            {
                var originalBitmap = new Bitmap(image.ImagePath);

                var newImageSize = new Size(originalBitmap.Width, originalBitmap.Height);
                if (originalBitmap.Width > ImageSize.Width)
                {
                    newImageSize.Height = (int)(originalBitmap.Height * (ImageSize.Width / (double)originalBitmap.Width));
                    newImageSize.Width = ImageSize.Width;
                }
                if (originalBitmap.Height > ImageSize.Height)
                {
                    newImageSize.Width = (int)(originalBitmap.Width * (ImageSize.Height / (double)originalBitmap.Height));
                    newImageSize.Height = ImageSize.Height;
                }

                var resizedBitmap = new Bitmap(originalBitmap, newImageSize);
                foreach (var id in originalBitmap.PropertyIdList)
                {
                    resizedBitmap.SetPropertyItem(originalBitmap.GetPropertyItem(id));
                }

                originalBitmap.Dispose();

                return resizedBitmap;
            }
            catch (Exception exception)
            {
                var bitmap = new Bitmap(ImageSize.Width, ImageSize.Height);
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    graphics.Clear(Color.White);
                    graphics.DrawString(exception.Message, new Font("Arial", 12), Brushes.Black, 50, 50);
                }

                return bitmap;
            }
        }
    }
}