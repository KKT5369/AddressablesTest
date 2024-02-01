using System;
using System.Collections;
using UnityEngine;

namespace UI
{
    public class UITest : MonoBehaviour
    {
        [SerializeField] private Animator stageAnim;

        private void Awake()
        {
            StartCoroutine(nameof(TestCo));
        }
        
        IEnumerator TestCo()
        {
            stageAnim.enabled = false;
            yield return new WaitForSeconds(3f);
            stageAnim.enabled = true;
        }
        
    }
}