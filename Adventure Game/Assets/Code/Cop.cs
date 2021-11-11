using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cop : MonoBehaviour
{
    Vector3 startPos;
    enum State
    {
        leftright,
        updown,
        random
    };
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        StartCoroutine(NewPos(State.leftright));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator NewPos(State state)
    {
        while (true)
        {
            Vector3 currentPos = transform.position;
            Vector3 endPos = new Vector3(startPos.x + Random.Range(-4, 4), startPos.y, startPos.z + Random.Range(-4, 4));

            transform.rotation = Quaternion.LookRotation((endPos - currentPos).normalized);

            float t = 0;
            while (t < 1)
            {
                transform.position = Vector3.Lerp(currentPos, endPos, t);
                t += Time.deltaTime;

                yield return null;
            }
            yield return new WaitForSeconds(.2f);
        }
    }
}
