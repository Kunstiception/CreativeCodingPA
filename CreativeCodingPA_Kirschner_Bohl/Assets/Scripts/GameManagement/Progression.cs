using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progression : MonoBehaviour
{
    // stores the current progress
    public int progress;

    public static Progression Instance;

    // https://learn.unity.com/tutorial/implement-data-persistence-between-scenes#634f8281edbc2a65c86270cb
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
