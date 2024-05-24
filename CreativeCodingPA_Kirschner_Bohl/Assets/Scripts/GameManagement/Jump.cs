using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    // The strength of the jump as a float value
    public float jumpStrength;


    // Reference to the player Animator
    private Animator _playerAnimator;

    // Reference to the rigidbody component of the player object
    private Rigidbody _playerRB;

    // Start is called before the first frame update
    void Start()
    {
        _playerRB = GameObject.Find("Player").GetComponent<Rigidbody>();

        _playerAnimator = GameObject.Find("Player").GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _playerRB.AddForce(Vector3.up * jumpStrength, ForceMode.Impulse);

        _playerAnimator.SetBool("isMoving", false); 
    }
}
