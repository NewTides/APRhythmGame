using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{
    //public EnemyController _bullet;
    public GameObject bullet;
    private float bulletInterval;
    private float timer;
    //private float bulletSize = 0.36f;
    public float startY;
    public float bulletX;
    //public Vector2 startPos;
    public bool[][] attackPattern; // an array of sets of x coordiantes
    
    
    // Start is called before the first frame update
    void Start()
    {
        //bullet starting y = 5.28f, ending y = 0.32f
        startY = 5.28f;
        bulletX = 2f;
        timer = 0f;
        bulletInterval = 0.66f;
        
        //_bullet = GetComponent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //Debug.Log("Timer: " + timer);
        if (timer > bulletInterval)
        {
            FirePattern();
            timer = 0f;
        }
        
    }

    private void FirePattern()
    {
        GameObject note = Instantiate(bullet,new Vector2(bulletX,startY),Quaternion.identity);
    }
}
