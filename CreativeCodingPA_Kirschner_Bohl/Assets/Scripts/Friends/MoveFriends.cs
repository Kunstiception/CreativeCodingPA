using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoveFriends : MonoBehaviour
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
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        //when isClose is true and E is pressed hasInteracted switches to true
        if (isClose && Input.GetKeyDown(KeyCode.E))
        {
            hasInteracted = true;

        }

        // if has Interacted is true the friend follow the player with an offset
        if (hasInteracted == true)
        {

            transform.position = Vector3.MoveTowards(transform.position, (player.transform.position - offset), speed * Time.deltaTime);

            text.gameObject.SetActive(false);


        }
    }
}
