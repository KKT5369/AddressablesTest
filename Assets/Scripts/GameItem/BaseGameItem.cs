using DG.Tweening;
using Managers;
using UnityEngine;

namespace GameItem
{
    public class BaseGameItem : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _spriteRenderer.transform.DOMoveY(0.5f, 2f).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.Linear);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                var randomNum = Random.Range(15, 26);
                _spriteRenderer.sprite = GameManager.Instance.GameItemAtlas.GetSprite(randomNum.ToString());
            }
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (!col.gameObject.tag.Equals("Player"))
                return;
            
        }

        public virtual void TriggerAction(){}

    }
}