using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;
    public PlayerShooting playerShooting;
    public Shooting bossShooting;
    public BossMovement bossMovement;
    public GameObject bossHealth;


    [Header("Settings")]
    [SerializeField] private float movespeed = 5f;

    private Vector3 clickedScreenPosition;
    private Vector3 releasedScreenPosition;


    public float speed = 1f;
    private bool left = false;
    private bool right = false;
    private bool center = true;
    public float jumpForce = 2f;
    private bool stopped = false;
    public bool canMove { get; set; }
    private bool permitToMove = true;

    private void Start()
    {
        canMove = true;
    }


    // Update is called once per frame
    void Update()
    {
        CheckPosition();
        StartCoroutine(ManageControl());
        if(permitToMove && canMove)
            MoveForward();
    }

    private void CheckPosition()
    {
        if (!stopped && transform.position.z > 69)
        {
            stopped = true;
            canMove = false;
            StartShooting();
        }

        if(transform.position.z > 74)
        {
            canMove = false;
        }

        if (transform.position.x < 0.02 && transform.position.x > -0.02 && !center)
        {
            rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
            center = true;
            left = false;
            right = false;
        }
        if (transform.position.x < 0.52 && transform.position.x > 0.48 && !right)
        {
            rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
            center = false;
            left = false;
            right = true;
        }
        if (transform.position.x > -0.52 && transform.position.x < -0.48 && !left)
        {
            rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
            center = false;
            left = true;
            right = false;
        }
    }

    private void StartShooting()
    {
        bossMovement.canMove = true;
        playerShooting.allowFire = true;
        bossShooting.allowFire = true;
        bossHealth.gameObject.SetActive(true);
    }

    private void MoveForward()
    {
        transform.position += Vector3.forward * movespeed * Time.deltaTime;
    }

    private IEnumerator ManageControl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickedScreenPosition = Input.mousePosition;
        }

        else if (Input.GetMouseButtonUp(0))
        {
            permitToMove = false;
            releasedScreenPosition = Input.mousePosition;
            float absoluteDifferenceX = Math.Abs(releasedScreenPosition.x - clickedScreenPosition.x);
            float absoluteDifferenceY = (releasedScreenPosition.y - clickedScreenPosition.y);

            if ((releasedScreenPosition.x - clickedScreenPosition.x) < 0 && 
                absoluteDifferenceX > absoluteDifferenceY && !left)
            {
                rb.velocity = new Vector3(-speed, rb.velocity.y, rb.velocity.z);
            }
            else if ((releasedScreenPosition.x - clickedScreenPosition.x) > 0 &&
                absoluteDifferenceX > absoluteDifferenceY && !right)
            {
                rb.velocity = new Vector3(speed, rb.velocity.y, rb.velocity.z);
            }
            else if (absoluteDifferenceX < absoluteDifferenceY && absoluteDifferenceY > 10)
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            }

            yield return null;
            permitToMove = true;
        }
    }

}