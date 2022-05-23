using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog dialog;
    public GameObject[] dialogObjects;

    public void TriggerDialog()
    {
        dialogObjects[0].SetActive(true);
        dialogObjects[1].SetActive(true);
        dialogObjects[2].SetActive(true);
        dialogObjects[3].SetActive(false);
        FindObjectOfType<DialogManager>().StartDialog(dialog);

    }

    public void TriggerDialogP()
    {
        dialogObjects[0].SetActive(true);
        dialogObjects[1].SetActive(true);
        dialogObjects[2].SetActive(true);
        dialogObjects[3].SetActive(false);
        FindObjectOfType<PalyerDialogManager>().StartDialog(dialog);
    }

    public void TriggerDialogF()
    {
        dialogObjects[0].SetActive(true);
        dialogObjects[1].SetActive(true);
        dialogObjects[2].SetActive(true);
        dialogObjects[3].SetActive(false);
        dialogObjects[4].SetActive(true);
        FindObjectOfType<FinalSceneDialogManager>().StartDialog(dialog);

    }
}
