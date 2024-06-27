using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MoveFriends : MonoBehaviour
{
    // checks is player is close enough to interact
    public bool isClose;
    // reference to the player
    public GameObject player;
    // The normal speed
    public float normalSpeed = 5f;
    // The speed when the friends needs to catch up to the player
    public float catchUpSpeed = 8f;
    
    // references text object
    public TextMeshProUGUI text;
    // offset of friend
    public Vector3 offset;

    private float _distance;
    
    // speed of the friend
    private float speed = 5f;

    // Reference to the DamageController script
    private DamageController _damageController;

    // Reference to the Friends Manager script
    private FriendManager _friendManager;
    
    // checks if interaction has happened
    private bool hasInteracted = false;


    void Start()
    {
        _damageController = GameObject.Find("Player").GetComponent<DamageController>();

        _friendManager = GameObject.Find("GameManager").GetComponent<FriendManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // https://docs.unity3d.com/ScriptReference/Vector3.Distance.html
        _distance = Vector3.Distance(transform.position, player.transform.position);

        // Assigns the correct offset to the friend so they dotn clip into each other and form a straight line
        if (isClose && Input.GetKeyDown(KeyCode.E))
        {
            
            
            hasInteracted = true;
            if (!_damageController.friends.Contains(gameObject) && _damageController.friends.Count < 3)
            {
                _friendManager.AssignOffset(gameObject);
                _damageController.friends.Add(gameObject);
            }
            
            isClose = false;
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
