using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{

    static Animator anim;
      private Rigidbody rb;

       private bool jumpy;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
         rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
      jumpy = Input.GetButtonDown("Jump");
    }

       private void FixedUpdate() {
        
        if (jumpy && !anim.GetCurrentAnimatorStateInfo(0).IsName("BaseLayer.Jump")) {
            anim.SetTrigger("Jump");
        }

    }
}
