using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendManager : MonoBehaviour
{

    // An array storing all the collectible friends
    public GameObject[] Friends;

    // Index of the current friend
    public int friendIndex;

    // Reference to the MoveFriends script
    private MoveFriends _moveFriends;

    // The offset of the friends on the z-axis
    private float zOffset;

    // Reference to the friends dispay script
    private FriendsDisplay _friendsDisplay;

    private DamageController _damageController;

    // Start is called before the first frame update
    void Start()
    {
        _friendsDisplay = GameObject.Find("Friends_Grid").GetComponent<FriendsDisplay>();

        _damageController = GameObject.Find("Player").GetComponent<DamageController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // Assign the offset of the friends according to the number of collected friends, add the friend to the list of collected friends, update the friends display
    public void AssignOffset(GameObject friend)
    {
        if(friend != null)
        {
            // Get the script on the friend object
            _moveFriends = friend.GetComponent<MoveFriends>();
            
            // https://learn.microsoft.com/en-us/dotnet/api/system.array.indexof?view=net-8.0#system-array-indexof(system-array-system-object)
            // Get the index of the given object in the array
            // int index = Array.IndexOf(Friends, friend);

            _damageController._friends.Add(friend);

            //friendIndex = index;

            _friendsDisplay.UpdateFriendsDisplay();
            
            if(_damageController.numberOfFriends <= 0)
            {
                zOffset = 0.5f;
            }
            else if(_damageController.numberOfFriends == 1)
            {
                zOffset = 1.0f;
            }
            else
            {
                zOffset = 1.5f;
            }
  
            _moveFriends.offset = _moveFriends.offset + new Vector3(0, 0, zOffset);
        }
        
    }

    public void ReassignOffset(GameObject friend)
    {
        if (_damageController.numberOfFriends == 1)
        {
            zOffset = 1f;
        }
        else if(_damageController.numberOfFriends == 2)
        {
            zOffset = 1.5f;
        }
        else
        {
            zOffset = 0.5f;
        }

        _friendsDisplay.UpdateFriendsDisplay();
    }
}
