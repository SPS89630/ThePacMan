using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionUp : MonoBehaviour
{
    public bool WallUp = false;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            WallUp = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            WallUp = false;
        }
    }
}
