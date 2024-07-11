using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class SongBlending : MonoBehaviour
{
    public AudioClip relaxedAudio;

    public AudioClip thrillingAudio;

    public float _reductionRate;

    
    private DamageController _damageController;

    private AudioSource _audioSource;

    


    
    // Start is called before the first frame update
    void Start()
    {
        _damageController = GameObject.Find("Player").GetComponent<DamageController>();

        _audioSource = GetComponent<AudioSource>();
    }


    private void Update()
    {
        if (_damageController.lifePoints <= 0.33f)
        {
            
            //StartCoroutine(SetThrillingAudio());
        }
        if (_damageController.lifePoints > 0.33f)
        {
            //StartCoroutine(SetRelaxedAudio());
        }
    }
    IEnumerator SetThrillingAudio()
    {
        // https://forum.unity.com/threads/audio-crossfade-how.144606/
        while (_audioSource.volume > 0.0f)
        {
            _audioSource.volume = Mathf.Lerp(1.0f, 0.0f, _reductionRate * Time.deltaTime);
        }
        _audioSource.volume = Mathf.Lerp(1.0f, 0.0f, _reductionRate * Time.deltaTime);
        // https://docs.unity3d.com/ScriptReference/WaitUntil.html
        yield return new WaitUntil(() => _audioSource.volume <= 0.0f);
        _audioSource.clip = thrillingAudio;
        while (_audioSource.volume < 1.0f)
        {
            _audioSource.volume = Mathf.Lerp(0.0f, 1.0f, _reductionRate * Time.deltaTime);
        }
    }

    IEnumerator SetRelaxedAudio()
    {

        // https://forum.unity.com/threads/audio-crossfade-how.144606/
        while (_audioSource.volume > 0.0f)
        {
            _audioSource.volume = Mathf.Lerp(1.0f, 0.0f, _reductionRate * Time.deltaTime);
        }  
        // https://docs.unity3d.com/ScriptReference/WaitUntil.html
        yield return new WaitUntil(() => _audioSource.volume <= 0.0f);
        _audioSource.clip = relaxedAudio;
        while(_audioSource.volume < 1.0f)
        {
            _audioSource.volume = Mathf.Lerp(0.0f, 1.0f, _reductionRate * Time.deltaTime);
        }
    }
}
