using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject door;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Player"))
        {
            //otwarcie drzwi 
            door.SetActive(false);
            //znikanie klucza przy kolizji
            //gameObject.SetActive(false);
            //zniszczenie klucza przy kolizji
            Destroy(gameObject);
        }

    }
}

