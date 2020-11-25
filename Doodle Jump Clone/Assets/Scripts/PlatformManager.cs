using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    private PLAYER player;
    private List<Platform> platforms = new List<Platform>();

    // Start is called before the first frame update
    public void MovePlatformsDown()
    {
        foreach(Platform platform in platforms)
        {
            platform.MoveDown(5);
        }
    }

   public void NewPlatform()
    {
        GameObject newObj = Instantiate(gameObject);
        platforms.Add(newObj.GetComponent<Platform>());
    }
    

}
