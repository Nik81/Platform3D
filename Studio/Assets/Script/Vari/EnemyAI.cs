using UnityEngine;
using System.Collections;
using System;

public class EnemyAI : MonoBehaviour, IHitable 
{

    public Transform target;

    public Action hasDied;
    public float speed = 2.0f;

    public float health = 100;
    
    bool canMove = true;
    bool isDead = false;
	
	// Update is called once per frame
	void Update () 
    {
        if (canMove)
        {
            Vector3 relativePos = (target.position + new Vector3(4, 0.5f, 0)) - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos);

            Quaternion current = transform.localRotation;

            transform.localRotation = Quaternion.Slerp(current, rotation, speed * Time.deltaTime);
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
	}

    public void Hit()
    {
        health -= 10;

        if (health <= 0 && !isDead)
        {
            Destroy(gameObject, 2);

            canMove = false;

            if (hasDied != null)
                hasDied();

            isDead = true;
        }
    }
}
