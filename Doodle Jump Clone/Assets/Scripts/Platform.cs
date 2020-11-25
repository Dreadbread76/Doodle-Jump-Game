using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    private PLAYER player;
    private GameObject playerEntity;

   
    private void Start()
    {
        playerEntity = GameObject.FindGameObjectWithTag("Player");
        
    }

    private void Update()
    {
        if(playerEntity.transform.position.y > transform.position.y)
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }



    // Start is called before the first frame update
    public void MoveDown(float downSpeed)
    {
        transform.position -= transform.up * downSpeed;
    }

    // Update is called once per frame
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (PLAYER.isJumping && player.platform != this)
        {
            PlatformManager manager = FindObjectOfType<PlatformManager>();
            manager.MovePlatformsDown();
        }
    }
}
