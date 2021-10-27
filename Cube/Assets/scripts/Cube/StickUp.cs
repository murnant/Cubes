using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickUp : MonoBehaviour
{
    private float height;
    void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.tag == "CubeUp")
    {
        if (collision.gameObject.transform.localScale.y == transform.localScale.y)
        {
            if (GetInstanceID() > collision.gameObject.GetInstanceID())
            {
                height += 1;
                collision.transform.position = transform.position + new Vector3(0.0f,transform.localScale.y*height,0.0f);
                //collision.gameObject.GetComponent<Rigidbody>().detectCollisions = false;
                print(height);
                collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                collision.gameObject.GetComponent<StickUp>().enabled = false;
                collision.gameObject.GetComponent<Rigidbody>().detectCollisions = false;
                collision.gameObject.transform.parent = transform;
            }
        }
    }
}

    // Start is called before the first frame update
    void Start()
    {
        height = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
