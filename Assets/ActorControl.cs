using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorControl : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isRunningHash;

    // Start is called before the first frame update
    void Start()
    {
        animator =GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");

    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool("isRunning");

        bool wPressed = Input.GetKey("w");
        bool runPressed=Input.GetKey("left shift");

        if (!isWalking && wPressed)
        {
            animator.SetBool(isWalkingHash, true);
        }

        if (isWalking && !wPressed)
        {
            animator.SetBool(isWalkingHash, false);
        }

        if (!isRunning &&( wPressed && runPressed)) {
            animator.SetBool("isRunning", true);
        }
        
        if (isRunning && (!wPressed || !runPressed))
        {
            
            animator.SetBool("isRunning", false);
        }
    }
}
