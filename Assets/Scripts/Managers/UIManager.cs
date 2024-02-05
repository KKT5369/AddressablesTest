using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Managers
{
    public class UIManager : Singleton<UIManager>
    {
        private Transform _uiParent;
        private Dictionary<string,GameObject> _uiList = new();
        private bool _creatingUI;

        private void Awake()
        {
            if (!_uiParent)
            {
                _uiParent = new GameObject("UIContainer").transform;
            }
        }

        public void OpenUI<T>()
        {
            if (_creatingUI)
                return;
            
            var uiName = GetUIName<T>();
            if (_uiList.TryGetValue(uiName,out var ui))
            {
                ui.SetActive(true);
            }
            else
            {
                CreateUI<T>();
            }
        }

        async void CreateUI<T>()
        {
            _creatingUI = true;
            var uiName = GetUIName<T>();
            var handle = await ResourceLoadManager.Instance.LoadAsset<GameObject>(uiName);
            var go = handle.Result as GameObject;
            var uiGo = Instantiate(go,_uiParent);
            _uiList.Add(uiName,uiGo);
            _creatingUI = false;
        }


        public void CloseUI<T>()
        {
            var uiName = GetUIName<T>();
            if (_uiList.TryGetValue(uiName,out var ui))
            {
                ui.SetActive(false);
            }
        }

        public T GetUI<T>()
        {
            var uiName = GetUIName<T>();
            if (_uiList.TryGetValue(uiName,out var ui))
            {
                return ui.GetComponent<T>();
            }

            return default;
        }

        string GetUIName<T>()
        {
            return typeof(T).Name;
        }

        public void ClearUI()
        {
            foreach (var v in _uiList)
            {
                Destroy(v.Value);
            }
            _uiList.Clear();
        }
    }
}