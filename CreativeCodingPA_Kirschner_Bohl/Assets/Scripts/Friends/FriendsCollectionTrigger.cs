using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FriendsCollectionTrigger : MonoBehaviour
{
    
    // Reference to the MoveFriends script
    public GameObject correspondingFriend;

    // references text object
    public TextMeshProUGUI text;
    
    // Reference to the FriendManager script
    public FriendManager friendManager;

    // Reference to the moveFriends script
    private MoveFriends _moveFriends;


    void Start()
    {
        _moveFriends = correspondingFriend.GetComponent<MoveFriends>();
    }


    private void OnTriggerEnter(Collider other)
    {
        // when player enters collider text appears and bool is set to true
        _moveFriends.isClose = true;
        text.gameObject.SetActive(true);
        friendManager.AssignOffset(correspondingFriend);
    }

    private void OnTriggerExit(Collider other)
    {
        // when player leaves collider text disappears and bool is set to false
        _moveFriends.isClose = false;
        text.gameObject.SetActive(false);
    }

}
