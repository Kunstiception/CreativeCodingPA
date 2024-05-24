using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    // The strength of the jump as a float value
    public float jumpStrength;

    // A bool that describes if the player is jumping or not
    public bool isJumping;
    
    //Reference to the player object
    private GameObject _player;

    // Reference to the player Animator
    private Animator _playerAnimator;

    // Reference to the rigidbody component of the player object
    private Rigidbody _playerRB;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");

        _playerRB = _player.GetComponent<Rigidbody>();

        _playerAnimator = _player.GetComponent<Animator>();
    }


    private void Update()
    {
        if (isJumping && Input.GetKeyDown(KeyCode.Space))
        {
            _playerRB.AddForce(Vector3.up * jumpStrength, ForceMode.Impulse);
 
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        isJumping = true;
        _playerAnimator.SetBool("isMoving", false);
    }
}
