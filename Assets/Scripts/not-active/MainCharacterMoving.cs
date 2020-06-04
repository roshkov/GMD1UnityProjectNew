using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterMoving : MonoBehaviour
{
    // [SerializeField] private float gravityforcedown;
    private Rigidbody rb;
     [SerializeField]  float jumpForce;
     private Vector3 jump;
     private bool isGrounded;


    // Start is called before the first frame update
    void Start()
    {
          rb = GetComponent<Rigidbody>();
          jump = new Vector3(0.0f, 2.0f, 0.0f);
          isGrounded = true; 
    }


        void OnCollisionStay()
         {
             if(!isGrounded && rb.velocity.y == 0 ) {
                isGrounded = true;
             }

         }


    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis ("Horizontal");
        if (horizontal != 0f) {
            transform.Translate (horizontal * Vector3.forward * 5f * Time.deltaTime);
        } 
        //should be changed
    
        if (Input.GetKeyDown ("space") && isGrounded ) {
            isGrounded = false;
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
        }

    }
}
