using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

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
        //agent.destination = new Vector3(PublicVars.posX, PublicVars.posY, PublicVars.posZ);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out hit, 200))
            {
                agent.destination = hit.point;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.name);
        if (other.gameObject.CompareTag("Key"))
        {
            Destroy(other.gameObject);
            PublicVars.hasKey = true;
            PublicVars.posX = agent.transform.position.x;
            PublicVars.posY = agent.transform.position.y;
            PublicVars.posZ = agent.transform.position.z;
            SceneManager.LoadScene("Maze", LoadSceneMode.Single);
        }
    }
}
