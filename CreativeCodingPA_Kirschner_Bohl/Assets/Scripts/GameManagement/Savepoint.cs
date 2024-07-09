using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Savepoint : MonoBehaviour
{

    // Adds to the progress variable and disables the collider
    private void OnTriggerEnter(Collider other)
    {
        Progression.Instance.progress++;
        gameObject.GetComponent<Collider>().enabled = false;
    }
}
