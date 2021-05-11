using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
#region Variables
    public PLAYER playerScript;
    private GameObject playerEntity;

   #endregion
   #region Start
    private void Start()
    {
        playerEntity = GameObject.FindGameObjectWithTag("Player");
        playerScript = playerEntity.GetComponent<PLAYER>();
    }
#endregion
#region Update

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
        
    if(this.transform.position.y < playerEntity.transform.position.y - 20 )
    {
        Destroy(transform.parent.gameObject);
    }

}

#endregion
#region OnCollisionEnter
   

    // Move the lava up when the colliding with a higher platform
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (PLAYER.isJumping && playerScript.platform != this)
        {
            PlatformManager manager = FindObjectOfType<PlatformManager>();
         //   manager.MovePlatformsDown();
            playerScript.MoveLava();
        }
        
    }
    #endregion
}
