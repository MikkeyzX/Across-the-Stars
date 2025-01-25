using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class XrayItem : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private bool active;
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        active = true;
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player") && active == true)
        {
            Global.XrayAmount += 1;
            
            meshRenderer.enabled = false;
            active = false;
        }
    
    }

}
