using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public Vector3 torque;
    private Rigidbody rb;
    private float nextTime;
    private MonoBehaviour enemyScript;
    // Start is called before the first frame update
    void Start()
    {
        enemyScript = GetComponent<Enemy>();
        rb = GetComponent<Rigidbody>();
        nextTime = Time.time + 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextTime)
        {
            enemyScript.enabled = !enemyScript.enabled;
            nextTime = Time.time + 2;
        }
        if (!enemyScript.enabled)
        {
            rb.AddRelativeTorque(torque);
        }
    }
}
