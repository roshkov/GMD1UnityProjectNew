using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnScript : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {


         if (animator.GetBool("DirectionToRight") ) {
            animator.SetBool("DirectionToRight", false);
        }
        else {
            animator.SetBool("DirectionToRight", true);
        }   


    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //keeping no angles - only 90 and -90
        if (animator.GetBool("DirectionToRight") ) {
         animator.gameObject.transform.rotation = Quaternion.Euler(0,90,0);
        }
        else {
           animator.gameObject.transform.rotation = Quaternion.Euler(0,270,0);
        }

    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}


    
}
