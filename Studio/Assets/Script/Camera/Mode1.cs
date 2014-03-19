using UnityEngine;
using System.Collections;

public class Mode1 : MonoBehaviour
{
    public Transform target;

    public float Distance = 5.0f;
    public float Height = 3.0f;

    void Update()
    {
        transform.position = target.position + new Vector3(0.0f, Height, Distance);
        transform.LookAt(target);
    }
}
