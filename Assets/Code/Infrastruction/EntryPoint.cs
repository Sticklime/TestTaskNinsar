using Code.Providers.Asset;
using Code.Providers.Config;
using UnityEngine;

namespace Code.Infrastruction
{
    public class EntryPoint : MonoBehaviour
    {
        private void Awake()
        {
            IConfigProvider configProvider = new ConfigProvider();
            IAssetProvider assetProvider = new AssetProvider();

            configProvider.Initialize();

            Game game = new Game(configProvider, assetProvider);
            game.StartGame();
        }
    }
}