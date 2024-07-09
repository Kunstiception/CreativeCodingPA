using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class SetSavepoint : MonoBehaviour
{
    public Transform[] savepoints;

    private GameObject _player;

    private PlayerController _playerController;


    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
        
        // disable the colliders of all pas savepoints
        for(int i = 0; i < Progression.Instance.progress; i++)
        {
            savepoints[i].GetComponent<Collider>().enabled = false;
        }

        // On reload set the player to the last checkpoint
        if(Progression.Instance.progress > 0)
        {
            _player.gameObject.transform.position = savepoints[Progression.Instance.progress - 1].position;
            _player.gameObject.transform.rotation = savepoints[Progression.Instance.progress - 1].rotation;
        }
        
    }
}
