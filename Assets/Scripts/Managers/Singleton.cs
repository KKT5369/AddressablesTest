using Unity.VisualScripting;
using UnityEngine;

namespace Managers
{
    public class Singleton<T> : MonoBehaviour, ISingleton where T : Component
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    var go = new GameObject(typeof(T).Name);
                    _instance = go.AddComponent<T>();
                }

                return _instance;
            }
        }
    }
}