using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightpath : MonoBehaviour
{
    // Reference to the animation curve
    public AnimationCurve animationCurve;

    // The duration of the lightpath
    public float duration = 5f;

    // Referece to the Cinemachine Dolly Cart
    private CinemachineDollyCart _path;

    // The progression of the dolly cart
    private float _progress;

    // Boolean that tells if the player is attached to the dolly cart or not
    private bool _attached;

    // Start is called before the first frame update
    void Start()
    {
        _path = GetComponent<CinemachineDollyCart>();
        _path.m_Speed = 0;
        _attached = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_attached == true)
        {
            _path.m_Speed = 10;
            _progress += Time.deltaTime / duration;
            // Normalize value for position (0 - 1)
            float position = animationCurve.Evaluate(_progress) % duration;
            _path.m_Position = position;
        }

        if (_progress >= 1)
        {
            _attached = false;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _attached = true;
            other.transform.SetParent(transform);
        }
    }
        
}
