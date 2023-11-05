using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BossMovement : MonoBehaviour
{
    public Transform tf;
    public bool canMove { get; set; }

    private void Start()
    {
        canMove = false;    
    }

    private void Update()
    {
        if (!canMove)
            return;
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        canMove = false;
        System.Random rnd = new System.Random();
        int n = rnd.Next(8);
        Vector3 distance = new Vector3();
        if (n > 4 && tf.position.x < 0.5f)
            distance = new Vector3(0.5f, 0f);
        else if(n < 4 && tf.position.x > -0.5f)
            distance = new Vector3(-0.5f, 0f);
        tf.position += distance;
        n = rnd.Next(5);
        yield return new WaitForSeconds(n * 0.1f + 1f);
        canMove = true;
    }
}
