using UnityEngine;
using System.Collections;

public class PongBat : MonoBehaviour
{

    private GameController controler;
    private Rigidbody2D body;
    private PolygonCollider2D shape;
    private GroundCreator creator;
    private Renderer gfx;

    public KeyCode up, down;
    public float speed = 1;

	// Use this for initialization
	void Awake ()
	{
	    controler = FindObjectOfType<GameController>();
	    body = GetComponent<Rigidbody2D>();
	    shape = GetComponent<PolygonCollider2D>();
	    creator = GetComponent<GroundCreator>();
	    gfx = GetComponent<Renderer>();
	}

    //void Start()
    //{
    //    NewShape();
    //}

    public void NewShape()
    {
        gfx.material.color = controler.colors[Random.Range(0, controler.colors.Length)];
        shape.points = controler.colliders[Random.Range(0, controler.colliders.Length)].points;
        creator.updateMesh = true;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
	{
	    int dir = 0;
        dir += Input.GetKey(up) ? 1 : 0;
        dir -= Input.GetKey(down) ? 1 : 0;

        body.velocity = new Vector2(0, dir * speed);
    }

    private bool isChanging = false;
    IEnumerator OnCollisionEnter2D(Collision2D col)
    {
        if (isChanging)
            yield break;

        if (col.gameObject.name == "Ball")
        {
            isChanging = true;
            col.gameObject.GetComponent<SpriteRenderer>().color = gfx.material.color;
            NewShape();
            yield return new WaitForSeconds(0.3f);
            isChanging = false;
        }
    }
}
