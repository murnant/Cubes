using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Green : MonoBehaviour
{
    private Rigidbody rb;
    private float height = 1.0f;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cube")
        {
            if (collision.gameObject.transform.localScale.y == transform.localScale.y)
            {
                if (GetInstanceID() > collision.gameObject.GetInstanceID())
                {
                    Destroy(collision.gameObject);
                    height += collision.gameObject.transform.localScale.y;
                    transform.localPosition += new Vector3(0.0f,collision.transform.localScale.y / 2,0.0f);
                    transform.localScale =  new Vector3(1.0f,height,1.0f);
                }
            }
            else
            {
                if (collision.gameObject.transform.localScale.y < transform.localScale.y)
                {
                    Destroy(collision.gameObject);
                    height += collision.gameObject.transform.localScale.y;
                    transform.localPosition += new Vector3(0.0f,collision.transform.localScale.y / 2,0.0f);
                    transform.localScale =  new Vector3(1.0f,height,1.0f);
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
