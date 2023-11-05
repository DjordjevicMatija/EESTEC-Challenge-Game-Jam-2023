using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    [SerializeField] private float cooldown = 0.5f;

    public float bulletForce = 10f;
    public bool allowFire { get; set; }

    private Vector3 clickedScreenPosition;
    private Vector3 releasedScreenPosition;

    private void Start()
    {
        allowFire = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!allowFire)
            return;
        checkClick();

    }

    private void checkClick()
    {
        if (Input.GetMouseButtonDown(0))
            clickedScreenPosition = Input.mousePosition;
        else if (Input.GetMouseButtonUp(0))
        {
            releasedScreenPosition = Input.mousePosition;
            float absX = Math.Abs(releasedScreenPosition.x - clickedScreenPosition.x);
            float absY = Math.Abs(releasedScreenPosition.y - clickedScreenPosition.y);
            if (absX < 5 && absY < 5)
                StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        allowFire = false;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(this.transform.forward * bulletForce, ForceMode.Impulse);
        Destroy(bullet, 5f);
        yield return new WaitForSeconds(cooldown);
        allowFire = true;
    }
}
