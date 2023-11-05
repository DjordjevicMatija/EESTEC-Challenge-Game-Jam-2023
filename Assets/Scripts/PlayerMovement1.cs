using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class PlayerMovement1 : MonoBehaviour
{

    public Rigidbody rb;

    private Vector3 clickedScreenPosition;
    private Vector3 releasedScreenPosition;

    [SerializeField]private List<GameObject> targets;

    public float speed = 1f;
    private bool left = false;
    private bool right = false;
    private bool center = true;
    public float jumpForce = 2f;


    // Update is called once per frame
    void Update()
    {
        GameObject target;
        ManageControl();

        if (right)
        {
            target = targets[2];
        }
        else if (center)
        {
            target = targets[1];
        }
        else
        {
            target = targets[0];
        }

        transform.position = Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime * speed);

    }

    private void ManageControl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickedScreenPosition = Input.mousePosition;
        }

        else if (Input.GetMouseButtonUp(0))
        {
            releasedScreenPosition = Input.mousePosition;
            float absoluteDifferenceX = Math.Abs(releasedScreenPosition.x - clickedScreenPosition.x);
            float absoluteDifferenceY = (releasedScreenPosition.y - clickedScreenPosition.y);

            if ((releasedScreenPosition.x - clickedScreenPosition.x) < 0 &&
                absoluteDifferenceX > absoluteDifferenceY)
            {
                if (center)
                {
                    left = true;
                    center = false;
                }
                else if (right)
                {
                    center = true;
                    right = false;
                }
            }
            else if ((releasedScreenPosition.x - clickedScreenPosition.x) > 0 &&
                absoluteDifferenceX > absoluteDifferenceY && !right)
            {
                if (center)
                {
                    right = true;
                    center = false;
                }
                else if (left)
                {
                    center = true;
                    left = false;
                }
            }
            else if (absoluteDifferenceX < absoluteDifferenceY && absoluteDifferenceY > 10)
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            }
        }
    }

}