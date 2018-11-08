using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    public float ballSpeed;
    public float speedInc;
    private bool ballMove;
    private Rigidbody rb;

    private Material mat;

    private void Awake()
    {
        mat = GetComponent<Renderer>().material;
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update () {
        if (ballMove)
        {
            mat.color = new Color(Random.value, Random.value, Random.value);
            rb.velocity = transform.forward * ballSpeed;
        }
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }


    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("PlayerTarget"))
            return;
        if (Input.GetMouseButtonDown(0))
        {
            {
                //points to the mouse's position when the left mouse button is clicked
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                Physics.Raycast(ray, out hit);
                Debug.Log(hit.point);
                Vector3 point = hit.point;
                point.y = transform.position.y;
                transform.LookAt(point);
                ballMove = true;
                ballSpeed += speedInc;
            }
        }

    }
}
