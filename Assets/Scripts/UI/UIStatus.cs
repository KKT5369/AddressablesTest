using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIStatus : MonoBehaviour
    {
        [SerializeField] private RectTransform[] categoryList;
        [SerializeField] private GameObject[] categoryUi;
        private RectTransform _selectCategory;
        private GameObject _selectCategoryUI;
        
        
        private void Awake()
        {
            SetAddListener();
        }

        void SetAddListener()
        {
            for (int i = 0; i < categoryList.Length; i++)
            {
                var v = categoryList[i];
                var go = categoryUi[i];
                var btn = v.GetComponent<Button>();
                btn.onClick.AddListener((() =>
                {
                    if (_selectCategory)
                    {
                        _selectCategory.DOAnchorPosX(15, 0.5f);
                        _selectCategoryUI.SetActive(false);
                    }
                    v.DOAnchorPosX(45f, 0.5f);
                    go.SetActive(true);
                    _selectCategory = v;
                    _selectCategoryUI = go;
                }));
            }
        }
        
    }
}
