using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointBehavior : MonoBehaviour
{

    PlayerBehavior Player;

    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<PlayerBehavior>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player.Score += 10;
            Destroy(gameObject);
        }
    }
}
