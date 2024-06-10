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


 // Start is called before the first frame update
 void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.verticalInput == 0 && playerController.horizontalInput == 0)
        {
            _animator.SetBool("isMoving", false);
        }
        else
        {
            _animator.SetBool("isMoving", true);
        }
    }
}
