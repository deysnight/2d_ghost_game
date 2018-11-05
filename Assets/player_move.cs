using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour {

    public Vector2 speed = new Vector2(6, 6);
    private Vector2 movement;

    public GameObject newFollow;

    List<GameObject> followList;

    private void Start()
    {
        followList = new List<GameObject>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("spawner"))
        {
            GameObject neww;
            neww = Instantiate(newFollow, transform.position, Quaternion.identity);
            followList.Add(neww);

            for (int i = 0; i < followList.Count; i++)
            {
                if (i == 0)
                {
                    followList[i].GetComponent<follow_move>().leader = this.gameObject;
                }
                else
                {
                    followList[i].GetComponent<follow_move>().leader = followList[i - 1];
                }
            }
        }
    }

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        movement = new Vector2(
                speed.x * inputX,
                speed.y * inputY);

    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = movement;
    }
}
