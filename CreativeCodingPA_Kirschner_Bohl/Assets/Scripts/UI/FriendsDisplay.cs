using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.UI;

public class FriendsDisplay : MonoBehaviour
{
    // Array of the friends sprites
    public GameObject[] friends;

    // The inactive color
    public Color inactiveColor;

    // The active color
    public Color activeColor;

    // Reference to the damage controller script
    private DamageController _damageController;


    
    // Start is called before the first frame update
    void Start()
    {
        _damageController = GameObject.Find("Player").GetComponent<DamageController>();

        // Set all friends to inactive on start
        ResetFriends();
    }

    // Update is called once per frame
    void Update()
    {
        // As long as there are no friends collected, set alle sprites to the inactive color
        if(_damageController.friends.Count == 0)
        {
            ResetFriends();
        }
    }

    public void ResetFriends()
    {
        // Set all friends to the inactive color
        foreach (var friend in friends)
        {
            friend.GetComponent<Image>().color = inactiveColor;
        }
    }

    // If any friends are collected, set as many sprites active as there are friends collected, otherwise set all to the inactive color
    public void UpdateFriendsDisplay()
    {
        ResetFriends();

        if (_damageController.friends.Count > 0 ) 
        {
            for (int i = 0; i < _damageController.friends.Count; i++)
            {
                friends[i].GetComponent<Image>().color = activeColor;
            }
        }

        else
        {
            for (int i = 0; i < _damageController.friends.Count; i++)
            {
                friends[i].GetComponent<Image>().color = inactiveColor;
            }
        }
        
    }
}
