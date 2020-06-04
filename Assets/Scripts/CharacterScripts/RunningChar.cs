using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningChar : MonoBehaviour, iRunningChar
{

    public void HorizontalMoveRun (ref Animator anim, ref float maxSpeedValue, ref float maxspeedRunning, ref float maxspeedWalking ) {
    //Running
                   if (Input.GetButton ("Run") ){
                        anim.SetBool("inRunningState", true);
                        maxSpeedValue = maxspeedRunning;
                   }
                   else {
                      anim.SetBool("inRunningState", false);
                       if (maxSpeedValue != maxspeedWalking) {
                           maxSpeedValue = maxspeedWalking;
                       }    
                   }
}

}
