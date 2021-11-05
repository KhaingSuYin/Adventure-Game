using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
                SceneManager.LoadScene(levelToLoad);
            }
            else if (PublicVars.hasKey)
            {
                PublicVars.hasKey = false;
                SceneManager.LoadScene(levelToLoad);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
