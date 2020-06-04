using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSoundsFXScript : MonoBehaviour
{

    private AudioManager audioManager;
    GameObject waterobject;
    CapsuleCollider mainPlayerCollider;

    [HideInInspector] public bool isInWater;

    void Start()
    {
        isInWater = false;
        audioManager = FindObjectOfType<AudioManager>();
        waterobject = GameObject.FindWithTag("WaterObj");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Step() {
       if (isInWater) {
        audioManager.Play("StepWalkWater");  
       }
       else {
        audioManager.Play("StepWalk");
       } 
        
        
    }


   
   
}
