namespace Service.Contracts
{
    public interface IQRCodeGeneratorService
    {
        public byte[] GenerateQRCode(Guid guid, string host, string path);
    }
}
