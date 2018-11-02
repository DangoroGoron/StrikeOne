using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        f(Input.GetMouseButton(0))
            RotateToMouse();
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    void RotateToMouse()
    {
        Vector3 v3T = Input.mousePosition;
        v3T.z = Mathf.Abs(Camera.main.transform.position.y - transform.position.y);
        v3T = Camera.main.ScreenToWorldPoint(v3T);
        v3T -= transform.position;
        v3T = v3T * 10000.0f + transform.position;
        transform.LookAt(v3T);
    }
}
