using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class AimScript : MonoBehaviour
{
    [SerializeField] private float controllerDeadZone = 0.1f;
    [SerializeField] private float gamepadRotateSmoothing = 1000f;

    [SerializeField] private bool isGamepad;

    private Vector2 aim;
    private NewControls controls;
    private PlayerInput playerInput;

    private void Awake()
    {
        controls = new NewControls();
        playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }


    // Update is called once per frame
    void Update()
    {
        UpdateAimInput();
    }

    private void UpdateAimInput()
    {

        aim = controls.Controls.Aim.ReadValue<Vector2>();
        Vector2 target = Camera.main.ScreenToWorldPoint(new Vector3(aim.x, aim.y, -Camera.main.transform.position.z));

        //m_aimInput = (target - (Vector2)transform.position).normalized;
    }

    public void OnDeviceChange(PlayerInput pi)
    {
        isGamepad = pi.currentControlScheme.Equals("Gamepad") ? true : false;
    }
}
