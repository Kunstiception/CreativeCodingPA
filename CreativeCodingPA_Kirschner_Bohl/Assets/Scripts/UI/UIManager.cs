using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    //References the player controller script
    private PlayerController _playerController;

    //References the damage controller script
    private DamageController _damageController;

    //The Game Over Scrren
    public GameObject gameOverUI;

    //Has the character died?
    public bool isGameOver;


    // Start is called before the first frame update
    void Start()
    {

        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        _damageController = GameObject.Find("Player").GetComponent<DamageController>();
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        //When character dies Game Over screen appears and the player can't move anymore
        if (_damageController._lifePoints <= 0f && _damageController.friends.Count == 0)
        {
            gameOverUI.SetActive(true);
            _playerController.speed = 0;
            _playerController.turnSpeed = 0;
            isGameOver = true;
            Cursor.lockState = CursorLockMode.None;

        }
    }

    public void BackToTitle()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);

    }


}
