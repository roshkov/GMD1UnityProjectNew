using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterScript : MonoBehaviour, iMovingChar, iRunningChar
{
 
    Rigidbody rb;
    Animator anim;
    [SerializeField] private float jumpForce;
    [SerializeField] private float maxspeedWalking;
    [SerializeField] private float maxspeedRunning;
    CapsuleCollider cc;
    private float maxSpeedValue;
    private float accelerationValue;

    
    GameObject player;
    private float move;
    iRunningChar runchar;

    iMovingChar movechar;

    bool disableRunning;
    


    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody>();
         rb.inertiaTensorRotation = Quaternion.identity;

         player = transform.GetChild (0).gameObject;
         anim = player.GetComponent<Animator>();
        
         maxSpeedValue = maxspeedWalking;  
         move = 0;

         cc =  GetComponent<CapsuleCollider>() ;

         if (this is iRunningChar) {
         runchar = new RunningChar(); 
          }

         if (this is iMovingChar) {
         movechar = new MovingChar();
         }

        
        //Disable running for secondScene
         if (SceneManager.GetActiveScene().name == "Level2") {
             disableRunning = true;
         }
         else {
             disableRunning = false;
         }
    }

    // Update is called once per frame
    void Update()
    {  
         //What you can do when you not turning
         if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Turn") )
             {
                HorizontalMove (gameObject, ref anim, ref move, ref maxSpeedValue);
                HorizontalMoveRun(ref anim, ref maxSpeedValue, ref maxspeedRunning, ref maxspeedWalking);
                //start movement (walk or run)
                VerticalMoveJump (ref anim, ref rb, ref jumpForce); 
             }

         HorizontalMoveTurn180 (ref anim, ref player );
            
    }

            
        void FixedUpdate()
        {
            // this example will rotate the collider only on the y axis
            cc.transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        }


   
public void HorizontalMoveRun (ref Animator anim, ref float maxSpeedValue, ref float maxspeedRunning, ref float maxspeedWalking ) {
         if (runchar !=null && !disableRunning) {
         runchar.HorizontalMoveRun(ref anim, ref maxSpeedValue, ref maxspeedRunning, ref maxspeedWalking);
         }
}

// public void HorizontalMoveWalk (GameObject gameObject, ref Animator anim, ref float move, ref float maxSpeedValue) {
public void HorizontalMove (GameObject gameObject, ref Animator anim, ref float move, ref float maxSpeedValue) {
    
      if (movechar !=null) {
         movechar.HorizontalMove (gameObject, ref anim, ref move, ref maxSpeedValue);
         }
}


 public void VerticalMoveJump (ref Animator anim, ref Rigidbody rb, ref float jumpForce) {
        if (movechar !=null) {
         movechar.VerticalMoveJump (ref anim, ref rb, ref jumpForce);

         }
 }


 public void HorizontalMoveTurn180 (ref Animator anim, ref GameObject player ) {
        if (movechar !=null) {
         movechar.HorizontalMoveTurn180 (ref anim, ref player );
         }
 }

}
