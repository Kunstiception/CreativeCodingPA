using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Interactions : MonoBehaviour
{

    public bool isClose;
    public GameObject player;
    public float speed = 1.5f;
    public bool hasInteracted = false;
    public TextMeshProUGUI text;


    private void OnTriggerEnter(Collider other)
    {
        isClose = true;
        text.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        isClose = false;
        text.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (isClose && Input.GetKeyDown(KeyCode.E)) 
        {
            print("yippie");
            hasInteracted = true;
            
        }

        if (hasInteracted == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }
}
