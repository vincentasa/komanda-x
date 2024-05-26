using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentLooks : MonoBehaviour
{
    public Transform tail;
    public Transform turn;
    public void Body()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        tail.GetComponent<SpriteRenderer>().enabled = false;
        //turn.GetComponent<SpriteRenderer>().enabled = false;
    }
    public void Tail()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        tail.GetComponent<SpriteRenderer>().enabled = true;
        //turn.GetComponent<SpriteRenderer>().enabled = false;
    }
    public void Turn()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        tail.GetComponent<SpriteRenderer>().enabled = false;
        //turn.GetComponent<SpriteRenderer>().enabled = true;
    }
}
