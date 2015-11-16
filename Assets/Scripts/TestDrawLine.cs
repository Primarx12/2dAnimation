using UnityEngine;
using System.Collections;

public class TestDrawLine : MonoBehaviour {

    public GameObject cube1,
                      cube2;

	// Use this for initialization
	void Start () 
    {
        UnityEditor.Handles.DrawLine(cube1.transform.position, cube2.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
