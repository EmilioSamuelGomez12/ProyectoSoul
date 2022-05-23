using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalSceneDialogManager : MonoBehaviour
{
    int NameCounter = 0;
    public Text nameText;
    public Text dialogText;
    public Image FinalSceneMiedo;

    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialog(Dialog dialog)
    {
        FinalSceneMiedo.GetComponent<Image>().enabled = true;
        if ((NameCounter % 2) == 0 || NameCounter == 0)
        {
            nameText.text = dialog.name[1];
        }
        else
        {
            nameText.text = dialog.name[0];
        }


        sentences.Clear();

        foreach (string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }


    public void DisplayNextSentence()
    {
        NameCounter++;
        if (((NameCounter % 2) == 0 || NameCounter == 0) && NameCounter < 13)
        {
            nameText.text = "Niño";
        }
        else
        {
            nameText.text = "Cammus";
        }

        if (sentences.Count == 0)
        {
            EndDialog();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogText.text = sentence;

    }

    void EndDialog()
    {
        SceneManager.LoadScene(0);
    }
}
