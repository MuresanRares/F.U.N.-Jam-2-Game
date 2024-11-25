using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider backRight;
    [SerializeField] WheelCollider backLeft;

    [SerializeField] Transform frontRightTransform;
    [SerializeField] Transform frontLeftTransform;
    [SerializeField] Transform backRightTransform;
    [SerializeField] Transform backLeftTransform;

    public float Acceleration = 500f;
    public float BreakForce = 300f;
    public float TurnAngle = 30f;

    private float _cAcceleration = 0f;
    private float _cBreakForce = 0f;
    private float _currentTurnAngle = 0f;

    public CarStatus carStatus;

    void Start()
    {
        if (carStatus == null)
        {
            carStatus = FindObjectOfType<CarStatus>();
            if (carStatus == null)
            {
                Debug.LogError("CarStatus script is not assigned and could not be found in the scene!");
            }
        }
    }

    private void FixedUpdate()
    {
        if (carStatus.inCar)
        {
            _cAcceleration = Acceleration * Input.GetAxis("Vertical");

            _currentTurnAngle = TurnAngle * Input.GetAxis("Horizontal");

            if (Input.GetKey(KeyCode.Space))
                _cBreakForce = BreakForce;
            else
                _cBreakForce = 0f;

            UpdateAccelerate(frontRight, _cAcceleration);
            UpdateAccelerate(frontLeft, _cAcceleration);

            UpdateBreaking(frontRight, _cBreakForce);
            UpdateBreaking(frontLeft, _cBreakForce);
            UpdateBreaking(backRight, _cBreakForce);
            UpdateBreaking(backLeft, _cBreakForce);

            UpdateTurnAngle(frontRight, _currentTurnAngle);
            UpdateTurnAngle(frontLeft, _currentTurnAngle);

            UpdateWheel(frontRight, frontRightTransform);
            UpdateWheel(frontLeft, frontLeftTransform);
            UpdateWheel(backRight, backRightTransform);
            UpdateWheel(backLeft, backLeftTransform);
        }
    }

    void UpdateAccelerate(WheelCollider col, float aForce)
    {
        col.motorTorque = aForce;
    }

    void UpdateBreaking(WheelCollider col, float bForce)
    {
        col.brakeTorque = bForce;
    }

    void UpdateTurnAngle(WheelCollider col, float cTurnAngle)
    {
        col.steerAngle = cTurnAngle;
    }

    void UpdateWheel(WheelCollider Col, Transform Trans)
    {
        Vector3 position;
        Quaternion rotation;
        Col.GetWorldPose(out position, out rotation);

        Trans.position = position;
        Trans.rotation = rotation * Quaternion.Euler(0, 90, 0);
    }
}
