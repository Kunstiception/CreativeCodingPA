using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Outro : MonoBehaviour
{
    // Array of audio files
    public AudioClip[] outroAudios;

    // Array of strings to be showns as subtitles
    public string[] subtitles;

    // Reference to the animation clip
    public AnimationClip fadeAway;

    // Reference to the fadetoblack animation clip
    public AnimationClip fadeToBlack;

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

    // Reference to the fadetoblack-animator
    private Animator _fadeToBlackAnimator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _fadeToBlackAnimator = GameObject.Find("FadeToBlack").GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _text = GameObject.Find("Subtitles").GetComponent<TMP_Text>();
        _textBox = GameObject.Find("Text_Background").GetComponent<Image>();
        StartCoroutine(WaitForAudio());
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Coroutine for the outro monologue
    IEnumerator WaitForAudio()
    {
        _animator.SetTrigger("FadeAway");
        yield return new WaitForSeconds(fadeAway.length);

        _textBox.gameObject.SetActive(true);

        yield return PlayAudioAndSetText(0);

        yield return PlayAudioAndSetText(1);
        
        _text.gameObject.SetActive(false);
        _textBox.gameObject.SetActive(false);

        _fadeToBlackAnimator.SetTrigger("FadeAway");
        yield return new WaitForSeconds(fadeToBlack.length);

        SceneManager.LoadScene(0);


    }

    // Play audio and set the subtitles
    private IEnumerator PlayAudioAndSetText(int index)
    {
        _audioSource.PlayOneShot(outroAudios[index], 1);
        _text.text = subtitles[index];
        yield return new WaitForSeconds(outroAudios[index].length);
    }
}
