using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Intro : MonoBehaviour
{
    // Array of audio files
    public AudioClip[] introAudios;

    // Array of strings to be showns as subtitles
    public string[] subtitles;

    // Reference to the animation clip
    public AnimationClip fadeAway;

    // The subtitles
    private TMP_Text _text;

    // The box behind the subtitles
    private Image _textBox;

    // Reference to the animator
    private Animator _animator;

    // Reference to the BlackScreen-Animator
    private Animator _animatorBlackScreen;

    // Reference to the audio source
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

    // Coroutine for the intro monologue
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

    // Play audio and set the subtitles
    private IEnumerator PlayAudioAndSetText(int index)
    {
        _audioSource.PlayOneShot(introAudios[index], 1);
        _text.text = subtitles[index];
        yield return new WaitForSeconds(introAudios[index].length);
    }
}
