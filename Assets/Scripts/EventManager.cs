using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{

    public delegate void JumpDelegate();
    public static event JumpDelegate jumpEvent;


    void Update()
    {
       if (Input.GetButtonDown ("Jump") ) {
           jumpEvent();
       }
    }
}
