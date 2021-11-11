using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using System.Linq;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent agent;
    Camera mainCam;
    public GameObject[] keys;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        mainCam = Camera.main;
        agent.transform.position = new Vector3(PublicVars.posX, PublicVars.posY, PublicVars.posZ);
        keys = GameObject.FindGameObjectsWithTag("Key");
        keys = keys.OrderBy(p => p.name).ToArray();
        if (PublicVars.L3keys > 0)
        {
            for (int i = 0; i < PublicVars.L3keys; ++i)
            {
                Destroy(keys[i]);
            }
        }
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
            PublicVars.L3keys++;
            PublicVars.hasKey = true;
            PublicVars.posX = agent.transform.position.x;
            PublicVars.posY = agent.transform.position.y;
            PublicVars.posZ = agent.transform.position.z;
            SceneManager.LoadScene("Maze"+ PublicVars.L3keys, LoadSceneMode.Single);
        }
    }
}
