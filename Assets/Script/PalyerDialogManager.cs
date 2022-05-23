using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PalyerDialogManager : MonoBehaviour
{
    public GameObject[] dialogObjects;
    public GameObject player;
    int NameCounter = 0;

    public Text nameText;
    public Text dialogText;
    public Image Cammus;
    public Image Mindy;

    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<MeshRenderer>().enabled = false;
        player.GetComponent<Rigidbody>().isKinematic = true;
        player.GetComponent<Player_Movement>().enabled = false;
        player.GetComponent<Player_Movement>().enabled = true;
        sentences = new Queue<string>();
    }

    public void StartDialog(Dialog dialog)
    {
        if ((NameCounter % 2) == 0 || NameCounter == 0)
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

        foreach (string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }


    public void DisplayNextSentence()
    {
        NameCounter++;
        if (((NameCounter % 2) == 0 || NameCounter == 0) && NameCounter < 19)
        {
            nameText.text = "Mindy";

        }
        else
        {
            Mindy.GetComponent<Image>().enabled = false;
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
        KillDialogs();
        player.GetComponent<MeshRenderer>().enabled = true;
        player.GetComponent<Rigidbody>().isKinematic = false;
        player.GetComponent<Player_Movement>().enabled = true;
        player.GetComponent<Player_Movement>().enabled = true;
    }

    public void KillDialogs()
    {
        dialogObjects[0].SetActive(false);
        dialogObjects[1].SetActive(false);
        dialogObjects[2].SetActive(false);
        dialogObjects[3].SetActive(false);
        dialogObjects[4].SetActive(false);
    }

}
