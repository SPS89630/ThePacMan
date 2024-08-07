using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBehavior : MonoBehaviour
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
            Debug.Log("Collected!");
            Player.PowerMode = true;
            Player.Score += 50;
            Destroy(gameObject);
        }
    }
}
