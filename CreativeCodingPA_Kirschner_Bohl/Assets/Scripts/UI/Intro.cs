using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    public AudioClip introAudio;
    public AnimationClip fadeAway;
    private Animator _animator;
    private Animator _animatorBlackScreen;
    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animatorBlackScreen = GameObject.Find("BlackScreenForeground").GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        
        StartCoroutine(WaitForAudio());
    }

    IEnumerator WaitForAudio()
    {
       _animatorBlackScreen.SetTrigger("FadeAway");

        yield return new WaitForSeconds(fadeAway.length);

        _audioSource.PlayOneShot(introAudio, 1);
        
        yield return new WaitForSeconds(introAudio.length);

        _animator.SetTrigger("FadeAway");

        yield return new WaitForSeconds(fadeAway.length);

        SceneManager.LoadScene(2);

    }
}
