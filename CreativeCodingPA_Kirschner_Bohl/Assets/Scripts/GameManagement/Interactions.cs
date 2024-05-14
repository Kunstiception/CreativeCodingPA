using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Interactions : MonoBehaviour
{

    public bool isClose;
    public GameObject friend;
    public float speed = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        isClose = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isClose = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, friend.transform.position, speed * Time.deltaTime);

        if (isClose && Input.GetKeyDown(KeyCode.E)) 
        {
            print("yippie");
            
        }
    }
}
