using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector3 dest = new Vector3(1, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        dest = transform.position;
        slideIfYouCan();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 delta = dest - transform.position;
        Vector3 step = delta.normalized * Time.deltaTime;

        if (step.magnitude < delta.magnitude)
        {
            transform.position += step;
        }
        else
        {
            transform.position = dest;
        }
    }
    public void slideIfYouCan()
    {
        dest = transform.position + new Vector3(1, 0, 0);
    }
}
