using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Redball : MonoBehaviour
{
    private float deltatime;
    private Vector3 velDownRight;
    private Vector3 velDownLeft;
    private bool inAir;
    private double timer;

    public Vector3 position;
    public Vector3 velocity;
    public Vector3 acceleration;

    // Start is called before the first frame update
    void Start()
    {
        deltatime = 0.02f;
        timer = 0;
        velDownRight = new Vector3(1, 5.5f, -1);
        velDownLeft = new Vector3(-1, 5.5f, -1);
        inAir = true;

        float gravity = 9.8f * 2;
        acceleration = new Vector3(0.0f, -gravity, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!inAir)
        {
            if (timer > 0.5f) //just wait x seconds
            {
                if (Random.Range(1, 3) == 1)  //1 or 2
                {
                    JumpDown(true);
                }
                else
                {
                    JumpDown(false);
                }
                timer = 0;
            }
            timer += Time.deltaTime;
        }
    }
    void FixedUpdate()
    {
        if (inAir)
        {
            position = transform.position;
            velocity += acceleration * deltatime;
            position += (velocity * deltatime);
            transform.position = position;
        }
    }
    void JumpDown(bool Right)
    {
        inAir = true;
        if (Right)
        {
            velocity = velDownRight;
            transform.rotation = Quaternion.Euler(0, 135, 0);
        }
        else // Left
        {
            transform.rotation = Quaternion.Euler(0, 225, 0);
            velocity = velDownLeft;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Plane")
        {
            inAir = false;
            Vector3 offSet = new Vector3(0, 0.7f, 0);
            transform.position = collision.transform.position + offSet;
        }
    }
}
