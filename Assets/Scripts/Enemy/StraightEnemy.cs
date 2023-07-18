using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction { Horizental, Vertical}

public class StraightEnemy : MonoBehaviour
{
    public Direction direction;
    public float speed = 5f; // Speed of enemy movement
    private bool movingHere = true; // Flag to track movement direction

    private void Update()
    {
        switch (direction)
        {
            case Direction.Horizental:
                MoveHorizental();
                break;
            case Direction.Vertical:
                MoveVertical();
                break;
            default:
                break;
        }
    }
    private void MoveHorizental(){
        float moveAmount = movingHere ? speed : -speed;
        transform.Translate(Vector2.right * moveAmount * Time.deltaTime);
    }
    private void MoveVertical(){
        float moveAmount = movingHere ? speed : -speed;
        transform.Translate(Vector2.up * moveAmount * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "wall")
        {
            movingHere = !movingHere;
        }

        if (other.gameObject.tag == "Player"){
            other.gameObject.GetComponent<PlayerStatus>().Damage();
        }

    }
}