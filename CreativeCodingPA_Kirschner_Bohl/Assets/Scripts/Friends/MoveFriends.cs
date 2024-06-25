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

    public float normalSpeed = 5f;

    public float catchUpSpeed = 8f;
    // checks if interaction has happened
    public bool hasInteracted = false;
    // references text object
    public TextMeshProUGUI text;
    // offset of friend
    public Vector3 offset;

    private float _distance;
    
    // speed of the friend
    private float speed = 5f;

    // Reference to the DamageController script
    private DamageController _damageController;

    void Start()
    {
        _damageController = GameObject.Find("Player").GetComponent<DamageController>();
    }

    // Update is called once per frame
    void Update()
    {
        // https://docs.unity3d.com/ScriptReference/Vector3.Distance.html
        _distance = Vector3.Distance(transform.position, player.transform.position);

        //when isClose is true and E is pressed hasInteracted switches to true
        if (isClose && Input.GetKeyDown(KeyCode.E))
        {
            hasInteracted = true;
            _damageController.numberOfFriends++;
        }

        // if has Interacted is true the friend follow the player with an offset
        if (hasInteracted == true)
        {

            transform.position = Vector3.MoveTowards(transform.position, (player.transform.position - offset), speed * Time.deltaTime);
            
            text.gameObject.SetActive(false);

            if(_distance > 3)
            {
                speed = catchUpSpeed;
            }
            else
            {
                speed = normalSpeed;
            }

        }
    }
}
