using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendManager : MonoBehaviour
{
    // The three possible offsets
    public float[] offsets;

    // Index of the current friend
    public int friendIndex;

    // Reference to the MoveFriends script
    private MoveFriends _moveFriends;

    // The offset of the friends on the z-axis
    private float offset;

    // Reference to the friends dispay script
    private FriendsDisplay _friendsDisplay;

    // Reference to the player object
    private GameObject _player;

    // Reference to the Damage Controller script
    private DamageController _damageController;


    // Start is called before the first frame update
    void Start()
    {
        _friendsDisplay = GameObject.Find("Friends_Grid").GetComponent<FriendsDisplay>();

        _player = GameObject.Find("Player");

        _damageController = _player.GetComponent<DamageController>();

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
                offset = offsets[0];
            }
            else if(_damageController.friends.Count == 1)
            {
                offset = offsets[1];
            }
            else
            {
                offset = offsets[2];
            }
  
            _moveFriends.offset = new Vector3(0, 0, offset);
        }
        
    }

    // After one friend has died, move the rest of the friends one offset-step closer to the player to fill the gap
    // (only applies if there is more than one friend remaining)
    public void ReassignOffset(GameObject friend)
    {
        if (_damageController.friends.Count > 1)
        {
            offset = offset - offsets[0];
        }

        _moveFriends.offset = new Vector3(0, 0, offset);

        _friendsDisplay.UpdateFriendsDisplay();
    }
}
