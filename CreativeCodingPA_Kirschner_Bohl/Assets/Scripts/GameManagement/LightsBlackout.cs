using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class LightsBlackout : MonoBehaviour
{
    public GameObject[] lightParents;

    private void Start()
    {
        // Switch off the lightsources of the areas the player has already passed through
        if(Progression.Instance != null && Progression.Instance.progress > 0)
        {
            foreach (Transform light in lightParents[Progression.Instance.progress - 1].transform.GetComponentInChildren<Transform>())
            {
                light.GetComponentInChildren<Light>().enabled = false;
                light.GetComponentInChildren<LightSourceHealing>().gameObject.SetActive(false);
            }
        }
        
    }
}
