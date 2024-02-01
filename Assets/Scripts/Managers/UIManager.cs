using System;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class UIManager : Singleton<UIManager>
    {
        private Transform _uiParent;
        private Dictionary<string,GameObject> _uiList = new();


        private void Awake()
        {
            if (!_uiParent)
            {
                _uiParent = new GameObject("UIContainer").transform;
            }
        }

        public void OpenUI<T>()
        {
            var openUiName = typeof(T).Name;
            if (_uiList.TryGetValue(openUiName,out var ui))
            {
                ui.SetActive(true);
            }
        }

        void CreateUI<T>()
        {
            var openUiName = typeof(T).Name;
            ResourceLoadManager.Instance.LoadAsset<GameObject>(openUiName, (handle =>
            {
                var result = handle.Result as GameObject;
                var uiGo = Instantiate(result,_uiParent);
                _uiList.Add(openUiName, uiGo);
            }));
        }


        public void CloseUI<T>()
        {
            var closeUiName = typeof(T).Name;
            if (_uiList.TryGetValue(closeUiName,out var ui))
            {
                ui.SetActive(false);
            }
        }

        public void GetUI<T>()
        {
            
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