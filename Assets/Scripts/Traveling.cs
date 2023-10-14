using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traveling : MonoBehaviour
{
    [SerializeField]    
    private float speed;
    private Rigidbody rb;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var movement = new Vector3(Input.GetAxis("Horizontal"), 0,Input.GetAxis("Vertical"));
        rb.velocity = movement * speed;
    }
}
