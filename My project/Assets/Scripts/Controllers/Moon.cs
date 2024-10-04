using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Moon : MonoBehaviour
{
    public Transform planetTransform;
    public float orbitRadius;
    float orbitSpeed = 30;
    public float angle = 0;

    // Start is called before the first frame update
    void Start()
    {
        orbitRadius = Vector3.Distance(planetTransform.position, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        OrbitalMotion(orbitRadius, orbitSpeed, planetTransform);
    }
    public void OrbitalMotion(float radius, float speed, Transform target)
    {
        
        angle += speed * Time.deltaTime;

        float x = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;
        float y = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;

        transform.position = new Vector3(x + target.position.x, y + target.position.y);
        
    }
}
