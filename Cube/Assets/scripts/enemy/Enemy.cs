using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public string targetTag;
    private GameObject[] thingsToFind;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        thingsToFind = GameObject.FindGameObjectsWithTag (targetTag);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float minDistance = 100;
        foreach (GameObject item in thingsToFind)
        {
            if (Vector3.Distance(transform.position,item.transform.position) < minDistance)
            {
                target = item.transform;
                minDistance = Vector3.Distance(transform.position,item.transform.position);
            }
        }
        if(target)
        {
            transform.LookAt(target);
        }
        rb.velocity = Vector3.zero;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == targetTag)
        {
            collision.transform.position = transform.position;
            collision.gameObject.GetComponent<Rigidbody>().detectCollisions = false;
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            collision.gameObject.transform.parent = transform;
        }
    }
}
