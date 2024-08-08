using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    PlayerBehavior Player;
    SpriteRenderer m_SpriteRenderer;
    public bool doOnce = true;

    public int CurrentPos;

    public Transform StartPos0;
    public Transform StartPos1;
    public Transform StartPos2;
    public Transform StartPos3;

    public Transform Pos1;
    public Transform Pos2;
    public Transform Pos3;
    public Transform Pos4;

    void Start()
    {
        StartPos0.gameObject.SetActive(false);
        CurrentPos = 11;
        Player = GameObject.Find("Player").GetComponent<PlayerBehavior>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Player.EnemyRed == true)
        {
            StartCoroutine(MoveEnemy());
        }
        else if (Player.EnemyRed == false)
        {
            StartCoroutine(EnemyDeath());
        }
        if (Player.PowerMode == true)
        {
            m_SpriteRenderer.color = Color.blue;
        }
        else 
        {
            m_SpriteRenderer.color = Color.red;
        }


        if (doOnce == true)
        {
            if (transform.position == StartPos1.position)
            {
                CurrentPos = 12;
            }
            if (transform.position == StartPos2.position)
            {
                CurrentPos = 13;
            }
            if (transform.position == StartPos3.position)
            {
                CurrentPos = 4;
            }
        }
        

        if (transform.position == Pos1.position)
        {
            CurrentPos = 1;
        }
        if (transform.position == Pos2.position)
        {
            CurrentPos = 2;
        }
        if (transform.position == Pos3.position)
        {
            CurrentPos = 3;
        }
        if (transform.position == Pos4.position)
        {
            CurrentPos = 4;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && Player.PowerMode == false)
        {
            Debug.Log("Player hit!");
            Player.Lives--;
        }
        else if (other.gameObject.CompareTag("Player") && Player.PowerMode == true)
        {
            Player.EnemyRed = false;
        }
    }


    private IEnumerator MoveEnemy()
    {
       if (doOnce == true)
        {
            if (CurrentPos == 11)
            {
                transform.position = Vector3.MoveTowards(transform.position, StartPos1.position, .02f);
            }
            if (CurrentPos == 12)
            {
                transform.position = Vector3.MoveTowards(transform.position, StartPos2.position, .02f);
            }
            if (CurrentPos == 13)
            {
                transform.position = Vector3.MoveTowards(transform.position, StartPos3.position, .02f);
            }
            if (CurrentPos == 4)
            {
                doOnce = false;
            }
            
        }


       else if (!doOnce)
        {
            if (CurrentPos == 1)
            {
                transform.position = Vector3.MoveTowards(transform.position, Pos2.position, .02f);
            }
            if (CurrentPos == 2)
            {
                transform.position = Vector3.MoveTowards(transform.position, Pos3.position, .02f);
            }
            if (CurrentPos == 3)
            {
                transform.position = Vector3.MoveTowards(transform.position, Pos4.position, .02f);
            }
            if (CurrentPos == 4)
            {
                transform.position = Vector3.MoveTowards(transform.position, Pos1.position, .02f);
            }
        }
        

        yield return null;
    }

    private IEnumerator EnemyDeath()
    {
        StartPos0.gameObject.SetActive(true);
        transform.position = Vector3.MoveTowards(transform.position, StartPos0.position, .01f);
        if (transform.position == StartPos0.position)
        {
            Player.PowerMode = false;
            if (!Player.EnemyRed)
            {
                Player.EnemyRed = true;
            }
            StartPos0.gameObject.SetActive(false);
        }
        yield return null;
    }
}
