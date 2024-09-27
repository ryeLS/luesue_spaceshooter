using UnityEngine;
using System.Collections;


public class Enemy : MonoBehaviour
{
    public float dodgeValue = 3f;
    public float waitTime = 5f;
    public Transform playerTransform;

    private void Start()
    {
        
    }
    private void Update()
    {
        EnemyDodge(dodgeValue);
    }
    public void EnemyDodge(float dodgeRange)
    {
        //float randomY = Random.Range(-dodgeRange, dodgeRange);
        //transform.position = new Vector3(transform.position.x, randomY);
        //float detectPlayer = transform.position.x + 2;
        //float playerDistance = playerTransform.position.x - transform.position.y;
        //if (playerDistance <= detectPlayer)
        //{
        //    randomY = Random.Range(-dodgeRange, dodgeRange);
        //    transform.position = new Vector3(transform.position.x, randomY);
        //    detectPlayer = transform.position.x + 1;
        //    playerDistance = playerTransform.position.x - transform.position.y;
        //}
    }

}
