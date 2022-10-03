 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1;

    private SpriteRenderer player;
    private Animator animation;
    private void Awake()
    {
        player = GetComponent<SpriteRenderer>();
        animation = GetComponent<Animator>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal") * speed;

        if (x < 0)  // vira para a esquerda
            player.flipX = true;
        else
          if (x > 0)  // vira para a direita
            player.flipX = false;
        // se for 0, fica como está

        Vector2 movimento = new Vector2(x, 0f) * Time.deltaTime;
        
        transform.Translate(movimento);
        if(x != 0)
            animation.SetBool("walk", true);
        else
            animation.SetBool("walk", false);
    }

}
