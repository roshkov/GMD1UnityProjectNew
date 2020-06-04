using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface iMovingChar
{
    void HorizontalMove (GameObject gameObject, ref Animator anim, ref float move, ref float maxSpeedValue) ;
    void VerticalMoveJump (ref Animator anim, ref Rigidbody rb, ref float jumpForce);
    void HorizontalMoveTurn180 (ref Animator anim, ref GameObject player );

  
}
