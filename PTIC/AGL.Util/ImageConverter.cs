/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2015/03/21 (yyyy/MM/dd)
 * Description: Utility class for image conversion
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace PTIC.Util
{
    /// <summary>
    /// Image conversion utility
    /// </summary>
    public class ImageConverter
    {
        /// <summary>
        /// Convert Image to byte array
        /// </summary>
        /// <param name="imageIn">Image</param>
        /// <returns>Byte array</returns>
        public static byte[] ToByteArray(Image imageIn)
        {
            if (imageIn == null)
                return null;
            MemoryStream ms = new MemoryStream();
            try
            {
                imageIn.Save(ms, imageIn.RawFormat);
            }
            catch (Exception ex) // RawFormat cannot be determined / Encoder is null
            {
                // JPEG as default
                imageIn.Save(ms, ImageFormat.Jpeg);
            }

            return ms.ToArray();
        }

        /// <summary>
        /// Convert byte array to image
        /// </summary>
        /// <param name="byteArrayIn">Byte array</param>
        /// <returns>Image</returns>
        public static Image ToImage(byte[] byteArrayIn)
        {
            if (byteArrayIn == null)
                return null;
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image img = Image.FromStream(ms);
            return img;
        }

    }
}
