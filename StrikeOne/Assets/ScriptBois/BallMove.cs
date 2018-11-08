using UnityEngine;

public class BallMove : MonoBehaviour
{
    public float ballSpeed;
    public float speedInc;
    private bool ballMove;
    private Rigidbody rb;

    // private Material mat;

    private void Awake()
    {
        // mat = GetComponent<Renderer>().material;
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        if (ballMove)
        {
            //mat.color = new Color(Random.value, Random.value, Random.value);
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
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Enemy"))
            return;

        Vector3 heading = other.transform.position - transform.position;
        Vector3 direction = heading / heading.magnitude;

        RaycastHit hit;
        Physics.Raycast(transform.position, direction, out hit);

        Vector3 normal = hit.normal;
        normal.y = transform.forward.y;
        transform.forward = normal;
        ballSpeed += speedInc;
    }
}
