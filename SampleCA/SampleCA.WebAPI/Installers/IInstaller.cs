namespace SampleCA.WebAPI.Installers
{
    public interface IInstaller
    {
        void InstallService(IConfiguration configuration, IServiceCollection service);
    }
}