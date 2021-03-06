using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using System.Linq;

public class PlayerMove1 : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent agent;
    Camera mainCam;
    public GameObject[] keys;
    public GUISkin guiSkin;
    bool riddle = false;
    Rect windowRect = new Rect(0, 0, 400, 380);
    private Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        mainCam = Camera.main;
        keys = GameObject.FindGameObjectsWithTag("Key");
        keys = keys.OrderBy(p => p.name).ToArray();
        if (PublicVars1.L3keys > 0)
        {
            for (int i = 0; i < PublicVars1.L3keys; ++i)
            {
                print(keys[i].name + "Destroyed");
                Destroy(keys[i]);
            }
        }
        agent.Warp(PublicVars1.position);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out hit, 200))
            {
                anim.SetBool("run", true);
                agent.destination = hit.point;
            }
        }

        if ((agent.transform.position - agent.destination).magnitude < 0.1)
        {
            anim.SetBool("run", false);
            agent.destination = agent.transform.position;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.name);
        if (other.gameObject.CompareTag("Key"))
        {
            Destroy(other.gameObject);
            PublicVars1.L3keys++;
            PublicVars1.hasKey = true;
            PublicVars1.position = gameObject.transform.position;
            SceneManager.LoadScene("Puzzle" + PublicVars1.L3keys);
        }
        if (other.gameObject.CompareTag("Riddle"))
        {
            Destroy(other.gameObject);
            riddle = true;
        }
    }
    void OnGUI()
    {
        if (riddle)
        {
            GUI.skin = guiSkin;
            Rect windowRect = new Rect(Screen.width / 4, Screen.height / 4, Screen.width / 2, Screen.height / 2);
            windowRect = GUI.Window(0, windowRect, DoMyWindow, "Solve the riddle");
        }
    }
    void DoMyWindow(int windowID)
    {
        GUI.Label(new Rect(Screen.width / 8, Screen.height / 6, Screen.width / 2, Screen.height / 2), "<<  This is the right way!");
        GUI.Label(new Rect(Screen.width / 8, Screen.height / 4, Screen.width / 2, Screen.height / 2 - 10), "This way is Right!     >>");
    }
}
