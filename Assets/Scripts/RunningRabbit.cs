using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningRabbit : MonoBehaviour
{
    GameObject mainPlayer;
    GameObject targetRabbit; //parent object
    Animation animation;
    private bool animDone;
    float reachDistance;
    [SerializeField] float distanceFromPlayer;
    // Start is called before the first frame update
    void Start()
    {
        mainPlayer = GameObject.FindWithTag ("Player");
        targetRabbit = transform.parent.gameObject;
        animation = gameObject.GetComponent<Animation>();
        animDone = false;
         animation["Run1"].speed = 3f;
    }
    

    // Update is called once per frame
    void Update()
    {

         reachDistance =Vector3.Distance(mainPlayer.transform.position, targetRabbit.transform.position);
        
         if (reachDistance < distanceFromPlayer && !animDone){
              
            // targetRabbit.transform.position = Vector3.Lerp(targetRabbit.transform.position, new Vector3(targetRabbit.transform.position.x + 0.1f, targetRabbit.transform.position.y, targetRabbit.transform.position.z + 0.1f), Time.deltaTime * 3f);
          
            

        
              animation.Play("Run1");
                //   animation.Play("Run");
           
            //  targetRabbit.transform.position = new Vector3( targetRabbit.transform.position.x+1f, targetRabbit.transform.position.y, targetRabbit.transform.position.z + 1f);
            // targetRabbit.transform.position = Vector3.Lerp(targetRabbit.transform.position, new Vector3(targetRabbit.transform.position.x, targetRabbit.transform.position.y, -50f), Time.deltaTime * 0.1f);
    
        } 


     }

        void LateUpdate() {
         
         if (reachDistance < distanceFromPlayer && !animDone){
              targetRabbit.transform.position = Vector3.Lerp(
              targetRabbit.transform.position, new Vector3(targetRabbit.transform.position.x+1.5f, targetRabbit.transform.position.y, targetRabbit.transform.position.z+2.3f), Time.deltaTime * 1f);
         }
        }

}
