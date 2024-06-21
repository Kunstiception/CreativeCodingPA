using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendsColorChange : MonoBehaviour
{
    private Renderer _renderer;
    
    private Material _material;

    private MoveFriends _moveFriends;

    private DamageController _damageController;
    
    // Start is called before the first frame update
    void Start()
    {
        
        _renderer = GetComponentInChildren<Renderer>();
        
        _material = _renderer.GetComponent<Renderer>().material;
        
        _moveFriends = GetComponent<MoveFriends>();

        _damageController = GameObject.Find("Player").GetComponent<DamageController>();
    }
    
    // Update is called once per frame
    void Update()
    {
        
        if (_moveFriends.hasInteracted)
        {
            _material.SetColor("_EmissionColor", _damageController.currentColor); 
        }
    }
    
}
