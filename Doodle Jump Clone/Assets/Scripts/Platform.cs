using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    private PLAYER player;

    public Transform allPlatforms;

    // Start is called before the first frame update
    public void MoveDown(int downSpeed)
    {
        if (PLAYER.position.y >= 100)
        {

        }
        else
        {

        }
    }

    // Update is called once per frame
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (PLAYER.isJumping && player.platform)
        {

        }
    }
}
