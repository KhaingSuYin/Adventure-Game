using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
	public int leveltoLoad = 1;
	
	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Ball")){
			SceneManager.LoadScene("Level3");
		}
	}
}
