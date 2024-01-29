using QRCoder;
using Service.Contracts;

namespace Service
{
    public class QRCodeGeneratorService : IQRCodeGeneratorService
    {
        public byte[] GenerateQRCode(Guid guid, string host, string path)
        {
            string url = host + path + guid;
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
            BitmapByteQRCode qrCode = new BitmapByteQRCode(qrCodeData);
            return qrCode.GetGraphic(20);
        }
    }
}
