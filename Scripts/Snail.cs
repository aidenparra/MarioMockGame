using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snail : MonoBehaviour {


    public float speed = 2f;
    Vector2 direction = Vector2.left;
        // Update is called once per frame
	void FixedUpdate ()
    {
        GetComponent<Rigidbody2D>().velocity = direction * speed;
	}


    private void OnTriggerEnter2D(Collider2D col)
    {

        transform.localScale = new Vector2(-1 * transform.localScale.x, transform.localScale.y);
        direction = new Vector2(-1 * direction.x, direction.y);


    }
    private void OnCollisionEnter2D(Collision col)
    {
        if(col.gameObject.name == "Fabio")
        {
            if (col.contacts[0].point.y < transform.position.y)
            {
                GetComponent<Animator>().SetTrigger("dead");
                GetComponent<Collider2D>().enabled = false;

            }
        }
    }
}
