using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintAppearanceScript : MonoBehaviour
{
  
    GameObject mainPlayer;
    public GameObject HintCanvasItem;
   
    [Range(2f, 30f)] public float ShowingTimeSeconds;
    // Start is called before the first frame update

    void Start()
    {
        mainPlayer = GameObject.FindWithTag ("Player");
        StartCoroutine (ReadTheHint(HintCanvasItem, ShowingTimeSeconds));
    }
    

    public IEnumerator ReadTheHint(GameObject HintCanvasItem, float ShowingTimeSeconds) {
        while (Vector3.Distance(mainPlayer.transform.position, transform.position) > 2f) {
            yield return null;
        } 

        HintCanvasItem.SetActive(true);

        yield return new WaitForSeconds(ShowingTimeSeconds);
        HintCanvasItem.SetActive(false);
    }

}
