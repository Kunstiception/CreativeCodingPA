using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSourceHealing : MonoBehaviour
{
    // Reference to the player object
    private GameObject _player;

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
    }

    private void OnTriggerExit(Collider other)
    {
        _damageController.inLight = false;
    }

}
