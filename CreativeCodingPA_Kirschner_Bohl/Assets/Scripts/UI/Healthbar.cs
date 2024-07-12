using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    // Tutorial für das Erstellen einer Healthbar: https://www.youtube.com/watch?v=BLfNP4Sc_iA

    // The color of the healthbar when health is low
    public Color riskyColor;

    // The color of the healthbar when health is good
    public Color healthyColor;

    // The healthbar fill
    private Image _fill;

    // The slider controlling the healthbar
    private Slider _slider;

    // Reference to the damage controller script
    private DamageController _damageController;

    // The renderer of the slider
    private Color _currentColor;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _fill = GameObject.Find("Fill").GetComponent<Image>();

        _slider = GetComponentInChildren<Slider>();

        _damageController = GameObject.Find("Player").GetComponent<DamageController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Set the slider using the life points
        _slider.value = _damageController.lifePoints;
        
        
        // Change the color of the healthbar when it goes under 0.33
        if ( _damageController.lifePoints < 0.33f )
        {
            _fill.color = riskyColor;
            
        }
        else
        {
            _fill.color = healthyColor;
        }
    }
}
