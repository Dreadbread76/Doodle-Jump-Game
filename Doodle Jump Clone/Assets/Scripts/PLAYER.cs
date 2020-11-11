using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYER : MonoBehaviour
{

    Rigidbody2D rigi;
    Transform playerTrans;

    public static bool isJumping;

    public GameObject platform;

    public static Vector2 position = new Vector2();

    


    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
        playerTrans = GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        position = transform.position;
    }
}
