using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformController : MonoBehaviour
{
    [Header("Movement")]
    public MovingPlatformDirections direction;

    [Range(0.1f, 10.0f)]
    public float speed;
    [Range(1f, 100f)]
    public float distance;
    public bool isLooping;

    float distanceOffset = 0.1f; 

    Vector2 startingPosition;
    bool isMovingActive;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        isMovingActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();

    }

    private void MovePlatform()
    {
        float pingPongValue = (isMovingActive) ? Mathf.PingPong(Time.time * speed, distance) : distance;

        if((!isLooping) && pingPongValue >= distance - distanceOffset)
        {
            isMovingActive = false;
        }

        switch(direction)
        {
            case MovingPlatformDirections.Horizontal:
                transform.position = new Vector2(
                    startingPosition.x + pingPongValue,
                    transform.position.y);
                break;
            case MovingPlatformDirections.Vertical  :
                transform.position = new Vector2(
                    transform.position.x, 
                    startingPosition.y + pingPongValue);
                break;
            case MovingPlatformDirections.Diagonal_Up:
                 transform.position = new Vector2(
                     startingPosition.x + pingPongValue, 
                     startingPosition.y + pingPongValue);
                break;
            case MovingPlatformDirections.Diagonal_Down:
                transform.position = new Vector2(
                     startingPosition.x + pingPongValue,
                     startingPosition.y - pingPongValue);
                break;

        }

    }

}
