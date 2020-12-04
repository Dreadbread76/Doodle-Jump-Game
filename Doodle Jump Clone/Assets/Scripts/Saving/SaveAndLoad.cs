using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoad : MonoBehaviour
{
    private static PLAYER player;
    public static void SaveScore()
    {
        if (player == null)
        {
            player = FindObjectOfType<PLAYER>();
        }

        if (player != null)
        {
            PlayerBinary.SavePlayer(player);
        }
    }
    public static void LoadScore()
    {
        PlayerData data = PlayerBinary.LoadPlayer();

        if(player == null)
        {
            player = FindObjectOfType<PLAYER>();
        }

        if (player!= null && data != null)
        {
            player.data = data;
        }
        else
        {
            player.data = new PlayerData(player);
        }
        
        
    }
}
