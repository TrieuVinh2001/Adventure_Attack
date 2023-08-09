//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class GatherInput : MonoBehaviour
//{//của Player
//    private Control myControl;

//    public float valueX;
//    public bool jumpInput;

//    public bool tryAttack;

//    public float valueY;
//    public bool tryToClimb;

//    private void Awake()
//    {
//        myControl = new Control();
//    }

//    private void OnEnable()
//    {
//        myControl.Player.Move.performed += StartMove;
//        myControl.Player.Move.canceled += StopMove;

//        myControl.Player.Jump.performed += JumpStart;
//        myControl.Player.Jump.canceled += JumpStop;

//        myControl.Player.Attack.performed += TryToAttack;
//        myControl.Player.Attack.canceled += StopTryAttack;

//        myControl.Player.Climb.performed += ClimbStart;
//        myControl.Player.Climb.canceled += ClimbStop;

//        myControl.Player.Enable();
//    }

//    private void OnDisable()
//    {
//        myControl.Player.Move.performed -= StartMove;
//        myControl.Player.Move.canceled -= StopMove;

//        myControl.Player.Jump.performed -= JumpStart;
//        myControl.Player.Jump.canceled -= JumpStop;

//        myControl.Player.Attack.performed -= TryToAttack;
//        myControl.Player.Attack.canceled -= StopTryAttack;

//        myControl.Player.Climb.performed -= ClimbStart;
//        myControl.Player.Climb.canceled -= ClimbStop;

//        myControl.Player.Disable();
//    }

//    public void DisablControls()
//    {
//        myControl.Player.Move.performed -= StartMove;
//        myControl.Player.Move.canceled -= StopMove;

//        myControl.Player.Jump.performed -= JumpStart;
//        myControl.Player.Jump.canceled -= JumpStop;

//        myControl.Player.Attack.performed -= TryToAttack;
//        myControl.Player.Attack.canceled -= StopTryAttack;

//        myControl.Player.Climb.performed -= ClimbStart;
//        myControl.Player.Climb.canceled -= ClimbStop;

//        myControl.Player.Disable();
//        valueX = 0;
//    }

//    private void StartMove(InputAction.CallbackContext ctx)
//    {
//        valueX = ctx.ReadValue<float>();
//    }
    
//    private void StopMove(InputAction.CallbackContext ctx)
//    {
//        valueX = 0;
//    }
//    private void JumpStart(InputAction.CallbackContext ctx)
//    {
//        jumpInput = true;
//    }
//    private void JumpStop(InputAction.CallbackContext ctx)
//    {
//        jumpInput = false;
//    }

//    private void TryToAttack(InputAction.CallbackContext ctx)
//    {
//        tryAttack = true;
//    }

//    private void StopTryAttack(InputAction.CallbackContext ctx)
//    {
//        tryAttack = false;
//    }

//    private void ClimbStart(InputAction.CallbackContext ctx)
//    {
//        valueY = Mathf.RoundToInt(ctx.ReadValue<float>());

//        if (Mathf.Abs(valueY) > 0)
//        {
//            tryToClimb = true;
//        }
//    }

//    private void ClimbStop(InputAction.CallbackContext ctx)
//    {
//        tryToClimb = false;
//        valueY = 0;
//    }
//}
