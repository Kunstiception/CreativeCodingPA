using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    public bool inLight;

    public Color healthyColor;

    public Color deathColor;

    private Renderer _renderer;

    private Color _currentColor;

    
    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponentInChildren<Renderer>();
        print(_renderer);
    }

    // Update is called once per frame
    void Update()
    {
        if (inLight == false)
        {
            _currentColor = Color.Lerp(healthyColor, deathColor, Mathf.PingPong(Time.time, 1));
            _renderer.material.color = _currentColor;
        }
        print(inLight);
    }
}
