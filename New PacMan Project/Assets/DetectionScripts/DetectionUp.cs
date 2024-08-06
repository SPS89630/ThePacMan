using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionUp : MonoBehaviour
{
    public bool WallUp = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Wall Up");
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
