using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    [SerializeField] public float beatTempo = 120f;
    [SerializeField] public bool moveRight = true;
    [SerializeField] public float x = 60.0f, y = 20.0f;
    [SerializeField] public Rigidbody2D rb;
    public bool hasStarted = false;
    public bool finished = true;
    Vector2 movement;
    

    // Start is called before the first frame update
    void Start()
    {
        movement = new Vector2(x, y);
        beatTempo = beatTempo / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasStarted)
        {
            if(Input.GetMouseButtonDown(1))
            {
                hasStarted = true;
            }
        }
        else
        {     
            if(moveRight)
            {
                rb.MovePosition(rb.position + movement * beatTempo * Time.fixedDeltaTime);
            }
            else
            {
                movement = new Vector2(-x, y);
                rb.MovePosition(rb.position + movement * beatTempo * Time.fixedDeltaTime);    
            }
        }
    }
}
