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
    //public float fireRate;
    public float chargeRate;
    public bool isCharging;

    //private float nextFire;
    private float nextCharge;
    private Light playerLight;
    private Rigidbody2D rigidB;


    void Start()
    {
        rigidB = GetComponent<Rigidbody2D>();
        playerLight = GetComponent<Light>();
        nextCharge = 0;
        //nextFire = fireRate;
        isCharging = false;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal_" + name);
        float moveVertical = Input.GetAxis("Vertical_" + name);
        Vector2 movement = new Vector2(moveHorizontal * speed, moveVertical * speed);
        rigidB.AddForce(movement);
        if (playerLight.range > 5)
        {
            playerLight.range -= 0.01f;
        }

        if (movement != Vector2.zero)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, movement);
        }
        //nextFire += Time.deltaTime;
        if (Input.GetButton("Jump"))
        {
            if (/*nextFire > fireRate &&*/ !isCharging)
            {
                //Rigidbody2D bullet = Instantiate(bulletPrefab, transform.position, transform.rotation) as Rigidbody2D;
                Instantiate(bulletPrefab, transform.position, transform.rotation);
                //bullet.AddForce(transform.up * speed);

                //bullet.AddForce(Vector2.up * speed);
                //transform.position += transform.forward * Time.deltaTime * movementSpeed;
                //bullet.rb2d.AddForce(new Vector3(0, 2000, 0));

                //nextFire = 0;
            }
            nextCharge += Time.deltaTime;
            isCharging = true;
        }
        else
        {
            isCharging = false;
            if (nextCharge > chargeRate)
            {
                Instantiate(chargedbulletPrefab, transform.position, transform.rotation);
                nextCharge = 0;
            }
        }
        

        void OnTriggerEnter2D(Collider2D other)
        {

        }
    }
}