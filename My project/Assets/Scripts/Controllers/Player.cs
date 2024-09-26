using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    public float maxspeed = 3f;
    public float accelerationtime = 2f;

    private Vector3 velocity = Vector3.zero;
    public float acceleration = 1f;
    public float decelerationtime = 2f;
    public float deceleration = 1f;

    private void Start()
    {

        acceleration = maxspeed / accelerationtime;
        deceleration = maxspeed / decelerationtime;
 
    }

    void Update()
    {
        PlayerMovement(); 
    }
    void PlayerMovement()
    {
       // velocity = Vector3.zero;
        if (Input.GetKey(KeyCode.LeftArrow)) {

            velocity += Vector3.left * acceleration * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            velocity += Vector3.right * acceleration * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            velocity += Vector3.up * acceleration * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            velocity += Vector3.down * acceleration * Time.deltaTime;
        }
        if(Input.GetKeyUp(KeyCode.UpArrow)|| Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.RightArrow)|| Input.GetKeyUp(KeyCode.LeftArrow))
        {
            if(velocity.magnitude > 0)
            {
                Debug.Log("get up");
                velocity -= Vector3.up * deceleration * Time.deltaTime;
            }
        }
        //velocity = velocity.normalized * speed;
        //fix this
        //find magnitude (its in the sliders) for the velocity and have an if statement for if magnitude>maxspeed
        if (velocity.magnitude >= maxspeed)
        {
            Debug.Log("max speed reached");//testing
            velocity = velocity.normalized * maxspeed;
        }
        
        
        transform.position += velocity * Time.deltaTime;

    }

}
