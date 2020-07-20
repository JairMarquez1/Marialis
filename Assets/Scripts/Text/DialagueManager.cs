using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialagueManager : MonoBehaviour
{

    public Dialogue dialogue;

    private Queue<string> sentences; //Lista de oraciones.
    private string activeSentence;

    public GameObject dialoguePanel;
    public TextMeshPro displayText;
 
    bool isTrue;
    public float typingSpeed;

    AudioSource myAudio;
    public AudioClip typeSound;

    void Start()
    {
        sentences = new Queue<string>();
        myAudio = GetComponent<AudioSource>();
    }


    void StartDialogue()
    {
        sentences.Clear();

        foreach(string sentence in dialogue.sentenceList)
        {
            sentences.Enqueue(sentence); //Añade oración a la lista.
        }

        
        NextSentence();
        
    }

  
    void NextSentence()
    {
        if(sentences.Count == 0) //No existen más diálogos en la lista.     
            return; //Termina el diálogo.
        else
        {
            activeSentence = sentences.Dequeue(); //Saca la oración del listado y devuelve la que queda.
            DisplayNextSentence();
        }     
    }

    void DisplayNextSentence()
    {
        StartCoroutine(TypeTheSentence(activeSentence));
    }

    IEnumerator TypeTheSentence(string sentence)
    {
        displayText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            displayText.text += letter;
            myAudio.PlayOneShot(typeSound);
            yield return new WaitForSeconds(typingSpeed);
        }
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A) && isTrue == true)
        {
            NextSentence();
        }   
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartDialogue();
            isTrue = true;
        }
        
    }
}
