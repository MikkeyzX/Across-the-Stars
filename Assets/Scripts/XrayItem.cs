using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class XrayItem : MonoBehaviour
{

    private MeshRenderer meshRenderer;
    private bool active;
    public int XrayAmount;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        active = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player") && active == true)
        {

            meshRenderer.enabled = false;
            XrayAmount += 1;
            print(XrayAmount);
            active = false;
        }
    }

}
