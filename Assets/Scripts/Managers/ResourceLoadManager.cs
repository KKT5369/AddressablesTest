using System;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Managers
{
    public class ResourceLoadManager : Singleton<ResourceLoadManager>
    {
        public async void LoadAsset<T>(string address, Action<AsyncOperationHandle> callback)
        {
            var handle = Addressables.LoadAssetAsync<T>(address);
            await UniTask.WaitUntil((() => handle.IsDone));
            callback.Invoke(handle);
        }
        
        public async UniTask<AsyncOperationHandle> LoadAsset<T>(string address)
        {
            var handle = Addressables.LoadAssetAsync<T>(address);
            await UniTask.WaitUntil((() => handle.IsDone));
            return handle;
        }
    }
    
}