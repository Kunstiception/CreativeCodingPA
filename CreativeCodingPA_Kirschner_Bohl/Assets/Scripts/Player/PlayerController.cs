using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Speed of the player character
    public float speed;

    // Turnspeed of the player character
    public float turnSpeed;
    
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

        // Moves the player character forward or backward depending on the value of verticalInput
        transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);

        // Moves the player character left or right depending on the value of horizontalInput inverted
        transform.Translate(Vector3.left * (horizontalInput* -1) * turnSpeed  * Time.deltaTime );

    }
}
