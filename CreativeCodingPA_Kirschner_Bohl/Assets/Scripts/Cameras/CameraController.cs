using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Reference to the player controller
    public PlayerController playerController;

    // Stores the current vertical input
    private float _verticalInput;

    // Stores the current horizontal input
    private float _horizontalInput;

    // Reference to the animator
    private Animator _animator;

    // Reference to the idleCam
    private CinemachineFreeLook _idleCam;

    // Reference to the moveCam
    private CinemachineVirtualCamera _moveCam;

    // A bool to descibe the current state of idleCam's X axis and to prevent it from being reset on every frame
    private bool _isMoveCamFixed;

    //Reference to the UIManager
    private UIManager _uiManager;


 // Start is called before the first frame update
 void Start()
    {
        // Get the animator component
        _animator = GetComponent<Animator>();

        // Get idle camera
        _idleCam = GameObject.Find("State-Driven Camera").GetComponentInChildren<CinemachineFreeLook>();

        // Get move camera
        _moveCam = GameObject.Find("State-Driven Camera").GetComponentInChildren<CinemachineVirtualCamera>();

        // Get UI Manager
        _uiManager = GameObject.Find("GameManager").GetComponent<UIManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (_uiManager.isGameOver == false)
        {
            // if the player does not move, switch to idle cam
            if (playerController.verticalInput == 0 && playerController.horizontalInput == 0)
            {
            _animator.SetBool("isMoving", false);
            // reset the free look cameras x axis value to 0, so it is centered behind the player when the camera is entered
            if (_isMoveCamFixed == false)
            {
                ResetIdleCam();
            }
            
            
            }
            // else switch to move cam and set _isMoveCamFixed to false
            else
            {
            _animator.SetBool("isMoving", true);
            _isMoveCamFixed = false;
            }
        }
       
    }

    // Resets the idleCam's X value to 0, so it starts behind the player not anywhere else, also reset the corresponding bool so this only happens once
    public void ResetIdleCam()
    {
        _idleCam.m_XAxis.Value = 0;
        _isMoveCamFixed = true;

    }

}
