using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCreator : MonoBehaviour {

    public GameObject linePrefab;
    public GameObject player;

    private GameObject currentLine;
    private Line lineScript;
	// Update is called once per frame
	void Update () {
		
        if(Input.GetKeyDown(KeyCode.Space))
        {
            player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }

        if(Input.GetMouseButtonDown(0))
        {
            currentLine = Instantiate(linePrefab);
            lineScript = currentLine.GetComponent<Line>();
        }

        if(Input.GetMouseButtonUp(0))
        {
            lineScript.StartUpdate();
            currentLine = null;
        }


        if(currentLine!=null)
        {
            lineScript.DrawLineOnMouseMove(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }

	}
}
