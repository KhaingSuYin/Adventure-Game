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
                Destroy(this.gameObject);
            }
            else if (PublicVars.hasKey)
            {
                PublicVars.hasKey = false;
                Destroy(this.gameObject);
                SceneManager.LoadScene("Level" + levelToLoad, LoadSceneMode.Single);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
