using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //prefabs
    public GameObject stonePrefab;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        // spawn a stone every 1 seconds
        InvokeRepeating("SpawnStone", 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        // destroy stone if it goes out the screen
        GameObject[] stones = GameObject.FindGameObjectsWithTag("Stone");
        foreach (GameObject stone in stones)
        {
            // get the screen position of the stone
            Vector3 screenPos = cam.WorldToScreenPoint(stone.transform.position);
            // if the stone is out of the screen 100 pixels, destroy it
            if (screenPos.x < -100 || screenPos.x > Screen.width + 100 || screenPos.y < -100 || screenPos.y > Screen.height + 100)
            {
                Destroy(stone);
            }

        }
    }

    public void SpawnStone()
    {
        //spawn a stone at a random position outside the screen 50 pixels
        Vector3 screenPos = new Vector3();
        int side = Random.Range(0, 4);
        switch (side)
        {
            case 0:
                screenPos.x = -50;
                screenPos.y = Random.Range(0, Screen.height);
                break;
            case 1:
                screenPos.x = Screen.width + 50;
                screenPos.y = Random.Range(0, Screen.height);
                break;
            case 2:
                screenPos.x = Random.Range(0, Screen.width);
                screenPos.y = -50;
                break;
            case 3:
                screenPos.x = Random.Range(0, Screen.width);
                screenPos.y = Screen.height + 50;
                break;
        }
        Debug.Log(screenPos);
        Vector3 worldPos = cam.ScreenToWorldPoint(screenPos);
        // z = 0
        worldPos.z = 0;
        Debug.Log(worldPos);  
        Instantiate(stonePrefab, worldPos, Quaternion.identity);


    }
}
