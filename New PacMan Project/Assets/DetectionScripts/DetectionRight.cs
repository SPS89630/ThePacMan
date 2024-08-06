using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionRight : MonoBehaviour
{
    public bool WallRight;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Wall Right");
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
