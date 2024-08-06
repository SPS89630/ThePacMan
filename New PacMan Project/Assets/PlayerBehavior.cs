using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private bool isMoving;
    private Vector3 originalPos, targetPos;
    private float timeToMove = 0.2f;

    DetectionDown DetectionDown;
    DetectionLeft DetectionLeft;
    DetectionRight DetectionRight;
    DetectionUp DetectionUp;

    void Start()
    {
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
    }

    // IEnumerator that makes the player move
    private IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;
        float elapsedTime = 0;

        originalPos = transform.position;
        targetPos = originalPos + direction;

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
