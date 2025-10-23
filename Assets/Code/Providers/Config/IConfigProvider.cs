using Code.Config;

namespace Code.Providers.Config
{
    public interface IConfigProvider
    {
        void Initialize();
        GridData GetGridData();
        CubeConfig GetCubeConfig();
    }
}