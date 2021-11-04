using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent agent;
    GameObject player;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(LookForPlayer());
    }

    IEnumerator LookForPlayer()
    {
        while (true)
        {
            yield return new WaitForSeconds(.5f);
            agent.destination = player.transform.position;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
