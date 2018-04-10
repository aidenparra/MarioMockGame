using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    public Transform cameraTarget;

    public float camneraSpeed;

    public float minX,
                 maxX,
                 minY,
                 maxY;

     void FixedUpdate()
    {
        var newPos = Vector2.Lerp(transform.position, cameraTarget.position, Time.deltaTime);

        var vect3 = new Vector3(newPos.x, newPos.y, -10f);

        var ClampX = Mathf.Clamp(vect3.x, minX, maxX);
        var ClampY = Mathf.Clamp(vect3.y, minY, maxY);

        transform.position = new Vector3(ClampX, ClampY, -10f);

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
