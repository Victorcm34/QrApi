using System.Drawing;

namespace QrApi.Interfaces
{
    public interface IQrGen
    {
         public byte[] GenByteArray(string url);
         public Bitmap GenImage(string url);
         public byte[] ImgToByte(Image img);
    }
}