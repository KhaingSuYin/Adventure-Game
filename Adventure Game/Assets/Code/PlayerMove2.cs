using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove2 : MonoBehaviour
{

    public int playerNum = 1;

    public int speed = 10;

    Rigidbody rb;

    bool isAlive = true;

    string vert, horiz;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        vert = "Vertical" + playerNum;
        horiz = "Horizontal" + playerNum;

        StartCoroutine(WaitToMove());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isAlive)
        {
            return;
        }

        float zSpeed = Input.GetAxis(vert) * speed;
        float xSpeed = Input.GetAxis(horiz) * speed;
        rb.AddForce(new Vector3(xSpeed, 0, zSpeed));

        if(transform.position.y < -30)
        {
            isAlive = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jump"))
        {
            jump();
        }

    }

    void jump()
    {
        rb.AddForce(new Vector3(0, 1000, 0));
    }

    IEnumerator WaitToMove()
    {
        yield return new WaitForSeconds(.2f);
        isAlive = true;
    }
}
