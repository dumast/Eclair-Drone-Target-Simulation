using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traveling : MonoBehaviour
{
    [SerializeField]    
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("left")){
            this.gameObject.transform.position = transform.position + new Vector3(-speed, 0, 0);
        }
        if (Input.GetKey("right")){
            this.gameObject.transform.position = transform.position + new Vector3(speed, 0, 0);
        }
        if (Input.GetKey("up")){
            this.gameObject.transform.position = transform.position + new Vector3(0, 0, speed);
        }
        if (Input.GetKey("down")){
            this.gameObject.transform.position = transform.position + new Vector3(0, 0, -speed);
        }
    }
}
