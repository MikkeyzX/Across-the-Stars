using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Flashlight : MonoBehaviour
{
    private Light light; 
    public float batteryLife;
    public float maxBatteryLife = 60f;
    public Slider slider;
    public AudioSource keySound;
    
    private void Awake()
    {
        light = GetComponentInChildren<Light>();
        batteryLife = maxBatteryLife;

    }

    private void Update()
    {
        if(UnityEngine.Input.GetMouseButtonDown(0))
        {
            ToggleLight();
            keySound.Play();
        }
        
        HandleBatteryLife();

    }


    private void ToggleLight()
    {
        if(light.enabled == false && batteryLife > 0f)
        {
            light.enabled = true;
        }
        else
        {
            light.enabled = false;
        }
    }

    private void HandleBatteryLife()
    {
        if(light.enabled == true)
        {
            batteryLife = batteryLife - 1f * Time.deltaTime;
            //batteryLife -= 1f; (robi to samo)
            
            if(batteryLife <= 0f)
            {
                light.enabled = false;
            }                   
        }
        
        slider.value = batteryLife / maxBatteryLife;
    }
    
    public void Charger(float value)
    {
        batteryLife = batteryLife + value;
        
        if(batteryLife > maxBatteryLife)
        {
            batteryLife = maxBatteryLife;
        }
    }
}

