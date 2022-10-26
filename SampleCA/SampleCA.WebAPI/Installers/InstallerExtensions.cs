namespace SampleCA.WebAPI.Installers
{
    public static class InstallerExtensions
    {
        public static void InstallServiceInAssembly(this IServiceCollection services, IConfiguration configuration)
        {
            var installers = typeof(Program).Assembly.ExportedTypes.Where(k => typeof(IInstaller).IsAssignableFrom(k) && !k.IsInterface && !k.IsAbstract).Select(Activator.CreateInstance).Cast<IInstaller>().ToList();

            installers.ForEach(installer => installer.InstallService(configuration, services));
        }
    }
}