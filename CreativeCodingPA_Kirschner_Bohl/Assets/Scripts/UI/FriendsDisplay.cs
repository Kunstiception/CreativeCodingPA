using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriendsDisplay : MonoBehaviour
{
    public GameObject[] friends;

    public Color inactiveColor;

    public Color activeColor;


    
    // Start is called before the first frame update
    void Start()
    {
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

    public void ShowFriend(int index)
    {
        friends[index].GetComponent<Image>().color = activeColor;
    }
}
