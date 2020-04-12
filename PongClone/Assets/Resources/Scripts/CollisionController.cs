using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public BallMovement ballMovement;
    public ScoreController scoreController;

    void BounceFromRaquet(Collision2D c)
    {
        Vector3 ballPosition = this.transform.position;
        Vector3 raquetPosition = c.gameObject.transform.position;

        float raquetHeight = c.collider.bounds.size.y;

        float x;

        if (c.gameObject.name == "Player1")
        {
            x = 1;
        }
        else
            x = -1;

        float y = (ballPosition.y - raquetPosition.y) / raquetHeight;

        this.ballMovement.IncreaseHitCounter();
        this.ballMovement.MoveBall(new Vector2(x, y));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player1" || collision.gameObject.name == "Player2")
        {
            this.BounceFromRaquet(collision);
            
        }
        else if (collision.gameObject.name == "LeftWall")
        {
            Debug.Log("Collision with LeftWall");
            this.scoreController.GoalPlayer2();
            StartCoroutine(this.ballMovement.StartBall(true)); //calls on the Ballmovement class and startball method each timethe wall is hit
        }
        else if (collision.gameObject.name == "RightWall")
        {
            Debug.Log("Collision with RightWall");
            this.scoreController.GoalPlayer1();
            this.StartCoroutine(this.ballMovement.StartBall(false));//calls on the Ballmovement class and startball method each timethe wall is hit
        }
    }
}
