using UnityEngine;
using System.Collections;

public class Input2 : MonoBehaviour {

    public float MoveSpeed = 3f;
    public float TurnSpeed = 3f;

	// Update is called once per frame
    void Update()
    {
        float speed = 0.0f;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.RotateRelativeToCamera(Vector3.forward, Camera.main);
            speed = MoveSpeed;
            rigidbody.drag = 0;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.RotateRelativeToCamera(Vector3.back, Camera.main);
            speed = MoveSpeed;
            rigidbody.drag = 0;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.RotateRelativeToCamera(Vector3.left, Camera.main);
            speed = MoveSpeed;
            rigidbody.drag = 0;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.RotateRelativeToCamera(Vector3.right, Camera.main);
            speed = MoveSpeed;
            rigidbody.drag = 0;
        }

        rigidbody.drag += 1f;

        rigidbody.velocity = rigidbody.rotation * new Vector3(0.0f, 0.0f, MoveSpeed);

        //rigidbody.AddForce(rigidbody.rotation * new Vector3(0.0f, 0.0f, speed));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            float jumpSpeed = 50f;
            //rigidbody.velocity += jumpSpeed * Vector3.up;

            rigidbody.AddForce(new Vector3(0, jumpSpeed, 0), ForceMode.Impulse);
        }
 
    }

    private void RotateRelativeToCamera(Vector3 direction, Camera cam)
    {
        // rotate given direction by the camera's rotation
        Vector3 camDir = cam.transform.rotation * direction;

        // add result to object's location to get relative direction
        Vector3 objectDir = transform.position + camDir;

        // create quaternion facing direction
        Quaternion targetRotation = Quaternion.LookRotation(objectDir - transform.position);

        // constrain rotation to the Y axis
        Quaternion constrained = Quaternion.Euler(0.0f, targetRotation.eulerAngles.y, 0.0f);

        // slerp rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, constrained, Time.deltaTime * this.TurnSpeed);
    }
}
