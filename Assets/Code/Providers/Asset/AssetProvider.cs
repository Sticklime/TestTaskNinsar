using UnityEngine;

namespace Code.Providers.Asset
{
    public class AssetProvider : IAssetProvider
    {
        public TComponent Instantiate<TComponent>(string path, Vector3 at) where TComponent : Object
        {
            TComponent prefab = Resources.Load<TComponent>(path);
            return Object.Instantiate(prefab, at, Quaternion.identity);
        }
    }
}