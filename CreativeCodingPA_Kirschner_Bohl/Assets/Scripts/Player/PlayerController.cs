using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Speed of the player character
    public float speed;

    // Turnspeed of the player character
    public float turnSpeed;

    // The vertical input for movement
    public float verticalInput;

    // The horizontal input for movement
    public float horizontalInput;

    // Angle, in which the player should turn when the input is opposite to its current direction while standing still
    private Quaternion _turnAround = Quaternion.Euler(0f, 180f, 0f);

    // References the Speedboost Script
    private SpeedBoost _speedBoost;

    // References the Object with the Speedboost Script attached to it
    private GameObject _boost;

    // How long has the player been boosted for
    private float boostTime;


    private void Start()
    {
        //Gets the Speedboost Script 
        _speedBoost = GameObject.Find("Boost").GetComponent<SpeedBoost>();
    }

    // Update is called once per frame
    void Update()
    {
        // Player input on the horizontal axis
        horizontalInput = Input.GetAxis("Horizontal");

        // Player input on the vertical axis
        verticalInput = Input.GetAxis("Vertical");

        // The angle in which the player can turn
        float turnAngle = turnSpeed * horizontalInput * Time.deltaTime;

        // Moves the player forward or backward depending on the vertical input
        transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);


        if (verticalInput == 0f)
        {

            // As long as the player doesnt move vertically: Rotating the character is allowed
            transform.Rotate(Vector3.up, turnAngle * turnSpeed * Time.deltaTime);
        }

        // If the player moves backward, then invert the turn angle
        else if (verticalInput < 0f)
        {
            transform.Rotate(Vector3.up, turnAngle * -1 * turnSpeed * Time.deltaTime);
        }
        // otherwise do not invert the turn angle
        else if (verticalInput > 0f)
        {
            transform.Rotate(Vector3.up, turnAngle * turnSpeed * Time.deltaTime);
        }

        // How long is the player being boosted for
        if (_speedBoost.isBoosted == true)
        {
            boostTime += Time.deltaTime;

            if (boostTime >= 3)
            {
                speed = 6;
                boostTime = 0;
                _speedBoost.isBoosted = false;
            }
        }   
    }
}
