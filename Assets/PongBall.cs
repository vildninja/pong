using UnityEngine;
using System.Collections;

public class PongBall : MonoBehaviour
{
    private Rigidbody2D body;
    private float speed = 10;

	// Use this for initialization
	void Start ()
	{
	    body = GetComponent<Rigidbody2D>();
	    body.velocity = Vector2.left * speed; 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        transform.position = Vector3.zero;
        body.velocity = Mathf.Sign(col.transform.position.x)*Vector2.left* speed;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        var vel = body.velocity;

        if (Mathf.Abs(vel.x) < 4)
        {
            vel.x = Mathf.Sign(vel.x)*5;
        }
        
        body.velocity = vel.normalized * speed;
    }
}
