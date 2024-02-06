using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIStagePopup : MonoBehaviour
{
    [SerializeField] private Animator stageAnim;
    [SerializeField] private TMP_Text txtStageName;
    [SerializeField] private float time;
    
    private Image _imgStage;
    private Sprite _spriteStage;
    private Coroutine _animCo;

    private void Awake()
    {
        _imgStage = stageAnim.GetComponent<Image>();
        _spriteStage = _imgStage.sprite;
    }

    private void Update()
    {
        if (stageAnim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1) 
        {
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        _animCo = StartCoroutine(nameof(TestCo));
        //todo 매니저 통해 지역 정보 가져오기
        // txtStageName.text = 지역이름 
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
        yield return new WaitForSeconds(time);
        stageAnim.enabled = true;
    }
}
