using UnityEngine;
using System.Collections;

public class EdgeController : MonoBehaviour {

    public Mesh cylinderMesh;
    public Material lineMat;

    public float radius = 0.05f;

    public Transform PointStart,
                     PointFinish;
    private GameObject ringGameObjects;

	// Use this for initialization
	void Start () {

            // Make a gameobject that we will put the ring on
            // And then put it as a child on the gameobject that has this Command and Control script
            this.ringGameObjects = new GameObject();
            this.ringGameObjects.name = "Connecting ring";
            this.ringGameObjects.transform.parent = this.gameObject.transform;

            // We make a offset gameobject to counteract the default cylindermesh pivot/origin being in the middle
            GameObject ringOffsetCylinderMeshObject = new GameObject();
            ringOffsetCylinderMeshObject.transform.parent = this.ringGameObjects.transform;

            // Offset the cylinder so that the pivot/origin is at the bottom in relation to the outer ring gameobject.
            ringOffsetCylinderMeshObject.transform.localPosition = new Vector3(0f, 1f, 0f);
            // Set the radius
            ringOffsetCylinderMeshObject.transform.localScale = new Vector3(radius, 1f, radius);

            // Create the the Mesh and renderer to show the connecting ring
            MeshFilter ringMesh = ringOffsetCylinderMeshObject.AddComponent<MeshFilter>();
            ringMesh.gameObject.AddComponent<BoxCollider>();
            ringMesh.mesh = this.cylinderMesh;

            MeshRenderer ringRenderer = ringOffsetCylinderMeshObject.AddComponent<MeshRenderer>();
            ringRenderer.material = lineMat;
	
	}
	
	// Update is called once per frame
	void Update () {

        // Move the ring to the point
        this.ringGameObjects.transform.position = this.PointFinish.transform.position;

        // Match the scale to the distance
        float cylinderDistance = 0.5f * Vector3.Distance(this.PointFinish.transform.position, this.PointStart.transform.position);
        this.ringGameObjects.transform.localScale = new Vector3(this.ringGameObjects.transform.localScale.x, cylinderDistance, this.ringGameObjects.transform.localScale.z);
        // Make the cylinder look at the main point.
        // Since the cylinder is pointing up(y) and the forward is z, we need to offset by 90 degrees.
        this.ringGameObjects.transform.LookAt(this.PointStart.transform, Vector3.up);
        this.ringGameObjects.transform.rotation *= Quaternion.Euler(90, 0, 0);
	
	}
}
