using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		Destroy (gameObject, 1.5f);
	}
	
	// Update is called once per frame
	void Update () 
    {
        var hits = Physics.OverlapSphere(transform.position, 0.2f);

        foreach (var hit in hits)
        {
            var hitables = hit.GetComponents(typeof(IHitable));

            if (hitables == null)
                return;

            foreach (IHitable hitable in hitables)
            {
                hitable.Hit();
            }
        }
	}
}
