using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightpath : MonoBehaviour
{
    // The duration of the lightpath
    public float duration = 5f;

    // Referece to the Cinemachine Dolly Cart
    private CinemachineDollyCart _path;

    // The progression of the dolly cart
    private float _progress;

    private bool _attached;

    // Start is called before the first frame update
    void Start()
    {
        _path = GetComponent<CinemachineDollyCart>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_attached == true)
        {
            _progress += Time.deltaTime / duration;
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
            other.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }
        
}
