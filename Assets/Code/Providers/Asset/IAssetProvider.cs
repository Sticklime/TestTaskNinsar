using UnityEngine;

namespace Code.Providers.Asset
{
    public interface IAssetProvider
    {
        TComponent Instantiate<TComponent>(string path, Vector3 at) where TComponent : Object;
    }
}