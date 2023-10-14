using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingParent : MonoBehaviour
{
    [SerializeField]
    private GameObject joint;

    [SerializeField]
    private GameObject plane;

    private GetTime getTimeScript;

    [SerializeField]
    private Rigidbody target;
    [SerializeField]
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

        var targetPosX = target.transform.position.x - joint.transform.position.x + Mathf.Abs(time) * velocity.x;
        var targetPosZ = target.transform.position.z - joint.transform.position.z + Mathf.Abs(time) * velocity.z;

        float yaw = Mathf.Atan(targetPosX / targetPosZ) * 180 / Mathf.PI;
        this.gameObject.transform.localRotation = Quaternion.Euler(0, yaw, 0);
    }
}
