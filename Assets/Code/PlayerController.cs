using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /* READ ME
     * FYI: A lot of this code is taken from another project of mine.
     * And that code is made using the help of code I found from the internet
     */
    private Vector3 target;
    public GameObject player;
    public GameObject rocketPrefab;

    public float bulletSpeed = 15f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Find mouse Position
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        //Finds difference in distance from mouse to player
        Vector3 difference = target - player.transform.position;
        //Creates a rotation that is facing towards the mouse
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg - 90;
        //Rotates Z rotation of the player towards the mouse
        player.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

        if (Input.GetMouseButtonDown(0))
        {
            //Turns the difference into a specific length value
            float distance = difference.magnitude;
            //Creates a value equivalent to a line from the player and the mouse
            Vector2 direction = difference / distance;
            direction.Normalize();
            //Activates the fire rocket code while providing direction and rotation
            fireRocket(direction, rotationZ);
        }
    }
    void fireRocket(Vector2 direction, float rotationZ)
    {
        //Creates a rocket
        GameObject r = Instantiate(rocketPrefab) as GameObject;
        //Sets rocket position to player position
        r.transform.position = player.transform.position;
        //r.transform.localPosition = (player.transform.localPosition + new Vector3(0,.2f,0));
        //Rotates the rocket towards the mouse
        r.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        //Sends the rocket flying
        r.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        
    }
}
