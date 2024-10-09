using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    private GameObject g;

    private float startX;

    [SerializeField] private float speed;

    [SerializeField] float distanceTravelled = 10;
    // Start is called before the first frame update
    void Start()
    {
        g = GetComponent<GameObject>();

        startX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > startX - distanceTravelled)
        {
            transform.position -= new Vector3(-1 * Time.deltaTime * speed, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(startX, transform.position.y, transform.position.z);
        }
    }
}
