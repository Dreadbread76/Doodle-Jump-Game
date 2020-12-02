using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject player;
    private List<Platform> platforms = new List<Platform>();
    public GameObject platformObj;
    Vector3 spawnPos;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void MovePlatformsDown()
    {
        foreach(Platform platform in platforms)
        {
            platform.MoveDown(5);
        }
    }

    public void NewPlatform()
    {

        spawnPos = new Vector3(Random.Range(-7, 7) + player.transform.position.x, 4 + player.transform.position.y, 0);
        GameObject newObj = Instantiate(platformObj, spawnPos, Quaternion.identity);
        platforms.Add(newObj.GetComponent<Platform>());
    }

    

}
