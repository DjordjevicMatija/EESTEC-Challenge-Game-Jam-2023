using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionBoss : MonoBehaviour
{

    public HealthBar health;
    private float hp;

    public ParentMovement parentMovement;

    private void Start()
    {
        hp = 100f;
        health.SetMaxHealth(hp);
        health.setHealth(hp);
    }

    private void OnTriggerEnter(Collider collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.tag == "BulletPlayer")
        {
            TakeDamage(20);
        }
    }

    private void TakeDamage(int dmg)
    {
        hp -= dmg;
        if (hp < 0)
            hp = 0;
        health.setHealth(hp);
        if (hp == 0)
            GameOver();
    }

    private void GameOver()
    {
        Destroy(gameObject);
        health.gameObject.SetActive(false);
        parentMovement.canMove = true;
    }
}
