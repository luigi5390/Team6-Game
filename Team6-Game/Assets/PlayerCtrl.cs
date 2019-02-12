using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour
{
    public float speed;
    public string name;
    public Rigidbody2D bulletPrefab;
    public Rigidbody2D chargedbulletPrefab;
    public float fireRate;
    public float chargeRate;
    public float laserRate;
    public float laserLength;

    private bool isCharging;
    private bool isLaser;
    private float laserTimer;
    private float nextFire;
    private float nextCharge;
    private Light playerLight;
    private Rigidbody2D rigidB;


    void Start()
    {
        rigidB = GetComponent<Rigidbody2D>();
        playerLight = GetComponent<Light>();
        nextCharge = 0;
        nextFire = fireRate;
        isCharging = false;
        isLaser = false;
        laserTimer = 0;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal_" + name);
        float moveVertical = Input.GetAxis("Vertical_" + name);
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rigidB.AddForce(movement * speed);
        if (playerLight.range > 5)
        {
            playerLight.range -= 0.01f;
        }
        if (movement != Vector2.zero)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, movement);
        }
        //machine gun spray
        nextFire += Time.deltaTime;
        if (laserTimer < laserLength && isLaser == true)
        {
            isCharging = false;
            laserTimer += Time.deltaTime;
            Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
        else if (Input.GetButton("Jump"))
        {
            isLaser = false;
            if (nextFire > fireRate && isCharging == false)
            {
                Vector3 spawn = transform.position + transform.up * 5;
                Instantiate(bulletPrefab, spawn, transform.rotation);
                nextFire = 0;
            }
            nextCharge += Time.deltaTime;
            isCharging = true;
        }
        else
        {
            isCharging = false;
            if (nextCharge > laserRate/*4 * chargeRate*/)
            {
                nextCharge = 0;
                laserTimer = 0;
                isLaser = true;
            }
            if (nextCharge > chargeRate)
            {
                Instantiate(chargedbulletPrefab, transform.position, transform.rotation);
                nextCharge = 0;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {

    }
}
