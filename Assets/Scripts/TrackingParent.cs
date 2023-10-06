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
    private GameObject target;
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

        velocity = (target.transform.position - pos) / Time.deltaTime;
        pos = target.transform.position;

        var targetPosX = (target.transform.position.x - joint.transform.position.x) + time * velocity.x;
        var targetPosZ = (target.transform.position.z - joint.transform.position.z) + time * velocity.z;
        var targetPosY = (target.transform.position.y - joint.transform.position.y) - joint.transform.position.y;

        float yaw = Mathf.Atan(targetPosX / targetPosZ) * 180 / Mathf.PI;
        // float pitch = Mathf.Sign(targetPos.x) * Mathf.Sign(targetPos.y + Mathf.Abs(this.gameObject.transform.position.y) ) * Mathf.Abs(Mathf.Atan((targetPos.y + Mathf.Abs(this.gameObject.transform.position.y)) / Mathf.Sqrt(Mathf.Pow(targetPos.x, 2) + Mathf.Pow(targetPos.z, 2))) * 180 / Mathf.PI);
        this.gameObject.transform.localRotation = Quaternion.Euler(0, yaw, 0);
    }
}
