using UnityEngine;
using UnityEngine.InputSystem;

public class OpponentCarMove : MonoBehaviour
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



    public WaypointManager waypointManager;
    
    void Update()
    {
        // Read keyboard input using new Input System
        steerInput = 0f;
        motorInput = 0f;

        if (Keyboard.current.gKey.isPressed )
            steerInput = -1f;
        if (Keyboard.current.jKey.isPressed )
            steerInput = 1f;

        if (Keyboard.current.yKey.isPressed )
            motorInput = 1f;
        if (Keyboard.current.hKey.isPressed )
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
