using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    private UnityEngine.AI.NavMeshAgent _agent;
    private MeshRenderer meshRenderer;
    public AudioSource XraySound;


    private IEnumerator TimerFunc()
    {
        while (true)
        {
        yield return new WaitForSeconds(2);
        foreach (Transform child in transform)
            child.gameObject.SetActive(false);
              
        }
        
    }
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        _agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    private void Start()
    {
        foreach (Transform child in transform)
            child.gameObject.SetActive(false);
    }
    
    public void AddXrayCount()
        {Global.XrayAmount += 1; }

    private void Update()
    {
        
        if (player != null)
        {
            _agent.SetDestination(player.transform.position);
        }

        if (Input.GetKeyDown("space"))
        {
            if (Global.XrayAmount > 0)
            {
                XraySound.Play();
                Global.XrayAmount -= 1;
                foreach (Transform child in transform)
                    child.gameObject.SetActive(true);
                StartCoroutine(TimerFunc());

            }

        }
    }
}
