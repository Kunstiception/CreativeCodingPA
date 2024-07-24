using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutroTrigger : MonoBehaviour
{
    public AnimationClip fadeAway;
    private Animator _animator;
    private DamageController _damageController;

    private void Start()
    {
        _animator = GameObject.Find("OutroFadeToBlack").GetComponent<Animator>();
        _damageController = GameObject.Find("Player").GetComponent<DamageController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _damageController.isInvincible = true;
            StartCoroutine(WaitForAnimation());
        }
    }

    IEnumerator WaitForAnimation()
    {
        _animator.SetTrigger("FadeAway");

        yield return new WaitForSeconds(fadeAway.length);
        SceneManager.LoadScene(3);
    }
}