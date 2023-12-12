using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Users;
using UnityEngine.Windows;

public class AimScript : MonoBehaviour
{
    //[SerializeField] private float controllerDeadZone = 0.1f;
    //[SerializeField] private float gamepadRotateSmoothing = 1000f;

    [SerializeField] private bool isGamepad;
    [SerializeField] private float cursorSpeed = 1000f;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private RectTransform cursorTransform;
    [SerializeField] private RectTransform canvaTransform;
    [SerializeField] private Canvas canvas;

    private NewControls controlsScript;
    private Mouse virtualMouse;

    private void Awake()
    {
        controlsScript = new NewControls();
        playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        controlsScript.Enable();

        if(virtualMouse == null)
        {
            virtualMouse = (Mouse)InputSystem.AddDevice("VirtualMouse");
        }
        else if(virtualMouse.added)
        {
            InputSystem.AddDevice(virtualMouse);
        }

        InputUser.PerformPairingWithDevice(virtualMouse, playerInput.user);

        if(cursorTransform != null)
        {
            Vector2 position = cursorTransform.anchoredPosition;
            InputState.Change(virtualMouse.position, position);
        }

        InputSystem.onAfterUpdate += UpdateAimInput;
    }

    private void OnDisable()
    {
        controlsScript.Disable();
        InputSystem.RemoveDevice(virtualMouse);
        InputSystem.onAfterUpdate -= UpdateAimInput;
    }


    // Update is called once per frame
    //void Update()
    //{
    //    UpdateAimInput();
    //}
    public void OnDeviceChange(PlayerInput pi)
    {
        isGamepad = pi.currentControlScheme.Equals("Gamepad") ? true : false;
    }

    private void UpdateAimInput()
    {
        //Vector2 aim = controlsScript.Controls.Aim.ReadValue<Vector2>();

        Vector2 deltaValue = Gamepad.current.rightStick.ReadValue();
        deltaValue *= cursorSpeed * Time.deltaTime;

        Vector2 currentPos = virtualMouse.position.ReadValue();
        Vector2 newPos = currentPos + deltaValue;

        newPos.x = Mathf.Clamp(newPos.x, 0, Screen.width);
        newPos.y = Mathf.Clamp(newPos.y, 0, Screen.height);

        InputState.Change(virtualMouse.position, newPos);
        InputState.Change(virtualMouse.delta, deltaValue);

        AnchorCursor(newPos);

        if (isGamepad)
        {


            //aim = aim.normalized;
        }
        else 
        { 
            //aim = (aim - new Vector2(Screen.width / 2, Screen.height / 2)).normalized;
        }

    }

    private void AnchorCursor(Vector2 lastposition)
    {
        Vector2 anchoredPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvaTransform, lastposition, canvas.renderMode 
            == RenderMode.ScreenSpaceOverlay ? null : Camera.main, out anchoredPosition);

        cursorTransform.anchoredPosition = anchoredPosition;
    }
}
