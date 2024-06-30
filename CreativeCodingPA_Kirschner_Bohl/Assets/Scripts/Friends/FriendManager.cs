using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendManager : MonoBehaviour
{
    // The three possible offsets
    public float[] offsets;
    
    // An array storing all the collectible friends
    //public GameObject[] Friends;

    // Index of the current friend
    public int friendIndex;

    // Reference to the MoveFriends script
    private MoveFriends _moveFriends;

    // The offset of the friends on the z-axis
    private float zOffset;

    // Reference to the friends dispay script
    private FriendsDisplay _friendsDisplay;

    // Reference to the Damage Controller script
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


    // Assign the offset of the friends according to the number of collected friends
    // Add the friend to the list of collected friends, update the friends display
    public void AssignOffset(GameObject friend)
    {
        if(friend != null)
        {
            
            _moveFriends = friend.GetComponent<MoveFriends>();
            
            if(_damageController.friends.Count <= 0)
            {
                zOffset = offsets[0];
            }
            else if(_damageController.friends.Count == 1)
            {
                zOffset = offsets[1];
            }
            else
            {
                zOffset = offsets[2];
            }
  
            _moveFriends.offset = new Vector3(0, 0, zOffset);
        }
        
    }

    // After one friend has died, move the rest of the friends one offset-step closer to the player to fill the gap
    // (only applies if there is more than one friend remaining)
    public void ReassignOffset(GameObject friend)
    {
        if (_damageController.friends.Count > 1)
        {
            zOffset = zOffset - offsets[0];
        }

        _moveFriends.offset = new Vector3(0, 0, zOffset);

        _friendsDisplay.UpdateFriendsDisplay();
    }
}
