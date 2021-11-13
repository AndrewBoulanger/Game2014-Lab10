using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [Header("Movement")]
    public float runForce;
    public Transform lookAheadPoint;
    public LayerMask groundLayerMask, wallLayerMask;
    public bool isGroundAhead;

    Rigidbody2D rigidbody;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        wallLayerMask = LayerMask.GetMask("Wall", "Platform");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        LookAhead();
        MoveEnemy();
    }

    private void LookAhead()
    {
        //ground check
        var hit = Physics2D.Linecast(transform.position, lookAheadPoint.position, groundLayerMask);
        isGroundAhead = (hit) ? true : false;

        //wall check
        Vector3 eyeLevelLookAheadPoint = lookAheadPoint.position;
        eyeLevelLookAheadPoint.y = transform.position.y;
        hit = Physics2D.Linecast(transform.position, eyeLevelLookAheadPoint, wallLayerMask);
        if(hit)
        {
            Flip();
        }
    }

    private void MoveEnemy()
    {
        if(isGroundAhead)
        {
            rigidbody.AddForce(Vector2.left * runForce * transform.localScale.x);
            rigidbody.velocity *= 0.90f;
            print("adding velocity");
        }
        else
        {
            Flip();
        }
    }

    private void Flip()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            transform.SetParent(collision.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            transform.SetParent(null);
        }
    }




    //Utilities
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, lookAheadPoint.position);
    }
}
