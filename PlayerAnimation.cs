using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    [SerializeField]
    private Sprite[] animSprites;

    public float timeThreshold = 0.1f;

    private float timer;
    private int state = 0;

    private SpriteRenderer sr;

    private PlayerMovement PlayerMovement;


    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
       
    }

    private void Start()
    {
        PlayerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (PlayerMovement.PLAYER_MOVING == true)
        {
            if (Time.time > timer)
            {
                sr.sprite = animSprites[state % animSprites.Length]; //E.g. 10 % 6 = 4 as there are 4 left over. 0 % 4 = 0. 1 % 4 = 1, 2 % 4 = 2, 3 % 4 = 3, 4 % 4 = 0, 5 % 4 = 1 and so on...
                state++;
                timer = Time.time + timeThreshold;
            }
        }
    }
}
