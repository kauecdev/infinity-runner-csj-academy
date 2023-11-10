using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rig;
    private bool isJumping;

    public Animator animator;
    public float speed;
    public float jumpForce;
    public Transform projectileOrigin;
    public GameObject projectilePrefab;

    // Start is called before the first frame update
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        Jump();
        Shoot();
    }

    private void FixedUpdate()  
    {
        MoveToRigth();
    }

    private void MoveToRigth()
    {
        rig.velocity = new Vector2(speed, rig.velocity.y);
    }

    private void Jump()
    {
        if (!isJumping && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            animator.SetBool("isJumping", true);
        } 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isJumping = false;
            animator.SetBool("isJumping", false);
        }
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.K)) 
        {
            Instantiate(projectilePrefab, projectileOrigin.position, projectileOrigin.rotation);
        }
    }
}
