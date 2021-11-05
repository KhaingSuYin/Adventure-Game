using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent agent;
    Camera mainCam;
    public Transform spawnPoint;
    public GameObject bulletPrefab;
    float startTime;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startTime = Time.time;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (Time.time - startTime < .2f)
            {
                RaycastHit hit;
                if (Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out hit, 200))
                {
                    agent.destination = hit.point;
                }
            }
            /*else
            {
                RaycastHit hit;
                if (Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out hit, 200))
                {
                    transform.LookAt(hit.point);
                    GameObject newBullet = Instantiate(bulletPrefab, spawnPoint.position, transform.rotation);
                    newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * 200);
                }
            }*/
        }
    }

    void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.name);
        if (other.gameObject.CompareTag("Key"))
        {
            Destroy(other.gameObject);
            
            PublicVars.hasKey = true;
        }
    }
}
