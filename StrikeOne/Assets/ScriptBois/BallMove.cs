using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    public float ballSpeed;
    public float speedInc;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }


    private void OnTriggerStay(Collider other)
    {
        if (Input.GetMouseButtonDown(0))
        {
            {
                //points to the mouse's position when the left mouse button is clicked
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Debug.Log(Input.mousePosition);
                
            }
        }

    }
}
