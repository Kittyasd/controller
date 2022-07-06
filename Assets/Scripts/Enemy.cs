using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;   

public class Enemy : MonoBehaviour
{
    public float speed;
    public float rotationSpeed = 1F;
    public float deadZone = 0.1F;
    private float rotateDirection = 0;
    public GameObject bullet;
    public Transform shotPoint;
    public Transform target;
    private float timeBtwShots;
    public float startTimeBtwShots;
    private int rand;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rand = UnityEngine.Random.Range(0, 2);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timeBtwShots <= 0 && (transform.position.x >= -4 || transform.position.y <= -1)){
            Instantiate(bullet, shotPoint.position, rb.transform.rotation);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
    void FixedUpdate()
    {
        if(rand == 0)
        {
            if(transform.position.x < -4 && (transform.rotation.z < -0.7 || transform.rotation.z > -0.6)) 
            {
                transform.Rotate(0, 0, rotationSpeed);
            }
            else if(transform.position.x < -4)
            {
                rb.transform.Translate(Vector3.up * speed * Time.fixedDeltaTime);
            }
            else{
                if(transform.InverseTransformPoint(target.position).x > deadZone/2) rotateDirection = -1F;
                    else if(transform.InverseTransformPoint(target.position).x < -deadZone/2) rotateDirection = 1F;
                    else
                    {
                        if(transform.InverseTransformPoint(target.position).y < 0) rotateDirection = 1F;
                        else rotateDirection = 0;
                    }     
                    transform.rotation *= Quaternion.Euler(0,0,rotationSpeed * rotateDirection);
            }
        }
        else
        {
            if(transform.position.y > -1)
            {
                rb.transform.Translate(Vector3.up * speed * Time.fixedDeltaTime);
            }
            else{
                if(transform.InverseTransformPoint(target.position).x > deadZone/2) rotateDirection = -1F;
                    else if(transform.InverseTransformPoint(target.position).x < -deadZone/2) rotateDirection = 1F;
                    else
                    {
                        if(transform.InverseTransformPoint(target.position).y < 0) rotateDirection = 1F;
                        else rotateDirection = 0;
                    }     
                    transform.rotation *= Quaternion.Euler(0,0,rotationSpeed * rotateDirection);
            }
        }
    }
}