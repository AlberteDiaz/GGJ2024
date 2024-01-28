using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicaBrillo : MonoBehaviour
{
    public Slider slider;
    public float slidervalue;
    public Image ponerBrillo;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("brillo", 0.5f);
        ponerBrillo.color = new Color(ponerBrillo.color.r, ponerBrillo.color.g, ponerBrillo.color.b, slider.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSlider(float value)
    {
        slidervalue = value;
        PlayerPrefs.SetFloat("brillo", slidervalue);
        ponerBrillo.color = new Color(ponerBrillo.color.r, ponerBrillo.color.g, ponerBrillo.color.b, slider.value);
    }
}
