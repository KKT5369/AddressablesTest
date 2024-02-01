using System;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Managers
{
    public class ResourceLoadManager : Singleton<ResourceLoadManager>
    {

        public async void LoadAsset<T>(string add, Action<AsyncOperationHandle> callback)
        {
            var handle = Addressables.LoadAssetAsync<T>(add);
            await UniTask.WaitUntil((() => handle.IsDone));
            callback.Invoke(handle);
        }

    }
}