using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileCreator : MonoBehaviour
{
    public GameObject missile;
    public static GameObject[] target;
    int targetChoice;
    public static int restartVal = 6;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectsWithTag("Castle");
        InvokeRepeating("Create", 2.5f, 2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(restartVal == 0)
        {
            Invoke("EndGame", .5f);
        }
    }
    void Create()
    {
        //Chooses a target
        targetChoice = Random.Range(0,6);
        while (target[targetChoice] == null)
        {
            FindNewTarget();
        }
        //Creates a missile
        GameObject a = Instantiate(missile, new Vector3(Random.Range(-8,8), 5, 0), Quaternion.identity);
        a.GetComponent<EnemyMissileDestroy>().baseLoc = target[targetChoice].transform.position;
        //Creates a position to look at
        //Vector3 lookPos = target[targetChoice].transform.position - a.transform.position;
        //Creates a rotation value towards the previous position
        //var rotate = Quaternion.LookRotation(lookPos);
        //float b = 1;
        //a.transform.rotation = Quaternion.Euler(0f, 0f, b);

        Vector3 targ = target[targetChoice].transform.position;
        targ.z = 0f;

        Vector3 objectPos = a.transform.position;
        targ.x = targ.x - objectPos.x;
        targ.y = targ.y - objectPos.y;

        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
        a.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 270));

        //a.Rigidbody.velocity = -transform.forward * m_Speed;
        //a.GetComponent<Rigidbody2D>().velocity = transform.forward * 2 * Time.deltaTime;

        //a.transform.rotation = rotate;
    }

    void FindNewTarget()
    {
        targetChoice = Random.Range(0, 6);
    }

    void EndGame()
    {
        restartVal = 6;
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
