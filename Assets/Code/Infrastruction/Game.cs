using Code.Providers.Asset;
using Code.Providers.Config;

namespace Code.Infrastruction
{
    public class Game
    {
        private readonly IConfigProvider _configProvider;
        private readonly IAssetProvider _assetProvider;

        public Game(IConfigProvider configProvider, IAssetProvider assetProvider)
        {
            _configProvider = configProvider;
            _assetProvider = assetProvider;
        }

        public void StartGame()
        {
            LevelLoader levelLoader = new LevelLoader(_configProvider, _assetProvider);

            levelLoader.InitLevel();
        }
    }
}