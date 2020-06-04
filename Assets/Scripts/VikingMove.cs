using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VikingMove : MonoBehaviour
{

     CharacterController characterController;

    Animator anim;
    
   [SerializeField] float jumpheight;
   [SerializeField] float maxspeed;
   [SerializeField] float acceleration;

 private Vector3 moveDirection = Vector3.zero;

    private float curSpeed;
    void Start()
    {
          anim = GetComponent<Animator>();
          curSpeed = 0;
            characterController = GetComponent<CharacterController>();
            transform.position = new Vector3(transform.position.x,0,transform.position.z);
     
    }

    // Update is called once per frame
    void Update()
    {
        

  

        //Turn 180

                //if faced to right and is pressed 'moveLeft' btn or   if faced to left and clicked 'moveright' btn  
                if ((anim.GetBool("DirectionToRight") == true  && Input.GetAxis("Horizontal") < 0   )  ||
                    (anim.GetBool("DirectionToRight") == false && Input.GetAxis("Horizontal") > 0   )  )
                     {
                        anim.SetTrigger("Turn"); 
                        
                }  

                //DELETE LATER IF NO BUGS OCCUR
                // if faced to left and clicked 'moveright' btn  
                // if (anim.GetBool("DirectionToRight") == false && Input.GetAxis("Horizontal") > 0   )  
                // {
                //     anim.SetTrigger("Turn"); 
                // }




         // HORIZONTAL MOVEMENTS
         //if is not turning
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Turn"))
             {
           
                    float move = Input.GetAxis("Horizontal");
                    anim.SetFloat("Speed", move);
                    transform.Translate (move * Vector3.right * curSpeed * Time.deltaTime, Space.World);  
                    if (curSpeed < maxspeed) { curSpeed += acceleration; }

             }
         

//  if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Turn"))
//              {
//             moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f , 0.0f );
//              moveDirection *= maxspeed;
//               anim.SetFloat("Speed", moveDirection.x);
//         //  Debug.Log("wtf: " + moveDirection);

           

          
//              if (Input.GetButton("Jump"))
//             {
//                   Debug.Log("JUMPPPP: ");
//                 moveDirection.y = 8.0f;
//             }                    
            
//              Debug.Log( transform.position.y);

//         if (transform.position.y >0) {
//          moveDirection.y -= 100.0f * Time.deltaTime;
//         }
//         // Move the controller
        
//         characterController.Move(moveDirection * Time.deltaTime);
//              }

        // Jump
        //     if(Input.GetKeyDown("space")) {
        //     anim.SetTrigger ("Jump");
        //      transform.position += transform.up * 20f * Time.deltaTime;
        // }
        // Jump
            if(Input.GetKeyDown("space")) {
            anim.SetTrigger ("Jump");
             
            //  if (transform.position.y < jumpheight) {
                // transform.position += transform.up * 20f * Time.deltaTime;
            //  }
        }

    }



    /// LateUpdate is called every frame, if the Behaviour is enabled.
    /// It is called after all Update functions have been called.
    void LateUpdate()
    {
        
    }
}
