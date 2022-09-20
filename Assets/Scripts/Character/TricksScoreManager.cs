using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TricksScoreManager : MonoBehaviour
{
    private PlayerController instancePC;
    private Rigidbody2D rb;
    private float stuntRotation = 0f;
    private bool isStuntTime = false;

    private void Start()
    {
        instancePC = PlayerController.Instance;
        rb = instancePC.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isStuntTime)
        {
            if (stuntRotation == 0)
            {
                stuntRotation = Mathf.Round(rb.transform.localRotation.z * (-1));
            }
            else
            {
                if (Mathf.Round(rb.transform.localRotation.z) == stuntRotation)
                {
                    stuntRotation *= -1;
                    instancePC.scoreHandler.AddScore(10*instancePC.scoreHandler.Modifier);
                }
            }
        }

    }

    public void SetStunt(bool state)
    {
        stuntRotation = Mathf.Round(rb.transform.localRotation.z * (-1));
        isStuntTime = state;
    }
}
