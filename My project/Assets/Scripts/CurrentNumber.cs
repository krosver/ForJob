using System;
using UnityEngine;
public class CurrentNumber : MonoBehaviour
{
    public int Current;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Current = Convert.ToInt16(collision.name);
    }
}
