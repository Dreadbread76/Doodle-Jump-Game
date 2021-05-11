using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerData
{
    #region Variables
    public int newScore;
    public int[] savedScores = new int[7];
    #endregion
    #region Player Data
    public PlayerData (PLAYER player)
    {
        newScore = PLAYER.score;

        if(player.data !=  null && player.data.savedScores != null && player.data.savedScores.Length != 0)
        {
            savedScores = player.data.savedScores;
        }
        

        NewScore(PLAYER.score);
    }
#endregion
    #region  New Highscore




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


   
    }
    #endregion
  

}
