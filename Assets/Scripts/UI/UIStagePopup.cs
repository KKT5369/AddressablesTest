using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStagePopup : MonoBehaviour
{
    [SerializeField] private Animator stageAnim;
    private Image _imgStage;
    private Sprite _spriteStage;
    private Coroutine _animCo;

    private void Awake()
    {
        _imgStage = stageAnim.GetComponent<Image>();
        _spriteStage = _imgStage.sprite;
    }

    private void OnEnable()
    {
        _animCo = StartCoroutine(nameof(TestCo));
    }

    private void OnDisable()
    {
        if (_animCo != null)
        {
            StopCoroutine(_animCo);
        }
            
        stageAnim.Rebind();
        _imgStage.sprite = _spriteStage;
    }

    IEnumerator TestCo()
    {
        stageAnim.enabled = false;
        yield return new WaitForSeconds(3f);
        stageAnim.enabled = true;
    }
}
