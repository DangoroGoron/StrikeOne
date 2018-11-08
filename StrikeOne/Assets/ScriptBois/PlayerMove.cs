using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float dodgeSpeed = 2F;
    private Rigidbody rb;
    public float dodge;
    private bool currentDodge;
    // Use this for initialization
    void Start()
    {
       rb=GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (currentDodge)
            return;
        bool bat = false;
        float angle = 0f;
        bool move = false;
        
        if (Input.GetKey(KeyCode.W))
        {
            move = true;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            move = true;
            angle += 180f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (move && Mathf.Approximately(angle, 0))
                angle -= 45f;
            else if (move)
                angle += 45f;
            else
                angle -= 90f;
            move = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (move && Mathf.Approximately(angle, 0))
                angle += 45f;
            else if (move)
                angle -= 45f;
            else
                angle += 90f;
            move = true;
        }

        if (move)
        {
            transform.eulerAngles = new Vector3(0, angle, 0);
            rb.velocity = transform.forward * (Input.GetKey(KeyCode.Space) ? dodgeSpeed : moveSpeed);
        }
// If statement to enable colider but I need to figure out how to disable it.

    }

    /*private IEnumerator Dodge(Vector3 direction)
    {
        currentDodge = true;

        float dodgeAmount = dodge;

        while (dodgeAmount > 0)
        {
            rb.velocity = direction * dodgeSpeed;
            dodgeAmount -= dodgeSpeed * Time.deltaTime;
            yield return 0;
        }

        currentDodge = false;
    }
    */
}
