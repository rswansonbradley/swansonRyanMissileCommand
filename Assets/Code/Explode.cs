using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    int scaleChange = 0;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Remove", 0.50f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (scaleChange < 10)
        {
            transform.localScale += new Vector3(0.06f, 0.06f, 0);
        }
        else if (scaleChange > 13)
        {
            transform.localScale -= new Vector3(0.1f, 0.1f, 0);
        }
        scaleChange++;
    }

    void Remove()
    {
        Destroy(this.gameObject);
    }
}
