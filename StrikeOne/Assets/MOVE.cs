using UnityEngine;
using System.Collections;

public class MOVE : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float dodgeSpeed = 2F;
    //public Rigidbody rb;
    public float dodge;
    private bool currentDodge;
    // Use this for initialization
    void Start()
    {
        //   GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (currentDodge)
            return;

        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector3.forward;
            //transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector3.back;
            //transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector3.left;
            //transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.right;
            //transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }

        transform.Translate(direction * moveSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Dodge(direction));
        }
    }

    private IEnumerator Dodge(Vector3 direction)
    {
        currentDodge = true;

        float dodgeAmount = dodge;

        while (dodgeAmount > 0)
        {
            transform.Translate(direction * dodgeSpeed * Time.deltaTime);
            dodgeAmount -= dodgeSpeed * Time.deltaTime;
            yield return 0;
        }

        currentDodge = false;
    }
}
