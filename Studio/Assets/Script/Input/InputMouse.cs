using UnityEngine;
using System.Collections;

public class InputMouse : MonoBehaviour {

    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        float v = verticalSpeed * Input.GetAxis("Mouse Y");
        transform.Rotate(0, h, 0);

        Vector3 movement = new Vector3(0, 0, v);
        rigidbody.AddForce(movement);
	}
}
