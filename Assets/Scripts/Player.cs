using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] float jumpHeight = 50;
    [SerializeField] float walkSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetAxis("Horizontal")) ;
        if (Input.GetKey(KeyCode.Space))
        {
            print("jump");
            rb.AddForce(Vector2.up * (jumpHeight * Time.deltaTime), ForceMode.Impulse);
        }

        if (Input.GetAxis("Horizontal") != 0f)
        {
            Vector2 dir = new Vector2(Input.GetAxis("Horizontal"), 0);
            rb.AddForce(dir * (walkSpeed * Time.deltaTime), ForceMode.Impulse);
        }
    }
}
