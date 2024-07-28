using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Is the player boosted?
    public bool isBoosted;

    // Is the player deboosted?
    public bool isDeboosted;
    
    // A bool to describe if the player is curently jumping or not
    public bool isJumping;

    // Speed of the player character
    public float speed;

    // Turnspeed of the player character
    public float turnSpeed;

    // Makes the player turn faster when not moving
    public float turnSpeedMultiplier;

    // The vertical input for movement
    public float verticalInput;

    // The horizontal input for movement
    public float horizontalInput;

    // Angle, in which the player should turn when the input is opposite to its current direction while standing still
    private Quaternion _turnAround = Quaternion.Euler(0f, 180f, 0f);

    // References the Speedboost Script
    private SpeedBoost _speedBoost;

    //References the AntiSpeedBoost Script;
    private AntiSpeedBoost _antiSpeedBoost;

    // References the Object with the Speedboost Script attached to it
    private GameObject _boost;

    private GameObject _antiBoost;

    // How long has the player been boosted for
    private float boostTime;


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

        // As long as the player doesnt move vertically: Rotating the character is allowed and the rotation speed is doubled to allow for better control of the character
        transform.Rotate(Vector3.up, turnAngle * turnSpeed * Time.deltaTime * turnSpeedMultiplier);
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
        if (isBoosted == true)
        {
            boostTime += Time.deltaTime;

            if (boostTime >= 3)
            {
                speed = 6;
                boostTime = 0;
                isBoosted = false;
            }
        }

        // How long is the player being deboosted for
        if (isDeboosted == true)
        {
            boostTime += Time.deltaTime;

            if (boostTime >= 3)
            {
                speed = 6;
                boostTime = 0;
                isDeboosted = false;
            }
        }

    }
}
