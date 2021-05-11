using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PLAYER : MonoBehaviour
{
    #region Variables
    [Header("Player Stuff")]
    Rigidbody2D rigi;
    public Transform playerTrans;
    public PlayerData data;
    public static bool isJumping;
    public Animator anim;
    public GameObject platform;
    public static Vector2 position = new Vector2();
    public float speed;
    public float boundary;
    public float teleportPos;
    public bool dead;

    
    [Header("Scoring")]
    public static int score;
    public GameObject scoreMenu;
    public Text scoreText;
    public Text[] highscoresText = new Text[7];


    [Header("Lava")]
    public GameObject lava;
    private float lavaOffset;
    

    #endregion
    #region Start
    void Start()
    {
        //Set all components in the starting position
        rigi = GetComponent<Rigidbody2D>();
        playerTrans = GetComponent<Transform>();
        scoreMenu.SetActive(false);

        lavaOffset = transform.position.y - lava.transform.position.y;
        SaveAndLoad.LoadScore();
        dead = false;
    }
    #endregion
    #region Update 
    void Update()
    {
        #region Boundaries
        
        position = transform.position;
        
        // Move the player to the other side of the screen if the player goes off screen
        if(position.x <= -boundary)
        {
            position.x = -teleportPos;
        }
        if (position.x >= boundary)
        {
            position.x = teleportPos;
        }

        transform.position = position;

        #endregion
        #region Inputs
        
        //Move left
        if (Input.GetKey(KeyCode.A))
        {
            rigi.AddForce(playerTrans.right * -speed);
        }
        //Move right
        if (Input.GetKey(KeyCode.D))
        {
            rigi.AddForce(playerTrans.right * speed);
        }
        if(position.y > 4)
        {
            isJumping = true;
        }
        #endregion
        #region Scoring

        //if the position is higher than the score, set the score to the new height

        if((int)position.y > score)
            score = (int)position.y;
        scoreText.text = "Score: " + score + "m";
        #endregion





        //float lavaHeight = lava.transform.position.y + 10;
        //if (position.y > lavaHeight)
        //{
        //    // if velocity.y > 0 
        //    //  set lava height to Player.Position + Offset (y)
        //    // else
        //    //  no longer move the lava (parenting not required)
        //}
    }
    public void GetHighscores()
    {
        
        for (int i = 0; i < highscoresText.Length; i++)
        {
           
            if(i >= data.savedScores.Length)
            {
                break;
            }
            highscoresText[i].text = data.savedScores[i].ToString();
        }
    }
    #endregion
    #region Lava
    public void MoveLava()
    {
        // Calculate the amount to move down, based on the current position and the offset
        Vector3 lavaPos = lava.transform.position;
        lavaPos.y = transform.position.y - lavaOffset;

        // If we are going to move down, ignore the function
        if(position.y < lava.transform.position.y)
            return;

        StartCoroutine(LavaMove(lavaPos));
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Kill when touching lava
        if (collision.gameObject.CompareTag("Lava"))
        {
            Death();
        }
       //Trigger Squish and Stretch Animation when the the player hits the platform
        if (collision.gameObject.CompareTag("Platform"))
        {


            anim.SetTrigger("groundHit");

        }
    }

    // OnCollisionExit2D is called when this collider2D/rigidbody2D has stopped touching another rigidbody2D/collider2D (2D physics only)
    
    IEnumerator LavaMove(Vector3 newPos)
    {
        Vector3 currentPos = lava.transform.position;
        float timer = 0;
        float maxTime = 1;

        // Loop until the timer has run out
        while (timer < maxTime)
        {
            // Calculate the amount to move along the lerp, based on the current time, divided by the maxtime
            // giving us a number from 0-1
            float factor = Mathf.Clamp01(timer / maxTime);
            lava.transform.position = Vector3.Lerp(currentPos, newPos, factor);

            // Wait until the frame has completed, add deltaTime to the timer, and restart
            yield return new WaitForEndOfFrame();

            timer += Time.deltaTime;
        }

        lava.transform.position = newPos;
    }
    #endregion
    #region Death and Revive
    void Death()
    {
        //Get the Highscores
        dead = true;
        SaveAndLoad.SaveScore();
        GetHighscores();
        //Set timescale to zero and bring up highscores
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        scoreMenu.SetActive(true);
    }
    public void Revive()
    {

        //Set timescale to 1 and reload scene
        dead = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
   
    #endregion

}
