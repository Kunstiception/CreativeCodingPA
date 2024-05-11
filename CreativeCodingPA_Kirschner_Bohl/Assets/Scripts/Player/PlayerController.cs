using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Speed of the player character
    public float speed;

    // Turnspeed of the player character
    public float turnSpeed;

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

        // Create a vector called direction by combining the horizontal and vertical input into a Vector3
        //Vector3 direction = new Vector3 (horizontalInput, 0, verticalInput);

        // Moves the player according to the created vector normalized
        transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);
        
        // Input.GetAxisRaw("Vertical")
        float turnAngle = turnSpeed * horizontalInput * Time.deltaTime;
        transform.Rotate(Vector3.up, turnAngle);

        if(verticalInput < 0)
        {
            transform.rotation = _turnAround;
        }
     
        
        


    }
}
