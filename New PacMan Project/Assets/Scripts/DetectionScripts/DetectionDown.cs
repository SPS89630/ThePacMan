using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionDown : MonoBehaviour
{
    public bool WallDown;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            WallDown = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            WallDown = false;
        }
    }
}
