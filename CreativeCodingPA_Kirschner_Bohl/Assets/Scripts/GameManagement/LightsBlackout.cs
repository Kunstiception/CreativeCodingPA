using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsBlackout : MonoBehaviour
{
    // All lightsources in an array
    public Light []Lights;

    // How many times 10 seconds have passed
    private float _passedTimeSteps;

    private int _lightsIndex = -1;


    private float seconds;

    private int displaySeconds;
    void Update()
    {
        print((int)Time.realtimeSinceStartup % 60f % 10);
        // https://discussions.unity.com/t/how-do-use-the-operator/6807/2
        // https://discussions.unity.com/t/time-time-as-int-value/34017

        if(((int)Time.realtimeSinceStartup % 60f) % 10 == 0 && (_lightsIndex <= Lights.Length))
        {
            _lightsIndex++;
            Blackout();
        }
    }

    void Blackout()
    {
       //_lightsIndex++;
       Lights[_lightsIndex].enabled = false;     

    }
}
