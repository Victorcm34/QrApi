using System.Drawing;
using System.IO;
using QrApi.Interfaces;
using QRCoder;

namespace QrApi.Services
{
    public class QrServices : IQrGen
    {
        public byte[] GenByteArray(string url)
        {
            Image image = GenImage(url);
            return ImgToByte(image);
        }

        public Bitmap GenImage(string url)
        {
            QRCodeGenerator qrGen = new QRCodeGenerator();
            QRCodeData qrData = qrGen.CreateQrCode(url, QRCodeGenerator.ECCLevel.M);
            QRCode qrCode = new QRCode(qrData);
            Bitmap qrImage = qrCode.GetGraphic(10);
            return qrImage;
        }

        public byte[] ImgToByte(Image img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
    }
}