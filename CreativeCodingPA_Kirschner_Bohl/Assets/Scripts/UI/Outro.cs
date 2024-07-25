using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Outro : MonoBehaviour
{
    public AudioClip[] outroAudios;
    public string[] subtitles;
    public AnimationClip fadeAway;
    public AnimationClip fadeToBlack;
    private TMP_Text _text;
    private Image _textBox;
    private Animator _animator;
    private Animator _animatorBlackScreen;
    private AudioSource _audioSource;
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

    private IEnumerator PlayAudioAndSetText(int index)
    {
        _audioSource.PlayOneShot(outroAudios[index], 1);
        _text.text = subtitles[index];
        yield return new WaitForSeconds(outroAudios[index].length);
    }
}
