using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

	public Text nameText;
	public Text dialogueText;

	public Animator animator;

	private Queue<string> sentences;
	private Queue<string> names;

	void Start()
	{
		sentences = new Queue<string>();
		names = new Queue<string>(); // 
	}

	public void StartDialogue(Dialogue dialogue)
	{
		Debug.Log("Conversation Started"); // remove later
		animator.SetBool("IsOpen", true);

		// nameText.text = dialogue.names; // 

		foreach (string name in dialogue.names) //
        {
			names.Enqueue(name);
        } 
		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	public void DisplayNextSentence()
	{

		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();
		string name = names.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence, name));

	}

	IEnumerator TypeSentence(string sentence, string name)
	{
		dialogueText.text = "";
		nameText.text = ""; //
		foreach (char letter in name.ToCharArray())
        {
			nameText.text += letter;
			yield return null;
        }
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}

	void EndDialogue()
	{
		animator.SetBool("IsOpen", false);
	}

}