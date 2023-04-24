using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBarScript healthBar;
    public Scorer scorer;

    public ReginaldSpawner rs;
    public HubertSpawner hs;

    bool grabbedFlag = false;
    Collider2D Flag;
    Vector2 blueFlagStartLocation = new Vector2(-20, -19);
    Vector2 redFlagStartLocation = new Vector2(20, 21);

    private void Start()
    {
        HealthStartSetter();
        hs = GameObject.Find("Blue Spawn").GetComponent<HubertSpawner>();
        rs = GameObject.Find("Red Spawn").GetComponent<ReginaldSpawner>();
    }
    private void Update()
    {
        if (grabbedFlag == true)
        {
            CarryFlag();
            if(currentHealth <= 0)
            {
                FlagReplacer();
            }
        }
        if(currentHealth <= 0)
        {
            RespawnPlayer();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FlagGrabber(collision);
        FlagScorer(collision);    
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Damager(collision);
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
        if (tag == "RedPlayer" && collision.tag == "Blueflag")
        {
            grabbedFlag = true;
            Flag = collision;
        }
    }
    private void FlagScorer(Collider2D collision)
    {
        if (grabbedFlag == true)
        {
            if (tag == "BluePlayer" && collision.tag == "BlueFlagPad")
            {
                grabbedFlag = false;
                Flag.transform.position = redFlagStartLocation;
                scorer.IncreaseBlueScore();
            }
            else if (tag == "RedPlayer" && collision.tag == "RedFlagPad")
            {
                grabbedFlag = false;
                Flag.transform.position = blueFlagStartLocation;
                scorer.IncreaseRedScore();
            }
        }
    }
    public void HealthStartSetter()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Damager(Collision2D collision)
    {
        if(collision.gameObject.tag == "Damage")
        {
            currentHealth -= 10;
            healthBar.SetHealth(currentHealth);
        }
    }
    private void RespawnPlayer()
    {
        if(tag == "BluePlayer")
        {
            transform.position = hs.GetHubertSpawnPoint();
            currentHealth = maxHealth;
            healthBar.SetHealth(maxHealth);
        }
        else
        {
            transform.position = rs.GetReginaldSpawnPoint();
            currentHealth = maxHealth;
            healthBar.SetHealth(maxHealth);
        }
    }
    private void FlagReplacer()
    {
        grabbedFlag = false;
        if (Flag != null)
        {
            if (Flag.tag == "RedFlag")
            {
                Flag.transform.position = redFlagStartLocation;
            }
            else if (Flag.tag == "BlueFlag")
            {
                Flag.transform.position = blueFlagStartLocation;
            }
            Flag = null;
        }
    }
}
