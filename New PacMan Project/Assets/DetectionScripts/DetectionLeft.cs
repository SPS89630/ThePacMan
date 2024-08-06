using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionLeft : MonoBehaviour
{
    public bool WallLeft;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Wall Left");
            WallLeft = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            WallLeft = false;
        }
    }
}
