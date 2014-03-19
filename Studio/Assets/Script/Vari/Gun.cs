using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

    public Rigidbody bulletPrefab;
    public Transform cannon;

    public float Energy = 3000;
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetButton("Fire1"))
        {
            Rigidbody bulletInstance;
            bulletInstance = Instantiate(bulletPrefab, cannon.position, cannon.rotation) as Rigidbody;
            bulletInstance.AddForce(cannon.up * Energy);
        }	
	}
}
