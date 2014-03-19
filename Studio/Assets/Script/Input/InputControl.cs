using UnityEngine;
using System.Collections;

public class InputControl : MonoBehaviour
{
    [Range(1,2)] public int Mode = 1;

    public float MoveSpeed = 3f;
    public float TurnSpeed = 3f;

    // Update is called once per frame
    void Update()
    {
        switch (Mode)
        {
            case 1: Mode1(); break;
            case 2: Mode2(); break;
        }
    }

    void Mode2()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
        else
            if (Input.GetKey(KeyCode.DownArrow))
                transform.Translate(-Vector3.forward * MoveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(Vector3.up, -TurnSpeed * Time.deltaTime);
        else
            if (Input.GetKey(KeyCode.RightArrow))
                transform.Rotate(Vector3.up, TurnSpeed * Time.deltaTime);
    }

    void Mode1()
    {
        float speed = 0.0f;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.RotateRelativeToCamera(Vector3.forward, Camera.main);
            speed = MoveSpeed;
            rigidbody.drag = 0;
        }
        else
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
        else
            if (Input.GetKey(KeyCode.RightArrow))
            {
                this.RotateRelativeToCamera(Vector3.right, Camera.main);
                speed = MoveSpeed;
                rigidbody.drag = 0;
            }

        rigidbody.drag += 1f;

        rigidbody.velocity = rigidbody.rotation * new Vector3(0.0f, 0.0f, MoveSpeed);
    }

    private void RotateRelativeToCamera(Vector3 direction, Camera cam)
    {
        Vector3 camDir = cam.transform.rotation * direction;

        Vector3 objectDir = transform.position + camDir;

        Quaternion targetRotation = Quaternion.LookRotation(objectDir - transform.position);

        Quaternion constrained = Quaternion.Euler(0.0f, targetRotation.eulerAngles.y, 0.0f);

        transform.rotation = Quaternion.Slerp(transform.rotation, constrained, Time.deltaTime * this.TurnSpeed);
    }

}


