using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    
    Animator anim;

    void Start()
    {
             anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      float move = Input.GetAxis("Horizontal");
      anim.SetFloat("Speed", move);  //put 'move' value to Speed (in animator)

      if(Input.GetKeyDown("space")) {
            anim.SetTrigger ("Jump");
      }  

    }
}
