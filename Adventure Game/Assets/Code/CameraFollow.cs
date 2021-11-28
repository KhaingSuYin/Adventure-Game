using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    GameObject player;

    Vector3 offset = new Vector3(7.0f, 10.0f, 0);
    Vector3 currOffset = new Vector3(7.0f, 10.0f, 0);

    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void LateUpdate()
    {
        float rotateY = player.transform.eulerAngles.y;
        Vector3 targetOffset = Quaternion.Euler(0, rotateY + 90, 0) * offset;
        currOffset = Vector3.SmoothDamp(currOffset, targetOffset, ref velocity, 3.0f, 1.5f);

        transform.position = player.transform.position + currOffset;
        transform.LookAt(player.transform);
    }
}