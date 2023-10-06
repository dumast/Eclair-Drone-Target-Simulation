using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTime : MonoBehaviour
{

    [SerializeField]
    private GameObject target;
    [SerializeField]
    private GameObject gun;

    [HideInInspector]
    public float time = 0;

    private float A ; // target Y position 
    private float B; // target Y velocity
    private float C; // drone Y position
    private float D; // target X position
    private float E; // target X velocity
    private float F; // drone X position
    private float G; // target Z position
    private float H; // target Z velocity
    private float K; // drone Z velocity

    [SerializeField]
    private float J; // Bullet Speed


    Vector3 pos, velocity;

// Start is called before the first frame update
void Start()
{
}

void Awake()
{
    pos = transform.position;
}

// Update is called once per frame
void Update()
{
    velocity = (target.transform.position - pos) / Time.deltaTime;
    pos = target.transform.position;

    A = target.transform.position.y; // target Y position 
    B = velocity.y; // target Y velocity
    C = gun.transform.position.y; // drone Y position
    D = target.transform.position.x; // target X position
    E = velocity.x; // target X velocity
    F = gun.transform.position.x; // drone X position
    G = target.transform.position.z; // target Z position
    H = velocity.z; // target Z velocity
    K = gun.transform.position.z; // drone Z position

    time =
    Mathf.Abs(((-1 / 2 * Mathf.Sqrt(
        Mathf.Pow((2 * A * B - 2 * B * C + 2 * D * E - 2 * E * F + 2 * G * H - 2 * H * K), 2)
            - 4 * (Mathf.Pow(B, 2) + Mathf.Pow(E, 2) + Mathf.Pow(H, 2) - Mathf.Pow(J, 2))
            * (Mathf.Pow(A, 2)
            - 2 * A * C + Mathf.Pow(C, 2) + Mathf.Pow(D, 2) - 2 * D * F + Mathf.Pow(F, 2) + Mathf.Pow(G, 2) - 2 * G * K + Mathf.Pow(K, 2))
            ) - A * B + B * C - D * E + E * F - G * H + H * K))
            / (Mathf.Pow(B, 2) + Mathf.Pow(E, 2) + Mathf.Pow(H, 2) - Mathf.Pow(J, 2)));

}
}
