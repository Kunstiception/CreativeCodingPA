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

    //the sound that plays when friend has been collected
    public AudioClip friendCollected;

    //Friend distance to player
    private float _distance;
    
    // speed of the friend
    private float speed = 5f;

    // Reference to the DamageController script
    private DamageController _damageController;

    // Reference to the Friends Manager script
    private FriendManager _friendManager;

    //References the FriendsDisplay script
    private FriendsDisplay _friendsDisplay;
    
    // checks if interaction has happened
    private bool hasInteracted = false;

    // The Vector3 to where the friends are being moved towards
    private Vector3 _playerAnchor;

    //References the player
    private GameObject _player;

    // Reference to the corresponding AudioSource
    private AudioSource _audioSource;


    void Start()
    {
        _player = GameObject.Find("Player");

        _audioSource = _player.GetComponent<AudioSource>();

        _damageController = _player.GetComponent<DamageController>();

        _friendManager = GameObject.Find("GameManager").GetComponent<FriendManager>();

        _friendsDisplay = GameObject.Find("Friends_Grid").GetComponent<FriendsDisplay>();
    }

    // Update is called once per frame
    void Update()
    {
        // https://docs.unity3d.com/ScriptReference/Vector3.Distance.html
        _distance = Vector3.Distance(transform.position, player.transform.position);

        // Assigns the correct offset to the friend so they dont clip into each other and form a straight line
        if (isClose && Input.GetKeyDown(KeyCode.E))
        {
            hasInteracted = true;
            

            if (!_damageController.friends.Contains(gameObject) && _damageController.friends.Count < 3)
            {
                _friendManager.AssignOffset(gameObject);
                _damageController.friends.Add(gameObject);
                _friendsDisplay.UpdateFriendsDisplay();
                _audioSource.PlayOneShot(friendCollected, 1f);
            }
            
            isClose = false;
        }

        // if has Interacted is true, the friends follow the player with an offset
        if (hasInteracted == true)
        {
            
            transform.localRotation = player.transform.rotation;
            //https://gamedev.stackexchange.com/questions/197281/how-can-i-make-an-object-follow-behind-the-player-with-respect-to-its-rotation-s
            _playerAnchor = player.transform.position + player.transform.TransformDirection(-offset);
            transform.position = Vector3.MoveTowards(transform.position, _playerAnchor, speed * Time.deltaTime);
            

            text.gameObject.SetActive(false);

            // make the friends go faster so they dont fall behind after reaching a certain distance to the player
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
