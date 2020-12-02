using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerData
{
    public int newScore;
    public int[] savedScores = new int[8];
    
    public PlayerData (PLAYER player)
    {
        newScore = PLAYER.score;

        for ( int i = 0; i < savedScores.Length; i++)
        {
            if(newScore > savedScores[i])
            {
                savedScores[i] = savedScores[i++];
            }
        }
       
       
    }

    
}
