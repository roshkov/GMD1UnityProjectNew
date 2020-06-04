using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

     [SerializeField] GameObject player;
     [SerializeField] private float spaceInFront;
     [SerializeField] private float cameraFollowSpeed;
     private bool dirToRight;
     private float spaceInFrontValue;
     private Animator anim;
      private Vector3 offset; 
       private Vector3 newPosition;
      float z;


    void Start()
    {
         offset = transform.position - player.transform.position;
         z = transform.position.z;

         anim = player.GetComponent<Animator>();
         dirToRight = anim.GetBool("DirectionToRight");
         spaceInFrontValue = spaceInFront;

    }


    void Update()
    {
       //If changes direction, change value of x, change
          if (anim.GetBool("DirectionToRight") != dirToRight) {
               spaceInFrontValue *= (-1);
               dirToRight  = anim.GetBool("DirectionToRight");
          }
       newPosition =   new Vector3 (player.transform.position.x + offset.x + spaceInFrontValue,     player.transform.position.y + offset.y,      z) ;

       
          if (!(newPosition == transform.position )) {
               transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * cameraFollowSpeed);
          }



    }
}
