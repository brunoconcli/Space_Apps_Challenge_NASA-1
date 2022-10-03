using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDialogue : MonoBehaviour
{
    public SpriteRenderer player;
    public SpriteRenderer npc;
    public SpriteRenderer button;
    public Dialogue dialogue;
    public DialogueManager dialogueManager;
    public SpriteRenderer particle1;

    public int counter = 0;

    public Animator animator;

    public bool isFollow = false;
    // Start is called before the first frame update
    void Update()
    {
        float playerX = player.transform.position.x;
        float buttonX = button.transform.position.x;
        if (!isFollow && playerX - buttonX <= 0.2f && playerX - buttonX >= -0.2f)
        {
            button.enabled = true;
            npc.flipX = true;
            if (Input.GetKeyDown("e"))
            {
                particle1.enabled = true;
                counter = 0;
                button.enabled = false;
                isFollow = true;
                dialogueManager.StartDialogue(dialogue);
            }
        }
        else
        {
            button.enabled = false;
            if (Input.GetKeyDown("e") && counter < dialogue.names.Length)
            {
                dialogueManager.DisplayNextSentence();
                counter++;
                Debug.Log(counter);
            }
            else if (counter >= dialogue.names.Length) //Diálogo acaba 
            {
                particle1.enabled = false;

                isFollow = false;
                counter = 0;
                Debug.Log(counter);
            }
            
        }
    }
}
