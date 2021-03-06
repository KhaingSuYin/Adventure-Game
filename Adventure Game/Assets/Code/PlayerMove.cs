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
    public AudioClip alarm;
    public AudioClip BGM;
    private AudioManager AM;
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
        AM = FindObjectOfType<AudioManager>();
        if (SceneManager.GetActiveScene().name == "Level3")
        {
            keys = GameObject.FindGameObjectsWithTag("Key3");
            keys = keys.OrderBy(p => p.name).ToArray();
            if (PublicVars.L3keys > 0)
            {
                for (int i = 0; i < PublicVars.L3keys; ++i)
                {
                    print(keys[i].name + "Destroyed");
                    DestroyImmediate(keys[i]);
                }
            }
        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            keys = GameObject.FindGameObjectsWithTag("Key2");
            keys = keys.OrderBy(p => p.name).ToArray();
            if (PublicVars.L2keys > 0)
            {
                for (int i = 0; i < PublicVars.L2keys; ++i)
                {
                    print(keys[i].name + "Destroyed");
                    DestroyImmediate(keys[i]);
                }
            }
        }
        else if (SceneManager.GetActiveScene().name == "Level1")
        {
            keys = GameObject.FindGameObjectsWithTag("Key");
            keys = keys.OrderBy(p => p.name).ToArray();
            if (PublicVars.L1keys > 0)
            {
                for (int i = 0; i < PublicVars.L1keys; ++i)
                {
                    print(keys[i].name + "Destroyed");
                    DestroyImmediate(keys[i]);
                }
            }
        }

        agent.Warp(PublicVars.position);
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
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            Destroy(other.gameObject);
            PublicVars.L1keys++;
            PublicVars.hasKey = true;
            PublicVars.position = transform.position;
            PublicVars.position.y = 0;
            SceneManager.LoadScene("Puzzle" + PublicVars.L1keys);
        }
        else if (other.gameObject.CompareTag("Key2"))
        {
            Destroy(other.gameObject);
            PublicVars.L2keys++;
            PublicVars.hasKey = true;
            PublicVars.position = transform.position;
            PublicVars.position.y = 0;
            SceneManager.LoadScene("Maze" + (PublicVars.L2keys + 3));
        }
        else if (other.gameObject.CompareTag("Key3"))
        {
            Destroy(other.gameObject);
            PublicVars.L3keys++;
            PublicVars.hasKey = true;
            PublicVars.position = transform.position;
            PublicVars.position.y = 0;
            SceneManager.LoadScene("Maze" + PublicVars.L3keys);
        }
        else if (other.gameObject.CompareTag("Riddle"))
        {
            Destroy(other.gameObject);
            riddle = true;
        }
        else if (other.gameObject.CompareTag("Alarm"))
        {
            Destroy(other.gameObject);
            PublicVars.alarm = true;
            AM.ChangeBGM(alarm);
        }
        else if (other.gameObject.CompareTag("Vent"))
        {
            Destroy(other.gameObject);
            PublicVars.hidden = true;
            PublicVars.alarm = false;
            AM.ChangeBGM(BGM);
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
