using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    

    // Turnspeed of the player character
    public float turnSpeed;

    // The vertical input for movement
    public float verticalInput;

    // The horizontal input for movement
    public float horizontalInput;

    // Angle, in which the player should turn when the input is opposite to its current direction while standing still
    private Quaternion _turnAround = Quaternion.Euler(0f, 180f, 0f);

    // Speed of the player character
    private float speed;

    //How long has the player been boosted for
    private float boostTime;

    //Checks if the player is boosted or not
    private bool isBoosted;

    private void Start()
    {
        //Default state of the player when not boosted
        speed = 6;
        boostTime = 0;
        isBoosted = false;
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

            // As long as the player doesnt move vertically: Moves the player left or right depending on the horizontal input
            transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
        }

        // If the player moves backward, then invert the turn angle and no direct movement to left or right is possible
        else if (verticalInput < 0f)
        {
            transform.Rotate(Vector3.up, turnAngle * -1 * turnSpeed * Time.deltaTime);
        }
        // otherwise do not invert the turn angle and no direct movement to left or right is possible
        else
        {
            transform.Rotate(Vector3.up, turnAngle * turnSpeed * Time.deltaTime);
        }

        // How long is the player being boosted for
        if (isBoosted)
        {
            boostTime += Time.deltaTime;
            
            if (boostTime >= 3)
            {
                speed = 6;
                boostTime = 0;
                isBoosted = false;
            }
        }

    // Boost when player touches the speedboost object; also destroys it
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boost")
        {
            isBoosted = true;
            speed = 12;
            Destroy(gameObject);
        }
    }



        // Makes the player turn when the input is opposite to its current direction while standing still
        /*if (verticalInput < 0 && verticalInput == 0)
        {
            transform.rotation = _turnAround;
        }
        */
    }
}
