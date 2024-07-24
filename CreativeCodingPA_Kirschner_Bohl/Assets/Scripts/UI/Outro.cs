using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Outro : MonoBehaviour
{
    public AudioClip outroAudio;
    public AnimationClip fadeAway;
    public AnimationClip fadeToBlack;
    private Animator _animator;
    private Animator _fadeToBlackAnimator;
    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _fadeToBlackAnimator = GameObject.Find("FadeToBlack").GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        StartCoroutine(WaitForAudio());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator WaitForAudio()
    {
        _animator.SetTrigger("FadeAway");

        yield return new WaitForSeconds(fadeAway.length);
        _audioSource.PlayOneShot(outroAudio, 1);


        yield return new WaitForSeconds(outroAudio.length);
        _fadeToBlackAnimator.SetTrigger("FadeAway");

        yield return new WaitForSeconds(fadeToBlack.length);
        SceneManager.LoadScene(0);


    }
}
