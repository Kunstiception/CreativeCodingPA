using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    //The Game Over Scrren
    public GameObject gameOverUI;

    //Has the character died?
    public bool isGameOver;

    public AudioClip deathSound;

    //References the player
    private GameObject _player;

    //References the player controller script
    private PlayerController _playerController;

    //References the damage controller script
    private DamageController _damageController;

    // Checks if the death sound has already played
    private bool _hasPlayed;

    //References the audio source of the camera
    private AudioSource _camAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
        _playerController = _player.GetComponent<PlayerController>();
        _damageController = _player.GetComponent<DamageController>();
        _camAudioSource = Camera.main.GetComponent<AudioSource>();
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        //When character dies Game Over screen appears and the player can't move anymore
        if (_damageController.lifePoints <= 0f && _damageController.friends.Count == 0)
        {
            gameOverUI.SetActive(true);
            _playerController.speed = 0;
            _playerController.turnSpeed = 0;
            isGameOver = true;
            Cursor.lockState = CursorLockMode.None;
            _camAudioSource.Stop();

            if(_hasPlayed == false)
            {
                _player.GetComponent<AudioSource>().PlayOneShot(deathSound);
                _hasPlayed = true;
            }

        }
    }

    public void BackToTitle()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        SceneManager.LoadScene(2);
    }


}
