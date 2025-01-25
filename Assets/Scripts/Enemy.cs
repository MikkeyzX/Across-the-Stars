using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    private UnityEngine.AI.NavMeshAgent _agent;
    private MeshRenderer meshRenderer;
    public AudioSource XraySound;
    public GameObject Outline;
    public GameObject Model;
    public Rigidbody rb;

    private IEnumerator TimerFunc()
    {
        while (true)
        {
        yield return new WaitForSeconds(2);
        Outline.SetActive(false);
        yield break;
        }
        
    }
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        _agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        Model.SetActive(true);
    }

    private void Start()
    {
        Outline.SetActive(false);
        Model.SetActive(true);
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
                Outline.SetActive(true);
                StartCoroutine(TimerFunc());

            }

        }
        var velocity = rb.velocity;
        Model.transform.LookAt(player.transform.position);
    }
}
