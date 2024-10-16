using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed = 1;
    public float arrivalDistance = 2;
    public float maxFloatDistance;
    Vector3 randomPoint = Vector3.zero;

    public GameObject spawnedChunks;
    public Transform player;
    public int numOfChunks = 4;
    float angle;
    float fixedAngle;
    public float radius = 1;
    // Start is called before the first frame update
    void Start()
    {
        angle = 360 / numOfChunks;
        fixedAngle = angle;

        randomPoint.x = Random.Range(-maxFloatDistance, maxFloatDistance);// works now
        randomPoint.y = Random.Range(-maxFloatDistance, maxFloatDistance);
    }

    // Update is called once per frame
    void Update()
    {
        asteroidChunks();
        asteroidmovement();
        //if(Vector3.Distance(transform.position, randomPoint) <= arrivalDistance)
        //{
        //    randomPoint.x = Random.Range(-maxFloatDistance, maxFloatDistance);
        //    randomPoint.y = Random.Range(-maxFloatDistance, maxFloatDistance);
        //    Debug.Log("changed destination");
        //    asteroidmovement();
        //}
    }
    public void asteroidmovement()
    {
        //Vector3 betweenVectors = randomPoint - transform.position;
        //betweenVectors.z = 0;
        //transform.position += betweenVectors * moveSpeed * Time.deltaTime;
    }
    public void asteroidChunks()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= radius)
        {
            
            List<Vector3> chunks = new List<Vector3>();
            for (int i = 0; i < numOfChunks; i++)
            {
                float x = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;
                float y = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;

                chunks.Add(new Vector3(x + transform.position.x, y + transform.position.y));
                spawnedChunks.transform.localScale = transform.localScale / 2;
                Instantiate(spawnedChunks, chunks[i], Quaternion.identity);
                
                angle += fixedAngle;
            }
        }
    }

}
