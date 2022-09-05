using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissileDestroy : MonoBehaviour
{
    public Vector3 baseLoc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, baseLoc, 3 * Time.deltaTime);
        if(transform.position.y < -3.55f)
        {
            Destroy(this.gameObject);
        }
        //GetComponent<Rigidbody2D>().velocity = transform.forward * 2 * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Castle" || collision.gameObject.tag == "FriendMissile")
        {
            Destroy(this.gameObject);
        }
    }
}
