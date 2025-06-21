using UnityEngine;
using UnityEngine.InputSystem;

public class Car_Move : MonoBehaviour
{
    [Header("Wheel Colliders")]
    public WheelCollider frontRight;
    public WheelCollider frontLeft;
    public WheelCollider backRight;
    public WheelCollider backLeft;

   

    [Header("Car Settings")]
    public float maxMotorTorque = 1500f;   // Power
    public float maxSteerAngle = 30f;      // How much the wheels can turn
    public float steerSmoothSpeed = 5f;    // How smoothly it turns

    private float currentSteerAngle;
    private float steerInput;
    private float motorInput;

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
