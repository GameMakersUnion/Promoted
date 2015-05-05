using UnityEngine;
using System.Collections;

public class BossWall : MonoBehaviour {

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Boss")
        {
            SoundManager.Play(SoundManager.Sounds.Promotion);
        }
    }
}
