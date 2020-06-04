using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeScript : MonoBehaviour
{

    // float curSpeed ;
    float maxSpeedValue;
    float accelerationValue;
    Rigidbody rb;
     Animator anim;
     CapsuleCollider cc;
    // private float currSpeed;
    [SerializeField] float maxspeedWalking;
    [SerializeField] float maxspeedRunning;

    GameObject player;
    GameObject torch;
    [SerializeField] float jumpForce;

    private float move;



//  float deltaAngle;
 private Vector3 startAngle;

    // Start is called before the first frame update
    void Start()
    {
        //  curSpeed = 0;
         rb = GetComponent<Rigidbody>();
         rb.inertiaTensorRotation = Quaternion.identity;

         cc =  GetComponent<CapsuleCollider>() ;

         player = transform.GetChild (0).gameObject;
         anim = player.GetComponent<Animator>();
         
         torch = transform.GetChild (1).gameObject;
        
         maxSpeedValue = maxspeedWalking;  
         move = 0;
    }

    // Update is called once per frame
    void Update()
    {

        
         //What you can do when you not turning
         if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Turn") )
             {
                 //Remove if there are no bugs
                //  rb.constraints = RigidbodyConstraints.FreezeRotationY;
                //  rb.constraints = RigidbodyConstraints.FreezeRotationX;
                 //

                HorizontalMoveWalk (ref anim, ref move);
                
                // HorizontalMoveRun(ref anim, ref maxSpeedValue, ref maxspeedRunning, ref maxspeedWalking);
                   


                //start movement (walk or run)
                transform.Translate (move * Vector3.right * maxSpeedValue * Time.deltaTime, Space.World);  
                 VerticalMoveJump (ref anim, ref rb, ref jumpForce);
                    
             }

         HorizontalMoveTurn180 (ref anim, ref player );
            
    }


void FixedUpdate()
{
    // this example will rotate the collider only on the y axis
    cc.transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
}



// void HorizontalMoveRun (ref Animator anim, ref float maxSpeedValue, ref float maxspeedRunning, ref float maxspeedWalking ) {
// //running
//                    if (Input.GetKey (KeyCode.LeftShift) ){
//                         anim.SetBool("inRunningState", true);
//                         maxSpeedValue = maxspeedRunning;
//                    }
//                    else {
//                       anim.SetBool("inRunningState", false);
//                        if (maxSpeedValue != maxspeedWalking) {
//                            maxSpeedValue = maxspeedWalking;
//                        }    
//                    }
//                 //    Debug.Log ("speed: " + maxSpeedValue + "        acc: " + accelerationValue);
// }

   
   

void HorizontalMoveWalk (ref Animator anim, ref float move) {
           //Horizontal movements
                   move = Input.GetAxis("Horizontal");
                   if (anim.GetBool("isGrounded")) {
                    anim.SetFloat("Speed", move);       
                   }
}


 void VerticalMoveJump (ref Animator anim, ref Rigidbody rb, ref float jumpForce) {

       if (Input.GetKeyDown (KeyCode.Space) && anim.GetBool("isGrounded") ){
                    anim.SetTrigger("Jump"); 
                    rb.constraints = RigidbodyConstraints.FreezeRotationZ;
                    anim.SetBool("isGrounded", false);
                    rb.velocity += jumpForce * Vector3.up; 
                    }
 }


 void HorizontalMoveTurn180 (ref Animator anim, ref GameObject player ) {
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
