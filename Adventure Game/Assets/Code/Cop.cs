using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(NewPos());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator NewPos()
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
