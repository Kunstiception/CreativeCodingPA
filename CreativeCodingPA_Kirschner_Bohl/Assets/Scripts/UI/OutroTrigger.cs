using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutroTrigger : MonoBehaviour
{
    // Reference to the animation clip
    public AnimationClip fadeAway;

    // Reference to the animator
    private Animator _animator;

    // Reference to the damage controller script
    private DamageController _damageController;

    private void Start()
    {
        _animator = GameObject.Find("OutroFadeToBlack").GetComponent<Animator>();
        _damageController = GameObject.Find("Player").GetComponent<DamageController>();
    }

    // Make the player invincible and start the coroutine to end the game
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _damageController.isInvincible = true;
            StartCoroutine(WaitForAnimation());
        }
    }

    // Wait until the animation has finished and load the final scene
    IEnumerator WaitForAnimation()
    {
        _animator.SetTrigger("FadeAway");

        yield return new WaitForSeconds(fadeAway.length);
        SceneManager.LoadScene(3);
    }
}