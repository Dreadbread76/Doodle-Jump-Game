﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject player;
    public GameObject lava;
    private List<Platform> platforms = new List<Platform>();
    public GameObject platformObj;
    private float prevPosStart = 0.8f;
    private float prevPosGap = 0.8f;
    Vector3 spawnPos;
    Vector3 prevPos;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        prevPos.y = spawnPos.y + prevPosStart;
    }
    
    public void Update()
    {
        //Spawn a new platform every time prevPos is moved
        if(player.transform.position.y > prevPos.y)
        {
            NewPlatform();
            prevPos.y = player.transform.position.y + prevPosGap;

        }
    }
    public void NewPlatform()
    {
        //Set spawn position to a random position 
        spawnPos = new Vector3(Random.Range(8, -8) + player.transform.position.x, lava.transform.position.y + Random.Range(11,17), 0);
        GameObject newObj = Instantiate(platformObj, spawnPos, Quaternion.identity);
        platforms.Add(newObj.GetComponent<Platform>());
    }

    

}
