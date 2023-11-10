using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    private Transform player;

    public float speed;
    public float offsetX;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;    
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newCamPosition = new Vector3(player.position.x + offsetX, 0f, transform.position.z);
        transform.position = Vector3.Slerp(transform.position, newCamPosition, speed * Time.deltaTime);
    }
}
