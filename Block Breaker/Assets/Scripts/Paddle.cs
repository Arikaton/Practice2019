using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthinUnits = 16f;
    [SerializeField] float paddleMinPos = 1f;
    [SerializeField] float paddleMaxPos = 15f;

    GameStatus gameStatus;
    Ball ball;
    float keyPos = 8f;
    [SerializeField] float keyVel;

    void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            gameStatus.ChangeMoveSet();
        }
        if (gameStatus.moveByMouse)
        {
            MouseMove();
        }
        else
        {
            KeyMove();
        }
    }

    private void KeyMove()
    {
        keyPos += Input.GetAxis("Horizontal") * keyVel;
        keyPos = Mathf.Clamp(keyPos, paddleMinPos, paddleMaxPos);
        Vector2 paddlePos = new Vector2(keyPos, transform.position.y);
        transform.position = paddlePos;
    }

    private void MouseMove()
    {
        Vector2 paddlePos = new Vector2(Mathf.Clamp(GetXPos(), paddleMinPos, paddleMaxPos), transform.position.y);
        transform.position = paddlePos;
    }

    private float GetXPos()
    {
        if (gameStatus.IsAutoPlayEnabled())
        {
            return ball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthinUnits;
        }
    }
}
