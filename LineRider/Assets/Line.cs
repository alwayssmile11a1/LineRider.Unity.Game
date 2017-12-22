using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour {

    private List<Vector2> positionList;
    private EdgeCollider2D edgeCollider2D;
    private LineRenderer lineRenderer;
    private bool startUpdate;

    private void Awake() 
    {
        edgeCollider2D = GetComponent<EdgeCollider2D>();
        lineRenderer = GetComponent<LineRenderer>();
        positionList = new List<Vector2>();
        startUpdate = false;
    }

    //private void Update()
    //{
    //    if (startUpdate)
    //    {
    //        for (int i = 0; i < edgeCollider2D.pointCount; i++)
    //        {

    //            lineRenderer.SetPosition(i, edgeCollider2D.points[i]);
    //        }
          
    //    }
    //}

    public void StartUpdate()
    {
        startUpdate = true;
        lineRenderer.useWorldSpace = false;

    }

    public void DrawLineOnMouseMove(Vector2 mousePosition)
    {
        if (positionList == null) return;
        if (positionList.Count == 0) // push to list right away if there is nothing in the list
        {
            positionList.Add(mousePosition);

            //set new position to line renderer
            lineRenderer.positionCount = positionList.Count;
            lineRenderer.SetPosition(positionList.Count - 1, mousePosition);
           
        }
        else
        {
            //check the distance between the previous mouse postion and current mouse position to see if we should put a new position to the list
            if(Vector2.Distance(mousePosition, positionList[positionList.Count-1]) > 0.1) 
            {
                positionList.Add(mousePosition);

                //set new position to line renderer and edge collider
                lineRenderer.positionCount = positionList.Count;
                lineRenderer.SetPosition(positionList.Count - 1, mousePosition);

                if (positionList.Count > 1) //set position to edge collider if there are more than 1 position
                {
                    edgeCollider2D.points = positionList.ToArray();
              
                }
            }
        }
    }

 


}
