using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed = 1;
    public float arrivalDistance = 2;
    public float maxFloatDistance;
    Vector3 randomPoint = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        asteroidmovement(maxFloatDistance);
        if(Vector3.Distance(transform.position, randomPoint) >= arrivalDistance)
        {
            asteroidmovement(maxFloatDistance);
        }
    }
    public void asteroidmovement(float randomDistance)
    {
        randomPoint.x = Random.Range(1, randomDistance);
        randomPoint.y = Random.Range(1, randomDistance);

        Vector3 betweenVectors = randomPoint - transform.position;
        betweenVectors.z = 0;
        transform.position += betweenVectors * moveSpeed * Time.deltaTime;
    }
}
