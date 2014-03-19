using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

    public Transform target;

    [Range(1,2)] public int Mode = 1;

    public float Distance = 3f;
    public float Height = 1.0f;
	
	// Update is called once per frame
	void Update () 
    {
        switch (Mode)
        {
            case 1: Mode1(); break;
            case 2: Mode2(); break;
        }
	}

    void Mode1() 
    {
        transform.position = target.position + new Vector3(0.0f, Height, -Distance);
        transform.LookAt(target);
    }

    void Mode2() 
    {
        transform.position = target.position;
        transform.position -= target.rotation * Vector3.forward * Distance;
        transform.position += Vector3.up * Height;

        transform.LookAt(target);
    }
}
