using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerWaterCollider : MonoBehaviour
{
    private bool isInWaterLocal = false;

    private void OnTriggerStay(Collider other)
    {
     if (other.gameObject.tag == "WaterObj")
        { 
            if (!isInWaterLocal) {
                isInWaterLocal = true;
                transform.GetChild(0).gameObject.GetComponent<MovingSoundsFXScript>().isInWater = true;
            }
            
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
             isInWaterLocal = false;
             transform.GetChild(0).gameObject.GetComponent<MovingSoundsFXScript>().isInWater = false;
    }
    
}
