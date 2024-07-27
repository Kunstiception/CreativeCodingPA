using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiSpeedBoost : MonoBehaviour
{

    private GameObject _player;
    // References the Player Controller Script
    private PlayerController _playerController;

    // How long has the player been boosted for
    public float deboostTime;

    // Checks if the player is deboosted or not
    public bool isDeboosted;

    //the sound that plays when player gets a antispeedboost
    public AudioClip antiSpeedBoost;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
        _playerController = _player.GetComponent<PlayerController>();

        // Default state of the player when not deboosted
        _playerController.speed = 6;
        deboostTime = 0;
        _playerController.isDeboosted = false;
    }
    // Boost when player touches the Antispeedboost object; also destroys it
    void OnTriggerEnter(Collider other)
    {
        _playerController.isDeboosted = true;
        _playerController.speed = 3;
        _player.GetComponent<AudioSource>().PlayOneShot(antiSpeedBoost, 0.7f);
        Destroy(gameObject);

    }

}