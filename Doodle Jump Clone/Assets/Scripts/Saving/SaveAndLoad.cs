using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoad : MonoBehaviour
{
    public static PLAYER player;
    public static void SaveScore()
    {
 
        PlayerBinary.SavePlayer(player);
    }
    public static void LoadScore()
    {
        PlayerData data = PlayerBinary.LoadPlayer();

        if (data == null)
        {
            return;
        }
        
        
    }
}
