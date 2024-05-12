using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Reference to the player controller
    public PlayerController playerController;

    // Stores the current vertical input
    private float _verticalInput;

    // Reference to the animator
    private Animator _animator;
    
        // Start is called before the first frame update
    void Start()
    {
        // Stores the animator component
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // store the current vertical input
        _verticalInput = playerController.verticalInput;
        // If vertical Input euqals 0 (no movement), switch to idle camera / The wait time is handled in the State Driven Camera-Settings
        if (_verticalInput == 0)
        {
            _animator.SetInteger("CameraIndex", 1);
        }
        // Else the active camera is the movement camera
        else
        {
            _animator.SetInteger("CameraIndex", 0);
        }
            
    }
}
