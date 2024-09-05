using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class AnimationAndMovementContraller : MonoBehaviour
{
    CharactorMovements playerInput;

    Vector2 currentMovemetInput;
    Vector3 currentMovement;
    Vector3 currentRunMovemet;
    bool isMovemetPressed;
    bool isRunPressed;

    float rotationFactorPerFrame = 5.0f;
    public float RunSpeed = 3.0f;


    

    CharacterController characterController;

    Animator animator;

    //Audio
    public AudioSource src;
    public AudioClip Walking, Running;

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new CharactorMovements();
        
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();


        playerInput.CharactorControll.Move.started += onMovementInput;

        playerInput.CharactorControll.Move.canceled += onMovementInput;
        playerInput.CharactorControll.Move.performed  += onMovementInput;
        playerInput.CharactorControll.Run.started += onRun;
        playerInput.CharactorControll.Run.canceled += onRun;


    }

    void handleRotaion()
    {
        Vector3 positionLookAt;

        positionLookAt.x=currentMovement.x;
        positionLookAt.y = 0.0f;
        positionLookAt.z = currentMovement.z;

        Quaternion currentRotaion = transform.rotation;

        if (isMovemetPressed)
        {
            Quaternion targetRotaion = Quaternion.LookRotation(positionLookAt);
            transform.rotation = Quaternion.Slerp(currentRotaion, targetRotaion, rotationFactorPerFrame*Time.deltaTime);
        }
    }

    void onMovementInput(InputAction.CallbackContext context)
    {
        currentMovemetInput = context.ReadValue<Vector2>();
        currentMovement.x = currentMovemetInput.x;
        currentMovement.z = currentMovemetInput.y;
        currentRunMovemet.x= currentMovemetInput.x*RunSpeed;
        currentRunMovemet.z = currentMovemetInput.y * RunSpeed;

        isMovemetPressed = currentMovemetInput.x != 0 || currentMovemetInput.y != 0;

        walkingAudio();

    }

    void onRun(InputAction.CallbackContext context) {
        isRunPressed = context.ReadValueAsButton();
        runingAudio();
    }

    void handleAnimation()
    {
        bool isWalking = animator.GetBool("isWalking");
        bool isRunning = animator.GetBool("isRunning");

        if (isMovemetPressed && !isWalking) {
            animator.SetBool("isWalking", true);
        }


        else if (!isMovemetPressed && isWalking)
        {
            animator.SetBool("isWalking", false);
        }

        if ((isMovemetPressed && isRunPressed) && !isRunning)
        {
            animator.SetBool("isRunning",true);
        }
        else if ((!isMovemetPressed || !isRunPressed) && isRunning)
        {
            animator.SetBool("isRunning", false);
        }

    }

    void handleGravity()
    {
        if (characterController.isGrounded)
        {
            float groundedGravity = -0.05f;
            currentMovement.y= groundedGravity;
            currentRunMovemet.y= groundedGravity;
        }
        else
        {
            float gravity = -9.8f;
            currentMovement.y= gravity;
            currentRunMovemet.y= gravity;
        }
    }

    // Update is called once per frame
    void Update()
    {
        handleRotaion();
        handleAnimation();
        handleGravity();
        if (isRunPressed)
        {
            characterController.Move(currentRunMovemet * Time.deltaTime);
        }
        else {
            characterController.Move(currentMovement * Time.deltaTime); }
    }

    void OnEnable()
    {
        playerInput.CharactorControll.Enable();
    }

    void onDisable()
    {
        playerInput.CharactorControll.Disable();
    }

    public void runingAudio()
    {
        src.clip = Running;
        src.Play();
    }
    public void walkingAudio()
    {
        src.clip = Walking;
        src.Play();
    }

    
}
