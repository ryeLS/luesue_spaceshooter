using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
using static UnityEngine.UI.Image;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;
    public GameObject powerupPrefab;

    public float maxspeed = 3f;
    public float accelerationtime = 2f;

    private Vector3 velocity = Vector3.zero;
    public float acceleration = 1f;
    //public float decelerationtime = 2f;
    //public float deceleration = 1f;

    public int numOfPoints = 6;
    float angle;
    float fixedAngle;
    public float radarRadius = 1;
    Color colour = Color.green;

    public int numOfPowerups = 4;
    public float powerUpRadius = 3;
    public float powerUpAngle;
    public float powerFixedAngle;

    private void Start()
    {
        angle = 360 / numOfPoints;
        powerUpAngle = 360 / numOfPowerups;

        fixedAngle = angle;
        powerFixedAngle = powerUpAngle;
        acceleration = maxspeed / accelerationtime;
        //deceleration = maxspeed / decelerationtime;
 
    }

    void Update()
    {
        PlayerMovement();
        EnemyRadar(radarRadius, numOfPoints);
        SpawnPowerups(powerUpRadius, numOfPowerups);
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

        //if(Input.GetKeyUp(KeyCode.UpArrow)|| Input.GetKeyUp(KeyCode.DownArrow) || 
        //   Input.GetKeyUp(KeyCode.RightArrow)|| Input.GetKeyUp(KeyCode.LeftArrow))
        //{
        //    if(velocity.magnitude > 0)
        //    {
        //        Debug.Log("get up");//testing
        //        velocity.x -= deceleration * Time.deltaTime;
        //        velocity.y -= deceleration * Time.deltaTime;
        //        //timer += Time.deltaTime
        //        //if (timer > decelerationtime)
        //        //{velocity.magnitude = 0} <-- my idea to stop the player
        //    }
        //}
        //velocity = velocity.normalized * speed;
        if (velocity.magnitude >= maxspeed)
        {
            Debug.Log("max speed reached");//testing
            velocity = velocity.normalized * maxspeed;
        }
        
        
        transform.position += velocity * Time.deltaTime;

    }
    public void EnemyRadar(float radius, int circlePoints)
    {
        List<Vector3> points = new List<Vector3>();

        for (int i = 0; i<circlePoints; i++)
        {
            float x = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;
            float y = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
        
            points.Add(new Vector3(x + transform.position.x, y + transform.position.y));
            angle += fixedAngle;

            x = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;
            y = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;

            points.Add(new Vector3(x + transform.position.x, y + transform.position.y));

            Debug.DrawLine(points[i], points[i+1], colour);
            angle += fixedAngle;
        }
        float distance = Vector3.Distance(enemyTransform.position, transform.position);
        if(distance <= radius)
        {
            colour = Color.red;
        }
    }
    public void SpawnPowerups(float radius, int numberOfPowerups)
    {
        List<Vector3> power = new List<Vector3>();

        for (int i = 0; i < numberOfPowerups; i++)
        {
            float x = Mathf.Cos(Mathf.Deg2Rad * powerUpAngle) * radius;
            float y = Mathf.Sin(Mathf.Deg2Rad * powerUpAngle) * radius;

            power.Add(new Vector3(x + transform.position.x, y + transform.position.y));

            Instantiate(powerupPrefab, power[i], Quaternion.identity);
            powerUpAngle += powerFixedAngle;
        }
    }

}
