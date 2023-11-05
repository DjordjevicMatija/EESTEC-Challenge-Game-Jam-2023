using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ParentMovement : MonoBehaviour
{

    public PlayerShooting playerShooting;
    public Shooting bossShooting;
    public BossMovement bossMovement;
    public GameObject bossHealth;
    public float movespeed = 3.5f;
    [SerializeField] private GameObject canvas;

    public bool canMove { get; set; }
    private bool permitToMove = true;
    private bool stopped = false;

    private void Start()
    {
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        CheckPosition();
        if(permitToMove && canMove)
            MoveForward();
    }

    private void CheckPosition()
    {
        if (!stopped && transform.position.z > 95)
        {
            stopped = true;
            canMove = false;
            StartShooting();
        }

        if (transform.position.z > 103)
        {
            canMove = false;
            canvas.gameObject.SetActive(true);
        }
    }

    private void MoveForward()
    {
        transform.position += Vector3.forward * movespeed * Time.deltaTime;
    }
    private void StartShooting()
    {
        bossMovement.canMove = true;
        playerShooting.allowFire = true;
        bossShooting.allowFire = true;
        bossHealth.gameObject.SetActive(true);
    }

}
