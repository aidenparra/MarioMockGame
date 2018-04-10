using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeBlock : MonoBehaviour
{
    public AnimationCurve anim;

    public int coinsInBlock = 5;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.contacts[0].point.y < transform.position.y)
        {
            StartCoroutine("StartAnim");
        }
        
    }
    IEnumerator StartAnim()
    {
        Vector2 startPos = transform.position;
        for (float x = 0; x < anim.keys[anim.length - 1].time; x += Time.deltaTime)
        {
            transform.position = new Vector2(startPos.x, startPos.y + anim.Evaluate(x));

            yield return null;
        }
    }


}