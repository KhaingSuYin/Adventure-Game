using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string levelToLoad;
    public bool locked = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!locked)
            {
                if (levelToLoad != "")
                {
                    SceneManager.LoadScene("Level" + levelToLoad);
                }
                Destroy(this.gameObject);
            }
            else if (PublicVars.hasKey)
            {
                if (levelToLoad != "")
                {
                    SceneManager.LoadScene("Level" + levelToLoad);
                }
                PublicVars.hasKey = false;
                Destroy(this.gameObject);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
