using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    [SerializeField] // SerializeField makes sure the speed is visible in the Unity editor
    private float speed;
    bool started = false;

    Rigidbody rb; // Used for any game object with a RigidBody attached to it

    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); // Gives access to any game object attached with a rigid body   
    }

    // Use this for initialization
    void Start ()
    {

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
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                SwitchDirection();
            }
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
