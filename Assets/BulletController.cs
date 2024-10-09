using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;
    public float lifeTime; // seconds


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }

        // if bullet touches a stone, destroy both
        GameObject[] stones = GameObject.FindGameObjectsWithTag("Stone");
        foreach (GameObject stone in stones)
        {
            if (Vector3.Distance(transform.position, stone.transform.position) < 0.5)
            {
                Destroy(stone);
                Destroy(gameObject);
            }
        }
        

    }
}
