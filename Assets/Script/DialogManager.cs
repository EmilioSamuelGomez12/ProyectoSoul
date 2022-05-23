using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{
    int NameCounter = 0;
    public Text nameText;
    public Text dialogText;
    public Image Cammus;
    public Image Mindy;

    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        
        sentences = new Queue<string>();
    }

    public void StartDialog (Dialog dialog)
    {
        if((NameCounter % 2) == 0 || NameCounter == 0)
        {
            Cammus.GetComponent<Image>().enabled = true;
            nameText.text = dialog.name[1];
        }
        else
        {
            Cammus.GetComponent<Image>().enabled = true;
            nameText.text = dialog.name[0];
        }    

        
        sentences.Clear();

        foreach(string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }


    public void DisplayNextSentence()
    {
        NameCounter++;
        if (((NameCounter % 2) == 0 || NameCounter == 0) && NameCounter<13)
        {
            Cammus.GetComponent<Image>().enabled = false;
            nameText.text = "Mindy";
            Mindy.GetComponent<Image>().enabled = true;

        }
        else
        {
            Mindy.GetComponent<Image>().enabled = false;
            nameText.text = "Cammus";
            Cammus.GetComponent<Image>().enabled = true;
        }

        if (sentences.Count ==0)
        {
            EndDialog();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogText.text = sentence;

    }
    
    void EndDialog()
    {
        SceneManager.LoadScene(1);
    }

}
