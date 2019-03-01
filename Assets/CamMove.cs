using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour {

    Vector3 prevPosition;
    Vector3 curPosition;
    Collider[] hitColliders;
    float radius = 0.05f;
    RaycastHit hit;
    Vector3 direction;
    Vector3 reflection;
    Vector3 nextPosition;


    public float mouseSensitivity = 3.0f;
    public float speed = 5.0f;
    private Vector3 transfer;

    public float minimumX = -360F;
    public float maximumX = 360F;
    public float minimumY = -60F;
    public float maximumY = 60F;
    float rotationX = 0F;
    float rotationY = 0F;
    Quaternion originalRotation;

    void Start()
    {
        originalRotation = transform.rotation;
        curPosition = prevPosition = Camera.main.transform.position;
    }

    void Update()
    {
        transfer = transform.forward * Input.GetAxis("Vertical");
        transfer += transform.right * Input.GetAxis("Horizontal");

        curPosition = transform.position;

        nextPosition = curPosition + transfer;

        if (Physics.Linecast(curPosition, nextPosition, out hit))
        {
            Debug.DrawLine(curPosition, nextPosition, Color.red, 10);
            Debug.Log("hit" + hit);

            reflection = Vector3.ProjectOnPlane(nextPosition - hit.point, hit.normal.normalized);


            if (!Physics.Linecast(curPosition, curPosition + reflection, out hit))
            {
                transform.position += reflection;
            }
        }
        else
        {
            transform.position += transfer * speed * Time.deltaTime / 10;
        }




        // Движения мыши -> Вращение камеры
        if (Input.GetMouseButton(1))
        {
            rotationX += Input.GetAxis("Mouse X") * mouseSensitivity;
            rotationY += Input.GetAxis("Mouse Y") * mouseSensitivity;
            rotationX = ClampAngle(rotationX, minimumX, maximumX);
            rotationY = ClampAngle(rotationY, minimumY, maximumY);
            Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
            Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, Vector3.left);
            transform.rotation = originalRotation * xQuaternion * yQuaternion;
        }


        prevPosition = curPosition;

    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(Camera.main.transform.position, radius);
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F) angle += 360F;
        if (angle > 360F) angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}
