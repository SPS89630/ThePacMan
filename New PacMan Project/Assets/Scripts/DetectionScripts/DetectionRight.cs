using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionRight : MonoBehaviour
{
    public bool WallRight;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            WallRight = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            WallRight = false;
        }
    }
}
