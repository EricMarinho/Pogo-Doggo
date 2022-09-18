using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public static PlayerController Instance { get; private set; }

    private float _bounceForce = 4f;
    private float maxBounce = 10f;
    public float BounceForce
    {
        get { return _bounceForce; }
        set {_bounceForce = (value < maxBounce) ? (value) : (maxBounce);}
    }
    public float FallForce{ get { return _bounceForce * 2;}
    }
    public InputManager inputManager;
    public BounceScript bounceScript;
    public ScoreHandler scoreHandler;
    private Rigidbody2D rb;
    // private string playerID = "";

    private void Awake() {
        Instance = this;

    }

}
