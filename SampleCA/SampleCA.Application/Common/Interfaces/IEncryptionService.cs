namespace SampleCA.Application.Common.Interfaces
{
    public interface IEncryptionService
    {
        string CreateSaltKey();
        string CreatePasswordHash(string password, string saltstring);
    }
}