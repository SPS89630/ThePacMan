using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerBehavior : MonoBehaviour
{
    private bool isMoving;
    private Vector3 originalPos, targetPos;
    private float timeToMove = 0.1f;
    public TextMeshProUGUI scoreDisplay;

    public int Lives = 3;
    public int Score = 0;

    public bool PowerMode;
    public bool EnemyRed;

    DetectionDown DetectionDown;
    DetectionLeft DetectionLeft;
    DetectionRight DetectionRight;
    DetectionUp DetectionUp;

    void Start()
    {
        PowerMode = false;
        EnemyRed = false;

        DetectionDown = GameObject.Find("DetectDown").GetComponent<DetectionDown>();
        DetectionLeft = GameObject.Find("DetectLeft").GetComponent<DetectionLeft>();
        DetectionRight = GameObject.Find("DetectRight").GetComponent<DetectionRight>();
        DetectionUp = GameObject.Find("DetectUp").GetComponent<DetectionUp>();
    }

    void Update()
    {
        // WASD Movement Input
        if (Input.GetKey(KeyCode.W) && !isMoving && DetectionUp != null && !DetectionUp.WallUp)
            StartCoroutine(MovePlayer(Vector3.up));

        if (Input.GetKey(KeyCode.A) && !isMoving && DetectionLeft != null && !DetectionLeft.WallLeft)
            StartCoroutine(MovePlayer(Vector3.left));

        if (Input.GetKey(KeyCode.D) && !isMoving && DetectionRight != null && !DetectionRight.WallRight)
            StartCoroutine(MovePlayer(Vector3.right));

        if (Input.GetKey(KeyCode.S) && !isMoving && DetectionDown != null && !DetectionDown.WallDown)
            StartCoroutine(MovePlayer(Vector3.down));

        scoreDisplay.text = "SCORE " + Score.ToString();
    }

    // IEnumerator that makes the player move
    private IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;
        float elapsedTime = 0;

        originalPos = transform.position;
        targetPos = originalPos + direction/2;

        while (elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(originalPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;
        isMoving = false;
    }
}

