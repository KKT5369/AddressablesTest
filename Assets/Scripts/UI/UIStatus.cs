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
        private RectTransform _selectCategory;
        
        private void Awake()
        {
            foreach (var v in categoryList)
            {
                var btn = v.GetComponent<Button>();
                btn.onClick.AddListener((() =>
                {
                    if (_selectCategory)
                    {
                        _selectCategory.DOAnchorPosX(15, 0.5f);
                    }
                    v.DOAnchorPosX(45f, 0.5f);
                    _selectCategory = v;
                }));
            }
        }
    }
}
