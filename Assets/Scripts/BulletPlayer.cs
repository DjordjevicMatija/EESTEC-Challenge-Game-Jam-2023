using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : MonoBehaviour
{
    //public GameObject hitEffect;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Boss")
        {
            //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            //Destroy(effect, 0.4f);
            Destroy(gameObject);
        }
    }
}
