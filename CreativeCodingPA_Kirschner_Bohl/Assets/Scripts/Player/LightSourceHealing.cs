using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSourceHealing : MonoBehaviour
{
    // Reference to the Lightsource belonging to this collider
    public Light _correspondingLightsource;

    //the sound that plays when player is being healed
    public AudioClip lightSourceHeal;

    // Reference to the player object
    private GameObject _player;

    // Reference to the damage controller script
    private DamageController _damageController;

    // Bool to control how often the healing sound will be played
    private bool _hasPlayed;
    
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
        _damageController = _player.GetComponent<DamageController>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == _player)
        {
            _damageController.isInLight = true;
            if(!_hasPlayed)
            {
                _player.GetComponent<AudioSource>().PlayOneShot(lightSourceHeal);
                _hasPlayed = true;
            }
            
        }

        if(other.gameObject == _player && _damageController.isFullHealth == true)
        {
            _damageController.isInLight = false;
            _correspondingLightsource.enabled = false;
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _damageController.isInLight = false;
    }

}
