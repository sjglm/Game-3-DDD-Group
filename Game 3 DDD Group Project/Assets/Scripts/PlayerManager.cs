using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private float HitPoints = 100f;
    bool grabbedFlag = false;
    Collider2D Flag;
    Vector2 redFlagStartLocation = new Vector2(-7.7f, 0.789f);
    Vector2 blueFlagStartLocation = new Vector2(8.96f, 1.16f);

    private void Update()
    {
        if(grabbedFlag == true)
        {
            CarryFlag();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FlagGrabber(collision);
        FlagScorer(collision);
    }
    private void CarryFlag()
    {
        Vector2 flagOffset = new Vector2(0f, 1f);
        Flag.transform.position = (Vector2)transform.position + flagOffset;
    }
    private void FlagGrabber(Collider2D collision)
    {
        if (tag == "BluePlayer" && collision.tag == "RedFlag")
        {
            grabbedFlag = true;
            Flag = collision;
        }
        if(tag == "RedPlayer" && collision.tag == "Blueflag")
        {
            grabbedFlag = true;
            Flag = collision;
        }
    }
    private void FlagScorer(Collider2D collision)
    {
        if(grabbedFlag != true) { }
        if(grabbedFlag == true)
        {
            if(tag == "BluePlayer" && collision.tag == "BlueFlagPad")
            {
                grabbedFlag = false;
                Flag.transform.position = redFlagStartLocation;
            }
            else if(tag == "RedPlayer" && collision.tag == "RedFlagPad")
            {
                grabbedFlag = false;
                Flag.transform.position = blueFlagStartLocation;
            }
        }
    }
}
