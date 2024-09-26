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
        randomPoint.x = Random.Range(-maxFloatDistance, maxFloatDistance);// works now
        randomPoint.y = Random.Range(-maxFloatDistance, maxFloatDistance);
    }

    // Update is called once per frame
    void Update()
    {
        asteroidmovement();
        if(Vector3.Distance(transform.position, randomPoint) <= arrivalDistance)
        {
            randomPoint.x = Random.Range(-maxFloatDistance, maxFloatDistance);
            randomPoint.y = Random.Range(-maxFloatDistance, maxFloatDistance);
            Debug.Log("changed destination");
            asteroidmovement();
        }
    }
    public void asteroidmovement()
    {
        Vector3 betweenVectors = randomPoint - transform.position;
        betweenVectors.z = 0;
        transform.position += betweenVectors * moveSpeed * Time.deltaTime;
    }
}
