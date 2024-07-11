using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendsDissolve : MonoBehaviour
{
    // Particle system to be played when the death event is happening
    public ParticleSystem deathParticles;

    // Length of the death event
    public int deathTime;

    // The value that is being restored to the player's health
    public float healingValue;

    // Reference to the damage controller
    private DamageController _damageController;

    // Reference to the friends display script
    private FriendsDisplay _friendsDisplay;

    void Start()
    {
        _damageController = GameObject.Find("Player").GetComponent<DamageController>();

        _friendsDisplay = GameObject.Find("Friends_Grid").GetComponent<FriendsDisplay>();

        deathParticles.gameObject.SetActive(false);
    }

    // Plays the particle system and heals the player, then makes the friend disappear
    public void DissolveAndHeal()
    {
        deathParticles.gameObject.SetActive(true);
        StartCoroutine(DeathEvent());
        _damageController.lifePoints = healingValue;
        deathParticles.gameObject.SetActive(false);
        gameObject.gameObject.SetActive(false);

    }

    IEnumerator DeathEvent()
    {
        yield return new WaitForSeconds(deathTime);
    }
}
