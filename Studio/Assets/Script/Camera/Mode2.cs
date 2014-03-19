using UnityEngine;
using System.Collections;

public class Mode2 : MonoBehaviour {

    public Transform target;

    public float Distance = 3f;
    public float Height = 1.0f;

	// Update is called once per frame
	void Update ()
    {
        transform.position = target.position;
        transform.position -= target.rotation * Vector3.forward * Distance;
        transform.position += Vector3.up * Height;

        transform.LookAt(target);
	}
}
