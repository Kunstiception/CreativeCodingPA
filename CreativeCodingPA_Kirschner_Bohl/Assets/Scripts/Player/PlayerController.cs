using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Speed of the player character
    public float speed;

    // Turnspeed of the player character
    public float turnSpeed;

    public float verticalInput;

    // Angle, in which the player should turn when the input is opposite to its current direction while standing still
    private Quaternion _turnAround = Quaternion.Euler(0f, 180f, 0f);
    
    // Update is called once per frame
    void Update()
    {
        // Player input on the horizontal axis
        float horizontalInput = Input.GetAxis("Horizontal");

        // Player input on the vertical axis
        verticalInput = Input.GetAxis("Vertical");

        // Moves the player according to the created vector normalized
        transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);

        
        if(verticalInput != 0f)
        {
            // The angle in which the player can turn
            float turnAngle = turnSpeed * horizontalInput * Time.deltaTime;
            // If the player moves backward, then invert the turn angle
            if (verticalInput < 0f)
            {
                transform.Rotate(Vector3.up, turnAngle * -1 * turnSpeed * Time.deltaTime);
            }
            // otherwise do not invert the turn angle
            else
            {
                transform.Rotate(Vector3.up, turnAngle * turnSpeed * Time.deltaTime);
            }
        }
        {
            
        }


        // Makes the player turn when the input is opposite to its current direction while standing still
        if (verticalInput < 0 && verticalInput == 0)
        {
            transform.rotation = _turnAround;
        }
     
        
        


    }
}
