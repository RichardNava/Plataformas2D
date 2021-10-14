using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public Vector2 min, max;
    public float smooth;
    Vector2 velocity;
    float x, y;


    private void Start()
    {
        x = player.transform.position.x;
        y = player.transform.position.y;
        this.transform.position = new Vector3(x, y, this.transform.position.z);
    }

    private void FixedUpdate()
    {
        x = Mathf.SmoothDamp(this.transform.position.x, player.transform.position.x, ref velocity.x, smooth);
        y = Mathf.SmoothDamp(this.transform.position.y, player.transform.position.y, ref velocity.y, smooth);

        this.transform.position = new Vector3(Mathf.Clamp(x,min.x,max.x), Mathf.Clamp(y, min.y, max.y), this.transform.position.z);
    }
}
