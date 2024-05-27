using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    // A bool to show if the player is near a lightsource or not
    public bool inLight;

    // The color to indicate that the health of the player is looking good
    public Color healthyColor;

    // The color to indicate that the health of the player is looking bad
    public Color deathColor;

    // A boolean indicating if the player has full health
    public bool isFullHealth;

    // Particle system for when player is receiving damage
    public ParticleSystem losingLightParticles;

    // Particle system for when playser is in light
    public ParticleSystem recievingLightParticles;

    // Reference to the renderer of the child game object
    private Renderer _renderer;

    // The material of that renderer
    private Material _playerMaterial;

    // The current color to be applied to the material
    private Color _currentColor;

    private float _lifePoints;

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
        
        // Sets the lifepoints to the 0f, which means the emission color is white, indicating full health
        _lifePoints = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        // Checks if the player is near a lightsource, if false life points are subtracted
        if (inLight == false)
        {
            _lifeChange = 0.15f;
            losingLightParticles.Play();
        }

        // if true, life points are added, which happens at twice the speed as the subtraction of life points
        else
        {
            _lifeChange = -0.4f;
            recievingLightParticles.Play();

        }

        //https://docs.unity3d.com/ScriptReference/Color.Lerp.html
        // Lerps between two colors to signal the player's health
        _currentColor = Color.Lerp(healthyColor, deathColor, _lifePoints);
        // https://docs.unity3d.com/ScriptReference/Mathf.Lerp.html
        // Increases the the interpolation by a fixed value multiplied by time.deltaTime
        _lifePoints += (_lifeChange * Time.deltaTime);
        // https://docs.unity3d.com/ScriptReference/Material.SetColor.html#:~:text=Use%20SetColor%20to%20change%20the,were%20not%20previously%20in%20use.
        // The current color is set to be the emission color
        _playerMaterial.SetColor("_EmissionColor", _currentColor);

        if (_lifePoints >= 1f)
        {
            // print("Game Over!");
        }

        else if (_lifePoints <= 0f)
        {
            isFullHealth = true;
        }

        else
        {
            isFullHealth = false;
        }
    }
}
