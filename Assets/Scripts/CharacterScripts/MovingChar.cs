using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingChar : MonoBehaviour, iMovingChar
{

public void HorizontalMove (GameObject gameObject, ref Animator anim, ref float move, ref float maxSpeedValue) {
           //Horizontal movements
                   move = Input.GetAxis("Horizontal");
                    if (anim.GetBool("isGrounded")) {
                        anim.SetFloat("Speed", move);       
                    }
                   gameObject.transform.Translate (move * Vector3.right * maxSpeedValue * Time.deltaTime, Space.World);  
}


 public void VerticalMoveJump (ref Animator anim, ref Rigidbody rb, ref float jumpForce) {

       if (Input.GetButtonDown ("Jump")  && anim.GetBool("isGrounded") ){
                    anim.SetTrigger("Jump"); 
                    rb.constraints = RigidbodyConstraints.FreezeRotationZ;
                    anim.SetBool("isGrounded", false);
                    rb.velocity += jumpForce * Vector3.up; 
         }
 }


 public void HorizontalMoveTurn180 (ref Animator anim, ref GameObject player ) {
                //Turn 180
                //if faced to right and is pressed 'moveLeft' btn or   if faced to left and clicked 'moveright' btn  
                    if ((anim.GetBool("DirectionToRight") == true  && Input.GetAxis("Horizontal") < 0   )  ||
                        (anim.GetBool("DirectionToRight") == false && Input.GetAxis("Horizontal") > 0   )  ) {
                             if (anim.GetBool("isGrounded")) {
                                anim.SetTrigger("Turn"); 
                             }
                             else {
                                       if (player.transform.rotation.y > 0 ) {   
                                           player.transform.eulerAngles = Vector3.up * -90;   
                                           anim.SetBool("DirectionToRight", false); 
                                       }
                                       else { 
                                           player.transform.eulerAngles = Vector3.up * 90; 
                                           anim.SetBool("DirectionToRight", true);
                                       }
                                  }
                            
                    } 
 }


}
