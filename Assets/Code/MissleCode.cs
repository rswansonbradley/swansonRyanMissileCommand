using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleCode : MonoBehaviour
{
    public GameObject explosion;
    public Vector3 maxHeight;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Visible", 0.08f);
        maxHeight = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Invoke("Remove", 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y >= maxHeight.y)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    void Remove()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    void Visible()
    {
        GetComponent<TrailRenderer>().enabled = true;
        GetComponent<SpriteRenderer>().enabled = true;
    }
}
