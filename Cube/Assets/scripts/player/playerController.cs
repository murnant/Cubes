using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class playerController : MonoBehaviour
{
    public float Speed = 0;
    public TextMeshProUGUI countText;
    public GameObject WinText;
    private int count;
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private int NumberOfPickUps;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        //SetCountText();
        //WinText.SetActive(false);
        //GameObject[] thingyToFind = GameObject.FindGameObjectsWithTag ("PickUp");
        //NumberOfPickUps = thingyToFind.Length;

    }



    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }


    void SetCountText()
    {
        //countText.text = "Count; " + count.ToString() + "/" + NumberOfPickUps.ToString();
        if (count >= NumberOfPickUps)
        {
            WinText.SetActive(true);
        }
    }


    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX,0.0f,movementY);
        rb.AddForce(movement * Speed);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count +1;
            SetCountText();
        }
    }
}
