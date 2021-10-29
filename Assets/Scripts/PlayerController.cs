using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float posX;
    private float posY;
    private float xStrafe;
    private float farRightX;
    private float farLeftX;
    private float maxES;
    private float currentES;
    public GameObject Player;
    
    // Start is called before the first frame update
    void Start()
    {
        posX = 2f;
        posY = 0.84f;
        xStrafe = 0.66f;
        farRightX = posX + 2 * xStrafe;
        farLeftX = posX - 2 * xStrafe;
        Player.transform.position = new Vector2 (posX, posY);

        maxES = 100f;
        currentES = maxES;
        
        /* debug messages I used to figure out why the player could move off the left side of the screen instead of stopping.
        Debug.Log("Right strafe limit: " + farRightX);
        Debug.Log("Left strafe limit: " + farLeftX);
        Debug.Log("X strafe amount: " + xStrafe); */
    }

    // Update is called once per frame
    void Update()
    {
        if (currentES != 0f)
        {
            HandleStrafe();
        }
        else
        {
            GameOver();
        }
        
    }

    private void HandleStrafe()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && posX != farRightX)
        {
            posX += xStrafe;
            Player.transform.position = new Vector2 (posX, posY);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && posX > farLeftX) //this was originally posX != farLeftX but due to floating point arithmetic farLextX is 0.67999999999999 etc instead of 0.68 so the > circumvents this.
        {
            posX -= xStrafe;
            Player.transform.position = new Vector2 (posX, posY);
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over");
    }
}
