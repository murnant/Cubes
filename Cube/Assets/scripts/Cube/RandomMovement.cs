using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 random = Random.insideUnitCircle.normalized;
        Vector3 direction = new Vector3(random.x,0.0f,random.y);
        GetComponent<Rigidbody>().AddRelativeForce(direction * speed);
    }
}
