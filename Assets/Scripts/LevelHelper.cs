using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class LevelHelper : MonoBehaviour
{
    public TMP_Text playButton;
    public GameObject buttonNew;
    public Button buttonPlay, buttonSave, buttonLoad;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buttonNew.SetActive(false);
        buttonPlay.interactable = true;
        buttonSave.interactable = true;
        buttonLoad.interactable = true;
        SaveManager.Instance.LoadGame();
        //Invoke(nameof(CheckLevel), .2f);
        
    }


    public void NewGamer()
    {
        SaveManager.Instance.NewPlayer();
    }


    public void PlayGame()
    {
       ManagerScene.Instance.PlayScene();
    }

    public void SaveGame()
    {
        SaveManager.Instance.ToSavePlayer();
    }

    public void LoadGame()
    {
        SaveManager.Instance.LoadGame();
    }


    private void Update()
    {
        CheckLevel();
    }

    private void CheckLevel()
    {
        playButton.text = "Play \n Level " + (SaveManager.Instance.AtualLevel()).ToString();
        if (SaveManager.Instance.IsLoadPlayer() == false)
        {
            NewPlayer();
        }
        else
        {
            Debug.Log(" IsloadPlayer não carregado");
        }
    }

    public void NewPlayer()
    {
        buttonNew.SetActive(true);
        buttonPlay.interactable = false;
        buttonSave.interactable = false;
        buttonLoad.interactable = false;
    }

}
