using System.Collections;
using System.Collections.Generic;
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

    // Reference to the renderer of the child game object
    private Renderer _renderer;

    // The material of that renderer
    private Material _playerMaterial;

    // The current color to be applied to the material
    private Color _currentColor;

    

    // The rate at which the life points change on update
    private float _lifeChange;

    
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
        _currentColor = Color.Lerp(deathColor, healthyColor,  _lifePoints);
        // https://docs.unity3d.com/ScriptReference/Mathf.Lerp.html
        // Increases the the interpolation by a fixed value multiplied by time.deltaTime
        _lifePoints += (_lifeChange * Time.deltaTime);
        // https://docs.unity3d.com/ScriptReference/Material.SetColor.html#:~:text=Use%20SetColor%20to%20change%20the,were%20not%20previously%20in%20use.
        // The current color is set to be the emission color
        _playerMaterial.SetColor("_EmissionColor", _currentColor);

        // Else if the healthy color is reached, set isFullHealth to true
        if (_lifePoints >= 1f)
        {
            isFullHealth = true;

        }
        // Else set it to false
        else
        {
            isFullHealth = false;
        }
    }
}
