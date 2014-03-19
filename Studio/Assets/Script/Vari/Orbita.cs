using UnityEngine;
using System.Collections;

public class Orbita : MonoBehaviour {

    public Transform target;	

	[Range(0, 20)] public int speed = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	void Update () 
	{
		Vector3 relativePos = (target.position + new Vector3(4, 0.5f, 0)) - transform.position;
		Quaternion rotation = Quaternion.LookRotation(relativePos);
		
		Quaternion current = transform.localRotation;
		
		transform.localRotation = Quaternion.Slerp(current, rotation, speed * Time.deltaTime);
		transform.Translate(0, 0, speed * Time.deltaTime);
	}
}
