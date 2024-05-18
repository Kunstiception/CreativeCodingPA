using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSourceHealing : MonoBehaviour
{
    // Reference to the Lightsource belonging to this collider
    public Light _correspondingLightsource;
    
    // Reference to the player object
    private GameObject _player;

    // Reference to the damage controller script
    private DamageController _damageController;
    
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
            _damageController.inLight = true;
        }

        if(other.gameObject == _player && _damageController.isFullHealth == true)
        {
            _damageController.inLight = false;
            _correspondingLightsource.enabled = false;
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _damageController.inLight = false;
    }

}
