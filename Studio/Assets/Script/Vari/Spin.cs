using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {

    public float RotationSpeed = 0.1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.Rotate(0, RotationSpeed, 0);
	}
}
