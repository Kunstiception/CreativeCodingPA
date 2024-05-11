using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Speed of the player character
    public float speed;

    // Turnspeed of the player character
    public float turnSpeed;

    // Angle, in which the player should turn when the input is opposite to its current direction while standing still
    private Quaternion _turnAround = Quaternion.Euler(0f, 180f, 0f);
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Player input on the horizontal axis
        float horizontalInput = Input.GetAxis("Horizontal");

        // Player input on the vertical axis
        float verticalInput = Input.GetAxis("Vertical");

        // Moves the player according to the created vector normalized
        transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);

        // The angle in which the player can turn
        if(verticalInput != 0f)
        {
            float turnAngle = turnSpeed * horizontalInput * Time.deltaTime;
            transform.Rotate(Vector3.up, turnAngle * turnSpeed * Time.deltaTime);
        }


        // Makes the player turn when the input is opposite to its current direction while standing still
        //if (verticalInput < 0)
        {
            //transform.rotation = _turnAround;
        }
     
        
        


    }
}
