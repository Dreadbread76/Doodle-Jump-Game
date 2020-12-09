using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public PlayerData data;
    public Text[] highscores = new Text[7];

   /* public void GetHighscores()
    {
        for (int i = 0; i < highscores.Length; i++)
        {
            highscores[i].text =  data.savedScores[i].ToString();
           
        }
    }*/
}
