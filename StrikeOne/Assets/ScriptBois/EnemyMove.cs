using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    //Attack
    public float stopRange;
    private Transform target;
    public float moveSpeed = 1f;
    private Rigidbody rb;
    private bool move = true;
    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("PlayerTarget").transform;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        float distToTarg = Vector3.Distance(transform.position, target.position);
        if (move)
        {
            transform.LookAt(target);
            rb.velocity = transform.forward * moveSpeed;
        }
        if (distToTarg < stopRange)
        {
            move = false;
        }
        else
        {
            move = true;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Ball"))
            return;
        Destroy(gameObject);
    }
}
