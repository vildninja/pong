using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public Color[] colors;
    public PolygonCollider2D[] colliders;

    public Transform left, right;

	// Use this for initialization
	void Awake ()
    {
        colliders = GetComponentsInChildren<PolygonCollider2D>();
	}

    void Start()
    {
        var cam = Camera.main;
        left.position = new Vector3(-cam.orthographicSize * cam.aspect + 1.5f, 0);
        right.position = new Vector3(cam.orthographicSize * cam.aspect - 1.5f, 0);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    [ContextMenu("Initialize Hue")]
    public void InitializeHue()
    {
        colors = new Color[41];
        for (int i = 0; i < 20; i++)
        {
            colors[i] = Color.HSVToRGB(i / 20f, 1, 1);
        }
        for (int i = 0; i < 20; i++)
        {
            colors[i + 20] = Color.HSVToRGB(i / 20f, 0.4f, 1);
        }
        colors[40] = Color.white;
    }
}
