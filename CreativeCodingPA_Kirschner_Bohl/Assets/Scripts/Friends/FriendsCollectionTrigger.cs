using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FriendsCollectionTrigger : MonoBehaviour
{
    // references text object
    public TextMeshProUGUI text;
    
    // Reference to the FriendManager script
    public FriendManager friendManager;

    // Reference to the moveFriends script
    private MoveFriends _moveFriends;


    void Start()
    {
        _moveFriends = GetComponentInParent<MoveFriends>();
    }


    private void OnTriggerEnter(Collider other)
    {
        // when player enters collider text appears and bool is set to true
        _moveFriends.isClose = true;
        text.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        // when player leaves collider text disappears and bool is set to false
        _moveFriends.isClose = false;
        text.gameObject.SetActive(false);
    }

}
