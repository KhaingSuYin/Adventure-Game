using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string levelToLoad;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (PublicVars.hasKey)
            {
                PublicVars.hasKey = false;
                if (levelToLoad != "")
                {
                    switch (levelToLoad)
                    {
                        case "Level2":
                        case "Level3":
                            PublicVars.position = new Vector3(32.5f, 0f, 5.5f);
                            SceneManager.LoadScene(levelToLoad);
                            break;
                        case "End":
                            SceneManager.LoadScene("End");
                            break;
                    }
                }
                Destroy(gameObject);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
