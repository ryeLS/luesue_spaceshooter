using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class angles : MonoBehaviour
{
    List<float> angle = new List<float>();
    public float radius = 1;
    Vector3 origin = Vector3.zero;
    public int counter = 0;
    // Start is called before the first frame update
    void Start()
    {//i forgot u can just . declare it like normal
        angle.Add(0);
        angle.Add(36);
        angle.Add(150);
        angle.Add(60);
        angle.Add(230);
        angle.Add(170);
        angle.Add(210);
        angle.Add(320);
        angle.Add(54);
        angle.Add(90);

        Debug.Log("Mathf.Cos(45): " + Mathf.Cos(45 * Mathf.Deg2Rad));
        Debug.Log("Mathf.Cos(-45): " + Mathf.Cos(-45 * Mathf.Deg2Rad));
        Debug.Log("Mathf.Acos(0.7071068): " + Mathf.Acos(0.7071068f) * Mathf.Rad2Deg);

    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Cos(Mathf.Deg2Rad * angle[counter]);
        float y = Mathf.Sin(Mathf.Deg2Rad * angle[counter]);
        Vector3 endingPosition = new Vector3(x, y) * radius;

        Debug.DrawLine(origin, endingPosition, Color.yellow);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            counter++;
        }

        

        
    }
}
