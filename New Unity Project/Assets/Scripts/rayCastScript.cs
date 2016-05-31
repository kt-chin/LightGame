using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LineRenderer))]

public class rayCastScript : MonoBehaviour
{
    private Transform goTransform;
    private LineRenderer lineRenderer;

    private Ray ray;
    private RaycastHit hit;

    //reflection direction
    private Vector3 inDirection;

    //reflection count
    private int nReflections = 5;

    //line render points
    private int nPoints;


    void Awake()
    {
        goTransform = this.GetComponent<Transform>();
        lineRenderer = this.GetComponent<LineRenderer>();
    }

    void Update()
    {
        nReflections = Mathf.Clamp(nReflections, 1, nReflections);
        ray = new Ray(goTransform.position, goTransform.forward);

        Debug.DrawRay(goTransform.position, goTransform.forward * 100, Color.magenta);


        nPoints = nReflections;
        lineRenderer.SetVertexCount(nPoints);
        lineRenderer.SetPosition(0, goTransform.position);

        for (int i = 0; i <= nReflections; i++)
        {
            if (i == 0)
            {
                if (Physics.Raycast(ray.origin, ray.direction, out hit, 1000))
                {
                    if (hit.transform.tag == "Mirror")
                    {
                        //the reflection direction is the reflection of the current ray direction flipped at the hit normal
                        inDirection = Vector3.Reflect(ray.direction, hit.normal);
                        //cast the reflected ray, using the hit point as the origin and the reflected direction as the direction
                        ray = new Ray(hit.point, inDirection);

                        //Draw the normal - only can be seen at the Scene tab for debugging purposes
                        Debug.DrawRay(hit.point, hit.normal * 3, Color.blue);
                        //represent the ray using a line that can only be viewed at the scene tab
                        Debug.DrawRay(hit.point, inDirection * 100, Color.magenta);

                        //Print the name of the object the cast ray has hit, at the console
                       // Debug.Log("Object name: " + hit.transform.name);

                        //if the number of reflections is set to 1
                        if (nReflections == 1)
                        {
                            //add a new vertex to the line renderer
                            lineRenderer.SetVertexCount(++nPoints);
                        }

                        //set the position of the next vertex at the line renderer to be the same as the hit point
                        lineRenderer.SetPosition(i + 1, hit.point);
                    }
                }
            }
            else // the ray has reflected at least once
            {
                if (Physics.Raycast(ray.origin, ray.direction, out hit, 1000))
                {
                    if (hit.transform.tag == "Mirror")
                    {
                        inDirection = Vector3.Reflect(inDirection, hit.normal);

                        ray = new Ray(hit.point, inDirection);

                        Debug.DrawRay(hit.point, hit.normal * 3, Color.blue);
                        Debug.DrawRay(hit.point, inDirection * 100, Color.magenta);

                        lineRenderer.SetVertexCount(++nPoints);

                        lineRenderer.SetPosition(i + 1, hit.point);
                    }
                    if (hit.transform.tag == "Objective")
                    {
                        lineRenderer.SetVertexCount(++nPoints);

                        lineRenderer.SetPosition(i + 1, hit.point);
                    }
                }
            }
        }
    }
}