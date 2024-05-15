using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Interactions : MonoBehaviour
{
    // checks is player is close enough to interact
    public bool isClose;
    // reference to the player
    public GameObject player;
    // speed of the friend
    public float speed = 5f;
    // checks if interaction has happened
    public bool hasInteracted = false;
    // references text object
    public TextMeshProUGUI text;
    // offset of friend
    private Vector3 offset;
    //
    public int collectedFriends;


    private void OnTriggerEnter(Collider other)
    {
        // when player enters collider text appears and bool is set to true
        isClose = true;
        text.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        // when player leaves collider text disappears and bool is set to false
        isClose = false;
        text.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //when isClose is true and E is pressed hasInteracted switches to true
        if (isClose && Input.GetKeyDown(KeyCode.E)) 
        {
            hasInteracted = true;
            collectedFriends++;                      
        }

        // if has Interacted is true the friend follow the player with an offset
        if (hasInteracted == true)
        {
            if(collectedFriends < 1)
            {
                offset = new Vector3(0, 0, 1);
            }

            else if (collectedFriends == 1)
            {
                offset = new Vector3(0, 0, 2);
            }

            else if (collectedFriends > 1)
            {
                offset = new Vector3(0, 0, 3);

            }

            print(collectedFriends);

            transform.position = Vector3.MoveTowards(transform.position, (player.transform.position - offset), speed * Time.deltaTime);
            //transform.position = player.transform.position - offset;
            text.gameObject.SetActive(false);


        }
    }
}
