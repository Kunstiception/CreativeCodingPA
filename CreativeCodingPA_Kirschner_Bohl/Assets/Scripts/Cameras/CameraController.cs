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

    //Referance to the player animator
    private Animator _playerAnimator;

 // Start is called before the first frame update
 void Start()
    {
        // Stores the animator component
        _animator = GetComponent<Animator>();
        _playerAnimator = GameObject.FindWithTag("Player").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // store the current vertical input
        _verticalInput = playerController.verticalInput;

        // store the current vertical input
        _horizontalInput = playerController.horizontalInput;

        // If both vertical and horizontal inputs euqal 0 (no movement), switch to idle camera / The wait time is handled in the State Driven Camera-Settings
        if (_verticalInput == 0 && _horizontalInput == 0)
        {
            _animator.SetInteger("CameraIndex", 1);
            _playerAnimator.SetBool("isIdling", true);
        }
        // Else the active camera is the movement camera
        else
        {
            _animator.SetInteger("CameraIndex", 0);
            _playerAnimator.SetBool("isIdling", false);

        }

    }
}
