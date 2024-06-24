using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    // The rate at which life points are increased
    public float increaseLifePoints;

    // The rate at which life points are decreased
    public float decreaseLifePoints;
    
    // A bool to show if the player is near a lightsource or not
    public bool inLight;

    // The color to indicate that the health of the player is looking good
    public Color deathColor;

    // The color to indicate that the health of the player is looking bad
    public Color healthyColor;

    // A boolean indicating if the player has full health
    public bool isFullHealth;

    // Particle system for when player is receiving damage
    public ParticleSystem losingLightParticles;

    // Particle system for when playser is in light
    public ParticleSystem recievingLightParticles;

    // The life points of the player character represented by its color
    public float _lifePoints;

    // The current color to be applied to the material
    public Color currentColor;

    // Time after being fully reacharged where the player doesnt lose any health
    public int InvincibilityTime;

    // Reference to the renderer of the child game object
    private Renderer _renderer;

    // The material of that renderer
    private Material _playerMaterial;

    // The rate at which the life points change on update
    private float _lifeChange;

    // Extra variable to set the lifechange to 0
    private float _fullChargeLifechange = 0;

    // Bool to describe if the player can take damage
    private bool _isInvincible;

    
    // Start is called before the first frame update
    void Start()
    {
        // Gets the renderer of the child object
        _renderer = GetComponentInChildren<Renderer>();

        // https://docs.unity3d.com/ScriptReference/Renderer-material.html
        // Gets the material of that renderer
        _playerMaterial = _renderer.GetComponent<Renderer>().material;
        print(_playerMaterial);
        
        // Sets the lifepoints to the 1f, which means the emission color is white, indicating full health
        _lifePoints = 1f;

        losingLightParticles.gameObject.SetActive(false);
        recievingLightParticles.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        print(isFullHealth);
        
        // Checks if the player is near a lightsource, if false life points are subtracted
        if (inLight == false)
        {
            _lifeChange = decreaseLifePoints;
            losingLightParticles.gameObject.SetActive(true);
            recievingLightParticles.gameObject.SetActive(false);
            
        }

        // if true, life points are added
        else if (inLight == true)
        {
            _lifeChange = increaseLifePoints;
            recievingLightParticles.gameObject.SetActive(true);
            losingLightParticles.gameObject.SetActive(false);
        }

        //https://docs.unity3d.com/ScriptReference/Color.Lerp.html
        // Lerps between two colors to signal the player's health
        currentColor = Color.Lerp(deathColor, healthyColor,  _lifePoints);
        // https://docs.unity3d.com/ScriptReference/Mathf.Lerp.html
        
        // Increases the the interpolation by a fixed value multiplied by time.deltaTime
        if (_isInvincible == false)
        {
            _lifePoints += (_lifeChange * Time.deltaTime);
        }
        
        // https://docs.unity3d.com/ScriptReference/Material.SetColor.html#:~:text=Use%20SetColor%20to%20change%20the,were%20not%20previously%20in%20use.
        // The current color is set to be the emission color
        _playerMaterial.SetColor("_EmissionColor", currentColor);

        // Else if the healthy color is reached, set isFullHealth to true
        if (_lifePoints >= 1f)
        {
            StartCoroutine(FullCharge());
            isFullHealth = true;
        }        

        // Else set it to false
        else
        {
            isFullHealth = false;
        }
    }

    IEnumerator FullCharge()
    {
        _isInvincible = true;
        _lifeChange = _fullChargeLifechange;
        // https://docs.unity3d.com/ScriptReference/WaitForSeconds.html
        yield return new WaitForSeconds(InvincibilityTime);
        _lifeChange = decreaseLifePoints;
        _isInvincible = false;
    }
}
