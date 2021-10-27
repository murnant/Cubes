using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickRight : MonoBehaviour
{
    private float height;
    void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.tag == "CubeRight")
    {
        if (GetInstanceID() > collision.gameObject.GetInstanceID())
        {
            height += 1;
            collision.transform.position = transform.position + new Vector3(transform.localScale.x * height,0.0f,0.0f);
            print(height);
            //collision.gameObject.GetComponent<Rigidbody>().detectCollisions = false;
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            collision.gameObject.GetComponent<Rigidbody>().detectCollisions = false;
            collision.gameObject.GetComponent<StickRight>().enabled = false;
            collision.gameObject.transform.parent = transform;
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
