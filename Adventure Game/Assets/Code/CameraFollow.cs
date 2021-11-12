using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    GameObject player;
    int turnSpeed = 1;

    Vector3 offset = new Vector3(3.0f, 11.8f, 0.2f);
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        // offset = transform.position - player.transform.position;
        // print(offset);
        Quaternion rotateDiff = transform.rotation - player.transform.rotation;
    }

    void LateUpdate()
    {
        transform.rotation = player.transform.rotation;
        Vector3 currOffset = transform.rotation * offset;
        transform.position = player.transform.position + currOffset;
        transform.LookAt(player.transform);
    }
}
