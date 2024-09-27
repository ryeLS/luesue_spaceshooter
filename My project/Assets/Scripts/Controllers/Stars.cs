using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;

    // Update is called once per frame
    void Update()
    {
        DrawConstellation();
    }
    public void DrawConstellation()
    {
        //for (int x = 0; x <= starTransforms.Count; x++)
        //{
        //    Vector3 starDistance = starTransforms[x++].position - starTransforms[x].position;
        //    Vector3 EndPoint = Vector3.MoveTowards(starTransforms[x].position, starTransforms[x++].position,
        //    drawingTime * Time.deltaTime);
        //    Debug.DrawLine(starTransforms[x].position, EndPoint, Color.white );
        //    if (x == starTransforms.Count)
        //    {
        //        x = 0;
        //    }
        //}
    }
}
