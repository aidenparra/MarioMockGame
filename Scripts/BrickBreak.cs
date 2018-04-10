using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBreak : MonoBehaviour {

    private SpriteRenderer iWannaPuke;
    public Sprite brokebrick;
    public float changeTime = .1f;

    private void Awake()
    {
        //BIG SLOPING PENIS
    }

    private void OnCollisionEnter2D(Collision col)
    {
        if (col.contacts[0].point.y < transform.position.y)
        {

        }
    }
}
