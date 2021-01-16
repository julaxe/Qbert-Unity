using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBallGenerator : MonoBehaviour
{
    public GameObject redBall;
    public GameObject greenBall;

    private double timer;
    private Vector3 left;
    private Vector3 right;

    void Start()
    {
        timer = 0;
        left = new Vector3(-0.7071f, 3.0f, 10.5355f);
        right = new Vector3(0.7071f, 3.0f, 10.5355f);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 5)
        {
            timer = 0;
            if (Random.Range(1, 6) == 1) // 1 out of 5 is a green ball
            {
                SpawnGreenBall();
            }
            else
            {
                SpawnRedBall();
            }

        }
        timer += Time.deltaTime;
    }

    void SpawnRedBall()
    {
        GameObject r = Instantiate(redBall) as GameObject;
        if (Random.Range(1, 3) == 1)  //1 or 2
        {
            r.transform.position = left;
        }
        else
        {
            r.transform.position = right;
        }
       
    }

    void SpawnGreenBall()
    {
        GameObject g = Instantiate(greenBall) as GameObject;
        if (Random.Range(1, 3) == 1)  //1 or 2
        {
            g.transform.position = left;
        }
        else
        {
            g.transform.position = right;
        }

    }
}
