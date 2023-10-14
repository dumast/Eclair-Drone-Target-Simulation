using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingChild : MonoBehaviour
{

    [SerializeField]
    private GameObject plane;

    private GetTime getTimeScript;

    [SerializeField]
    private Rigidbody target;

    private float i = 1f;

    Vector3 pos, velocity;
    float time = 0f;

    // Start is called before the first frame update
    void Start()
    {
        getTimeScript = plane.GetComponent<GetTime>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if(!float.IsNaN(getTimeScript.time)){
            time = getTimeScript.time;
        }

        velocity = target.velocity;


        var distance = Mathf.Sqrt(Mathf.Pow(target.transform.position.x - this.gameObject.transform.position.x, 2) + Mathf.Pow(target.transform.position.z - this.gameObject.transform.position.z, 2) + Mathf.Pow(target.transform.position.y - this.gameObject.transform.position.y, 2));
        var gravTime = distance / getTimeScript.J;

        var targetPosX = target.transform.position.x - this.gameObject.transform.position.x + time * velocity.x;
        var targetPosZ = target.transform.position.z - this.gameObject.transform.position.z + time * velocity.z;
        var targetPosY = target.transform.position.y - this.gameObject.transform.position.y + time * velocity.y + 1/2f * 9.81f * Mathf.Pow(gravTime + Mathf.Max(time, 0), 2) ;
        // var targetPosY = target.transform.position.y - this.gameObject.transform.position.y + time * velocity.y;

        float pitch = -Mathf.Sign(targetPosZ) * Mathf.Sign(targetPosY) * Mathf.Abs(Mathf.Atan(targetPosY / Mathf.Sqrt(Mathf.Pow(targetPosZ, 2) + Mathf.Pow(targetPosX, 2))) * 180f / Mathf.PI);
        this.gameObject.transform.localRotation = Quaternion.Euler(pitch, 0, 0);
    }
}
