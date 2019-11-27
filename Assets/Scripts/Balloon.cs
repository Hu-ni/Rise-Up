using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    private LevelManager lm;

    private void Awake()
    {
        lm = GetComponent<LevelManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Structure")
        {
            GameManager.gm.ps = PlayState.Dead;
            Time.timeScale = 0;
            Destroy(this.gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Level_End"))
        {
            lm.spawnLevel();
        }
    }
}
