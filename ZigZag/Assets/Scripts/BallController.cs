using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    [SerializeField] // SerializeField makes sure the speed is visible in the Unity editor
    private float speed;
    bool started;
    bool gameOver;

    Rigidbody rb; // Used for any game object with a RigidBody attached to it

    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); // Gives access to any game object attached with a rigid body   
    }

    // Use this for initialization
    void Start ()
    {
        started = false;
        gameOver = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!started)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(speed, 0, 0);
                started = true;
            }
        }

        if (!Physics.Raycast(transform.position, Vector3.down, 1f)) // Casts a ray downwards and returns true if it collides with other game objects. 
        {
            gameOver = true;
            rb.velocity = new Vector3(0, -25f, 0); // Normal Coordinate vector applies. + means upwards while - means downwards
        }

        if (Input.GetMouseButtonDown(0) && !gameOver)
        {
            SwitchDirection();
        }
        
		
	}

    /*
     * Used to change the direction of the ball when it is tapped. 
     */

    void SwitchDirection ()
    {
        if (rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
        else
        {
            rb.velocity = new Vector3(0, 0, speed);
        }

    }
}
