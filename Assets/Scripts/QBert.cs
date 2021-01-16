using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QBert : MonoBehaviour
{
    public Vector3 position;
    public Vector3 velocity;
    public Vector3 acceleration;
    public float timeSpeed;

    public Material yellowMaterial;

    private float deltatime;
    private Vector3 velUpRight;
    private Vector3 velUpLeft;
    private Vector3 velDownRight;
    private Vector3 velDownLeft;
    private float angle;
    private float speed;
    private bool inAir;
    
    // Start is called before the first frame update
    void Start()
    {
        deltatime = 0.02f;

        angle = Mathf.Atan((4.9f*timeSpeed*timeSpeed) - 1.0f); // or + 1 if going up where 1 is the deltaY

        speed = 1/(Mathf.Cos(angle)*timeSpeed);

        //velUp = new Vector3(speed*Mathf.Cos(angle)*Mathf.Cos(Mathf.Deg2Rad * 45), speed*Mathf.Sin(angle), -speed*Mathf.Cos(Mathf.Deg2Rad * 45));
        velDownRight = new Vector3(1, 6.0f, -1);
        velDownLeft = new Vector3(-1, 6.0f, -1);

        velUpRight = new Vector3(1, 9.0f, 1);
        velUpLeft = new Vector3(-1, 9.0f, 1);

        float gravity = 9.8f * 2.5f;
        acceleration = new Vector3(0.0f, -gravity, 0.0f);
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!inAir)
        {

            if (Input.GetKey("s"))
            {
                JumpDown(true);
            }
            else if (Input.GetKey("a"))
            {
                JumpDown(false);
            }
            else if (Input.GetKey("q"))
            {
                JumpUp(false);
            }
            else if (Input.GetKey("w"))
            {
                JumpUp(true);
            }
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
        if(Right)
        {
            velocity = velDownRight;
            transform.rotation = Quaternion.Euler(0, 135, 0);
        }else // Left
        {
            transform.rotation = Quaternion.Euler(0, 225, 0);
            velocity = velDownLeft;
        }
    }
    void JumpUp(bool Right)
    {
        inAir = true;
        if (Right)
        {
            velocity = velUpRight;
            transform.rotation = Quaternion.Euler(0, 45, 0);
        }
        else // Left
        {
            velocity = velUpLeft;
            transform.rotation = Quaternion.Euler(0, -45, 0);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "Plane")
        {
            inAir = false;
            Vector3 offSet = new Vector3(0, 0.5f, 0);
            transform.position = collision.transform.position + offSet;
            collision.collider.GetComponent<Renderer>().material = yellowMaterial;
        }
    }
}
