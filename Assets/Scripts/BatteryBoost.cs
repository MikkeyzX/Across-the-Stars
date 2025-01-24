using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BatteryBoost : MonoBehaviour
{

    public Flashlight flashlight;
    public float chargeValue; 
    private MeshRenderer meshRenderer;
    private bool active;
    public float respawnTime;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        active = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Player") && active == true)
        {
            flashlight.Charger(chargeValue);
        
            meshRenderer.enabled = false;

            active = false;

            StartCoroutine(Reactivate());
        }
    }

    private IEnumerator Reactivate()
    {
        yield return new WaitForSeconds(respawnTime);

        meshRenderer.enabled = true;

        active = true;

    }
}


