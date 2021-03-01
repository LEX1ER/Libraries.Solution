using QRCoder;
using System;
using System.IO;

namespace QR.Client.Library
{
    public class QRClient
    {
        string Code;
        byte[] Byte;
        string FullPath;
        string Ext = "png";

        public QRClient(string code)
        {
            Code = code;
        }
        public QRClient ToByte()
        {
            var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(Code, QRCodeGenerator.ECCLevel.Q);
            PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);
            Byte = qrCode.GetGraphic(20);
            return this;
        }
        public QRClient FolderLocation(string folder)
        {
            var qrFilePath = $"{folder}/{Code}.{Ext}";
            FullPath = Path.GetFullPath(qrFilePath);
            return this;
        }
        public QRClient ExtensionName(string ext)
        {
            Ext = ext;
            return this;
        }
        public void Save()
        {
            var folderDirectory = Path.GetDirectoryName(FullPath);

            if (!Directory.Exists(folderDirectory))
            {
                Directory.CreateDirectory(folderDirectory);
            }

            FileStream file = File.Create(FullPath);
            file.Write(Byte, 0, Byte.Length);
            file.Close();
        }
    }
}
