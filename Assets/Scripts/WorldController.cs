using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    public Transform pivotPoint;
    public float rotationSpeed = 15f;
    public float slowRotationSpeed = 10f;
    public float maxZRotationAngle = 0.2f;
    public float minZRotationAngle = -0.2f;
    public float maxXRotationAngle = 0.2f;
    public float minXRotationAngle = -0.2f;


    private Quaternion originalRotation;

    public bool isEnable = false;
    public MovementFromAudio moveScript;

    private void Start()
    {
        moveScript = GameObject.Find("Player").GetComponent<MovementFromAudio>();
        originalRotation = transform.rotation;
    }

    void OnEnable()
    {
        PlayerStats.onPlayerDied += ResetToOriginalRotation;
    }

    void OnDisable()
    {
        PlayerStats.onPlayerDied -= ResetToOriginalRotation;
    }

    void FixedUpdate()
    {
        if (!isEnable)
        {
            return;
        }

        float currentZRotation = transform.rotation.z;
        float currentXRotation = transform.rotation.x;

        if (moveScript.forwards)
        {
            LeanForward();
        }
        if (moveScript.backwards)
        {
            LeanBack();
        }
        if (Input.GetKey(KeyCode.A))
        {
            LeanLeft();
        }
        if (Input.GetKey(KeyCode.D))
        {
            LeanRight();
        }
    }

    public void LeanForward()
    {
        float currentZRotation = transform.rotation.z;
        if (currentZRotation < maxZRotationAngle)
        {
            Vector3 rotationAxis = transform.forward;
            float rotationAngle = rotationSpeed * Time.deltaTime;
            transform.RotateAround(pivotPoint.position, rotationAxis, rotationAngle);
        }
    }

    public void LeanBack()
    {
        float currentZRotation = transform.rotation.z;
        if (currentZRotation > minZRotationAngle)
        {
            Vector3 rotationAxis = -transform.forward;
            float rotationAngle = rotationSpeed * Time.deltaTime;
            transform.RotateAround(pivotPoint.position, rotationAxis, rotationAngle);
        }
    }

    public void LeanLeft()
    {
        float currentXRotation = transform.rotation.x;
        if (currentXRotation > minXRotationAngle)
        {
            Vector3 rotationAxis = -transform.right;
            float rotationAngle = rotationSpeed * Time.deltaTime;
            transform.RotateAround(pivotPoint.position, rotationAxis, rotationAngle);
        }
    }

    public void LeanRight()
    {
        float currentXRotation = transform.rotation.x;
        if (currentXRotation < maxXRotationAngle)
        {
            Vector3 rotationAxis = transform.right;
            float rotationAngle = rotationSpeed * Time.deltaTime;
            transform.RotateAround(pivotPoint.position, rotationAxis, rotationAngle);
        }
    }
    public void ResetToOriginalRotation()
    {
        transform.rotation = originalRotation;
    }

    public void ReturnToOriginal()
    {
        float currentZRotation = transform.rotation.z;
        if (currentZRotation > 0.01)
        {
            Vector3 rotationAxis = -transform.forward;
            float rotationAngle = slowRotationSpeed * Time.deltaTime;
            transform.RotateAround(pivotPoint.position, rotationAxis, rotationAngle);
        }
        if (currentZRotation < -0.01)
        {
            Vector3 rotationAxis = transform.forward;
            float rotationAngle = slowRotationSpeed * Time.deltaTime;
            transform.RotateAround(pivotPoint.position, rotationAxis, rotationAngle);
        }
    }
    

}
