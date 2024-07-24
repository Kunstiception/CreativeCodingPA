using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{

    private GameObject _player;
    // References the Player Controller Script
    private PlayerController _playerController;

    // How long has the player been boosted for
    private float boostTime;

    // Checks if the player is boosted or not
    public bool isBoosted;

    //the sound that plays when player gets a speedboost
    public AudioClip speedBoost;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
        _playerController = _player.GetComponent<PlayerController>();
        
        // Default state of the player when not boosted
        _playerController.speed = 6;
        boostTime = 0;
        _playerController.isBoosted = false;
    }
       // Boost when player touches the speedboost object; also destroys it
    void OnTriggerEnter(Collider other)
    {
        _playerController.isBoosted = true;
        _playerController.speed = 12;
        _player.GetComponent<AudioSource>().PlayOneShot(speedBoost);
        Destroy(gameObject);
        
    }
 
}
