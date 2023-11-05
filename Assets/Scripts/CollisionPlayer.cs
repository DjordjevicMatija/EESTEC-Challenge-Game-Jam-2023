using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CollisionPlayer : MonoBehaviour
{
    public static bool weak;

    public HealthBar health;
    private float hp;
    private int coins = 0;

    [SerializeField] private GameObject counter;
    private int sceneID;

    private void Start()
    {
        hp = 100f;
        health.SetMaxHealth(hp);
        health.setHealth(hp);
        sceneID = SceneManager.GetActiveScene().buildIndex;
    }


    private void OnTriggerEnter(Collider collision)
    {
        GameObject obj = collision.gameObject;
        switch (obj.tag)
        {
            case "BulletBoss":
                TakeDamage(20);
                break;
            case "Coin":
                CollectCoin(obj);
                break;
            case "Wall":
                GameOver();
                break;
            case "Fire":
                if (sceneID == 3 && weak)
                    TakeDamage(15);
                else if (sceneID == 3 && !weak)
                    TakeDamage(5);
                else
                    TakeDamage(10);
                break;
            case "Ice":
                if (sceneID == 2 && weak)
                    TakeDamage(15);
                else if (sceneID == 2 && !weak)
                    TakeDamage(5);
                else
                    TakeDamage(10);
                break;
            default:
                break;

        }
    }

    private void CollectCoin(GameObject obj)
    {
        coins++;
        counter.GetComponent<TextMeshProUGUI>().text = coins.ToString();
        Destroy(obj);
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
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }
}
