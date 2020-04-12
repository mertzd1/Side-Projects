using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float movementSpeed;
    public float extraSpeedPerHit;
    public float maxExtraSpeed;

    int hitCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(this.StartBall());
    }
    //this places the ball back after a player scores
    void PositionBall(bool isStartingPlayer1)
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        if (isStartingPlayer1)
        {
            this.gameObject.transform.localPosition = new Vector3(-100, 0, 0); //places ball to the left
        }
        else
        {
            this.gameObject.transform.localPosition = new Vector3(100, 0, 0); //places ball to the right
        }
            
    }
    //this moves the ball to the left or right based on who scored last, it call the isStartingPlayer1
    //method to determine where to place the ball
    public IEnumerator StartBall(bool isStartingPlayer1 = true)
    {
        this.PositionBall(isStartingPlayer1);

        this.hitCounter = 0;
        yield return new WaitForSeconds(2);
        if (isStartingPlayer1)
            this.MoveBall(new Vector2(-1, 0)); //this means the ball will move to the left
        else
        {
            this.MoveBall(new Vector2(1, 0));
        }

    }

    public void MoveBall(Vector2 dir)
    {
        dir = dir.normalized;

        float speed = this.movementSpeed + this.hitCounter * this.extraSpeedPerHit;

        Rigidbody2D rigidbody2d = this.gameObject.GetComponent<Rigidbody2D>();

        rigidbody2d.velocity = dir * speed;

    }

    public void IncreaseHitCounter()
    {
        if(this.hitCounter * this.extraSpeedPerHit <= this.maxExtraSpeed)
        {
            this.hitCounter++;
        }
    }

   
}
