using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerData
{
    public int newScore;
    public int[] savedScores = new int[7];
    
    public PlayerData (PLAYER player)
    {
        newScore = PLAYER.score;

        if(player.data !=  null && player.data.savedScores != null && player.data.savedScores.Length != 0)
        {
            savedScores = player.data.savedScores;
        }
        

        NewScore(PLAYER.score);
    }


    void NewScore(int newScore)
    {
        int nextScore = newScore;

        for (int i = 0; i < savedScores.Length; i++)
        {

            if (nextScore > savedScores[i])
            {

                int temp = savedScores[i];
                savedScores[i] = nextScore;
                nextScore = temp;
                
            }
        }


        /*
        for ( int i = 0; i < savedScores.Length; i++)
        {
            if(newScore > savedScores[i])
            {
                if (i+1 < savedScores.Length)
                {
                    savedScores[i+1] = savedScores[i];
                }

                savedScores[i] = newScore;

                Debug.Log(newScore);
            }
        }*/
        }

    /*
    void thismethod()
    {

    }

    void thismethod(int x)
    {

    }*/

}
