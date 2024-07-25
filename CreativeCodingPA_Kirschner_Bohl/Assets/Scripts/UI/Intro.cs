using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Intro : MonoBehaviour
{
    public AudioClip[] introAudios;
    public string[] subtitles;
    public AnimationClip fadeAway;
    private TMP_Text _text;
    private Image _textBox;
    private Animator _animator;
    private Animator _animatorBlackScreen;
    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animatorBlackScreen = GameObject.Find("BlackScreenForeground").GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _text = GameObject.Find("Subtitles").GetComponent<TMP_Text>();
        _textBox = GameObject.Find("Text_Background").GetComponent<Image>();
        _textBox.gameObject.SetActive(false);
        
        StartCoroutine(WaitForAudio());
    }

    IEnumerator WaitForAudio()
    {
       _animatorBlackScreen.SetTrigger("FadeAway");
        yield return new WaitForSeconds(fadeAway.length);

        _textBox.gameObject.SetActive(true);

        // https://discussions.unity.com/t/coroutines-inside-coroutines/733010/2
        yield return PlayAudioAndSetText(0);

        yield return PlayAudioAndSetText(1);

        yield return PlayAudioAndSetText(2);

        yield return PlayAudioAndSetText(3);

        yield return PlayAudioAndSetText(4);

        _text.gameObject.SetActive(false);
        _textBox.gameObject.SetActive(false);

        _animator.SetTrigger("FadeAway");
        yield return new WaitForSeconds(fadeAway.length);

        SceneManager.LoadScene(2);

    }

    private IEnumerator PlayAudioAndSetText(int index)
    {
        _audioSource.PlayOneShot(introAudios[index], 1);
        _text.text = subtitles[index];
        yield return new WaitForSeconds(introAudios[index].length);
    }
}
