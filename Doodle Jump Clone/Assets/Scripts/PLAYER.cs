using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PLAYER : MonoBehaviour
{
    #region Variables
    Rigidbody2D rigi;
    Transform playerTrans;

    public static bool isJumping;

    public GameObject platform;

    public static Vector2 position = new Vector2();

    public float speed;
    public float boundary;
    public float teleportPos;

    int score;

    public Text scoreText;

    #endregion
    #region Start
    void Start()
    {

        rigi = GetComponent<Rigidbody2D>();
        playerTrans = GetComponent<Transform>();

        
        
    }
    #endregion
    #region Update 
    void Update()
    {
        #region Boundaries
        position = transform.position;

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
        if (Input.GetKey(KeyCode.A))
        {
            rigi.AddForce(playerTrans.right * -speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigi.AddForce(playerTrans.right * speed);
        }
        #endregion
        #region Scoring
        int score = (int)position.y;
        scoreText.text = "" + score;
        #endregion
    }
    #endregion
}
