using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    private UnityEngine.AI.NavMeshAgent _agent;
    private MeshRenderer meshRenderer;
    public int XrayAmount;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        _agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
    

    private void Update()
    {
        if (player != null)
        {
            _agent.SetDestination(player.transform.position);
        }

        if (Input.GetKeyDown("space"))
        {
            if (XrayAmount > 0)
            {
                GameObject.GetChild().SetActive(true);
            }

        }
    }
}
