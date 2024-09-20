using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    private Vector3 velocity = Vector3.right * 0.001f;
    void Update()
    {
        //transform.position += velocity;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            PlayerMovement();
        }
    }
    void PlayerMovement()
    {
        transform.position += -velocity;
    }

}
