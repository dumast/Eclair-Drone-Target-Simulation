using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneTraveling : MonoBehaviour
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
        if (Input.GetKey("a")){
            this.gameObject.transform.position = transform.position + new Vector3(-speed, 0, 0);
        }
        if (Input.GetKey("d")){
            this.gameObject.transform.position = transform.position + new Vector3(speed, 0, 0);
        }
        if (Input.GetKey("w")){
            this.gameObject.transform.position = transform.position + new Vector3(0, 0, speed);
        }
        if (Input.GetKey("s")){
            this.gameObject.transform.position = transform.position + new Vector3(0, 0, -speed);
        }
        if (Input.GetKey("e")){
            this.gameObject.transform.position = transform.position + new Vector3(0, speed, 0);
        }
        if (Input.GetKey("q")){
            this.gameObject.transform.position = transform.position + new Vector3(0, -speed, 0);
        }
    }
}
