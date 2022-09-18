using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceScript : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Bounce(float force){
        rb.velocity = new Vector2 (0f , 0f);
        rb.AddRelativeForce(Vector2.up * force, ForceMode2D.Impulse);
    }

    public void RealignVertical(float force){
        rb.velocity = new Vector2 (0f , 0f);
        rb.AddForce(Vector2.right * force, ForceMode2D.Impulse);
    }
    public void RealignHorizontal(float force){
        rb.velocity = new Vector2 (0f , 0f);
        rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
    }
    
    public void Fall(float force){
        rb.velocity = new Vector2 (0f , 0f);
        rb.AddForce(Vector2.down * force, ForceMode2D.Impulse);
    }
    
}
