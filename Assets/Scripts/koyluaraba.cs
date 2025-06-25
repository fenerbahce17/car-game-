using UnityEngine;
using UnityEngine.InputSystem;

public class koyluaraba : MonoBehaviour
{
    [Header("Wheel Colliders")]
    public WheelCollider frontRight;
    public WheelCollider frontLeft;
    public WheelCollider backRight;
    public WheelCollider backLeft;

    [Header("Wheel Transforms")]
public Transform frontRightTransform;
public Transform frontLeftTransform;
public Transform backRightTransform;
public Transform backLeftTransform;


   

    [Header("Car Settings")]
    public float maxMotorTorque = 1500f;   // Power
    public float maxSteerAngle = 30f;      // How much the wheels can turn
    public float steerSmoothSpeed = 5f;    // How smoothly it turns

    private float currentSteerAngle;
    private float steerInput;
    private float motorInput;
    public AudioSource engineSound;
    public float minPitch = 0.8f;
    public float maxPitch = 2.0f;


    void Update()
    {
        // Read keyboard input using new Input System
        steerInput = 0f;
        motorInput = 0f;

        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            steerInput = -1f;
        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            steerInput = 1f;

        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
            motorInput = 1f;
        if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
            motorInput = -1f;
    }

    void FixedUpdate()
    {
        HandleMotor();
        HandleSteering();
        Brake();
        UpdateWheelPoses();
 


    }

    public void AudioSettings()
    {
        //float speedFactor = Mathf.Abs(motorInput);  // Or use velocity magnitude
        //engineSound.pitch = Mathf.Lerp(minPitch, maxPitch, speedFactor);
        //engineSound.volume = Mathf.Clamp01(motorInput / 50f) * 1.0f;
        

    }
    private void UpdateWheelPose(WheelCollider collider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        collider.GetWorldPose(out pos, out rot);
        wheelTransform.position = pos;
        wheelTransform.rotation = rot;
    }
    private void UpdateWheelPoses()
    {
            UpdateWheelPose(frontRight, frontRightTransform);
            UpdateWheelPose(frontLeft, frontLeftTransform);
            UpdateWheelPose(backRight, backRightTransform);
            UpdateWheelPose(backLeft, backLeftTransform);
        
    }
        private void Brake()
    {

        float brakeForce = 3000f; // Adjust as needed
        float handbrakeForce = 5000f;

        bool isBraking = motorInput == 0f; // Natural brake when no input
        bool isHandbrake = Keyboard.current.spaceKey.isPressed;

        float appliedBrakeForce = 0f;

        if (isHandbrake)
        {
            // Apply stronger brake to rear wheels
            backLeft.brakeTorque = handbrakeForce;
            backRight.brakeTorque = handbrakeForce;
            frontLeft.brakeTorque = 0f;
            frontRight.brakeTorque = 0f;
        }
        else if (isBraking)
        {
            appliedBrakeForce = brakeForce;

            backLeft.brakeTorque = appliedBrakeForce;
            backRight.brakeTorque = appliedBrakeForce;
            frontLeft.brakeTorque = appliedBrakeForce;
            frontRight.brakeTorque = appliedBrakeForce;
        }
        else
        {
            // Release brakes when accelerating
            backLeft.brakeTorque = 0f;
            backRight.brakeTorque = 0f;
            frontLeft.brakeTorque = 0f;
            frontRight.brakeTorque = 0f;
        }


    }

   private void HandleMotor()
    {
        float torque = motorInput * maxMotorTorque;
        Debug.Log($"Motor input: {motorInput}, Torque: {torque}");

        backLeft.motorTorque = torque;
        backRight.motorTorque = torque;
    }


    private void HandleSteering()
    {
        float targetAngle = steerInput * maxSteerAngle;
        currentSteerAngle = Mathf.Lerp(currentSteerAngle, targetAngle, steerSmoothSpeed * Time.deltaTime);

        frontLeft.steerAngle = currentSteerAngle;
        frontRight.steerAngle = currentSteerAngle;
    }

   

   
}
