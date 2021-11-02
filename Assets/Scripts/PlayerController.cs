using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float posX;
    private float posY;
    public float xStrafe;
    private float farRightX;
    private float farLeftX;
    private float quitTimer;
    private float barX;
    private float barY;
    private float esDrop;
    public int maxES;
    public int currentES;
    public GameObject Player;
    public GameObject text;
    public GameObject ESbar;
    
    // Start is called before the first frame update
    void Start()
    {
        posX = 2f;
        posY = 0.84f;
        xStrafe = 0.66f;
        farRightX = posX + 2 * xStrafe;
        farLeftX = posX - 2 * xStrafe;
        Player.transform.position = new Vector2 (posX, posY);

        maxES = 100;
        currentES = maxES;
        barX = 3.83f;
        barY = 1.83f;
        esDrop = 0.27f;
        
        ESbar.transform.position = new Vector2 (barX, barY);
        
        /* debug messages I used to figure out why the player could move off the left side of the screen instead of stopping.
        Debug.Log("Right strafe limit: " + farRightX);
        Debug.Log("Left strafe limit: " + farLeftX);
        Debug.Log("X strafe amount: " + xStrafe); */
    }

    // Update is called once per frame
    void Update()
    {
        if (currentES > 0)
        {
            HandleStrafe();
        }
        else
        {
            if (quitTimer == 0)
            {
                GameObject note = Instantiate(text,new Vector2(2f,0f),Quaternion.identity);
                Debug.Log("Game Over");
            }
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

    
    private void OnTriggerEnter2D(Collider2D hit)
    {
        
        if (hit.gameObject.tag == "Bullet")
        {
            currentES -= hit.GetComponent<BulletController>().damage;
            barY -= esDrop;
            ESbar.transform.position = new Vector2 (barX, barY);
            Debug.Log("Emotional Stability: " + currentES);
        }
        
    }

    private void GameOver()
    {
        quitTimer += Time.deltaTime;
        if (quitTimer > 3f)
        {
            Application.Quit();
        }
    }
}
