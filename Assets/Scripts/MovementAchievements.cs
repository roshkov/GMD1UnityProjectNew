using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MovementAchievements : MonoBehaviour
{
    public GameObject AchievementCanvasItem;
    
    [Range(1f, 30f)] public float ShowingTimeSeconds;

    int jumps = 0;
    void OnEnable() {
        EventManager.jumpEvent += JumpCount;
    }

     void OnDisable() {
        EventManager.jumpEvent -= JumpCount;
    }

    void JumpCount () {
        jumps++;
       if (jumps == 1) {
            passText("1JumpAchievement", AchievementCanvasItem);
        }
        if (jumps > 20) {
            passText("20JumpsAchiement", AchievementCanvasItem);
            OnDisable();
        }
    }

    public IEnumerator ShowAchievement(GameObject achievTobeDisplayed, float ShowingTimeSeconds) {
        achievTobeDisplayed.SetActive(true);
        yield return new WaitForSeconds(ShowingTimeSeconds);
        achievTobeDisplayed.SetActive(false);
    }

    private void passText(string achName, GameObject AchievementCanvasItem) {
        if ( AchievementCanvasItem != null) {
                GameObject achievTobeDisplayed = AchievementCanvasItem.transform.Find(achName).gameObject;
                    if (achievTobeDisplayed != null) {
                         StartCoroutine (ShowAchievement (achievTobeDisplayed, ShowingTimeSeconds));
                    }
        }
    }

}
