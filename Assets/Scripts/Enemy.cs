using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    private UnityEngine.AI.NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
    

    private void Update()
    {
        _agent.SetDestination(player.transform.position);
    }
}
