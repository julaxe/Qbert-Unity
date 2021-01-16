using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    public float Tup;
    public float Tdown;
    public bool Inside;

    private bool Up;
    private double Timer;
    private Renderer renderer;
    void Start()
    {
        renderer = GetComponent<Renderer>();
        Up = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Inside)
        { 
            if(Timer >= 0.3)
            {
                Inside = false;
                Timer = 0;
            }
            else
            {
                Timer += Time.deltaTime;
                return;
            }
            
        }
       if(Up)
        {
            renderer.enabled = true;
            if(Timer >= Tup)
            {
                Up = false;
                Timer = 0;
            }
        }
        else
        {
            renderer.enabled = false;
            if(Timer >= Tdown)
            {
                Up = true;
                Timer = 0;
            }
        }
        Timer += Time.deltaTime;
    }
}
