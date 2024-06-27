using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.UI;

public class FriendsDisplay : MonoBehaviour
{
    public GameObject[] friends;

    public Color inactiveColor;

    public Color activeColor;

    private DamageController _damageController;


    
    // Start is called before the first frame update
    void Start()
    {
        _damageController = GameObject.Find("Player").GetComponent<DamageController>();

        ResetFriends();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResetFriends()
    {
        
        foreach (var friend in friends)
        {
            friend.GetComponent<Image>().color = inactiveColor;
        }
    }

    public void UpdateFriendsDisplay()
    {
        ResetFriends();

        for (int i = 0; i < _damageController.friends.Count; i++)
        {
            friends[i].GetComponent<Image>().color = activeColor;
        }

    }
}
