using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class LightsBlackout : MonoBehaviour
{
    // All lightsources in an array
    public Light[] Lights;

    // The time between the blackouts
    public float waitTime;

    // The index of the current lightsource within the array
    private int _lightsIndex;

    // The timer that dictates when the next lightsource will be shut off
    private float _blackoutTimer;

    private void Start()
    {
        // Index is set to -1, so no lightsource will be shut off at the beginning of the application
        _lightsIndex = -1;
    }

    void Update()
    {
        
        // https://docs.unity3d.com/ScriptReference/Time-deltaTime.html
        // On update the timer adds Time.deltaTime
        _blackoutTimer += Time.deltaTime;

        
        // If the timer reaches/surpasses the wait time and the current lightsIndex is within the bounds of the array, call the Blackout function and reset the timer by subtracting the wait time
        if (_blackoutTimer >= waitTime && _lightsIndex<=Lights.Length)
        {
            Blackout();
            _blackoutTimer = _blackoutTimer - waitTime;
        }

    }

    // Shuts off the lightsource that is linked to the current lightsIndex
    void Blackout()
    {
        _lightsIndex++;
        Lights[_lightsIndex].enabled = false; 
    }
}
