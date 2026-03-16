using Itens;
using Play.HD.Singleton;
using System.IO;

using UnityEngine;
//using UnityEngine.SceneManagement;
using System.Linq;

public class SaveManager : Singleton<SaveManager>  //MonoBehaviour
{


    private string _path = "";
    //string _path = Application.dataPath + "/save.txt"; // salva no projeto
    // string _path = Application.streamingAssetsPath + "/save.txt" ; // salva na pasta StreamingAssets  nos assets
    //string _path = Application.persistentDataPath + "/save.txt"; // salva na pasta de windows

    public SaveSetting savePlayer;// {  get; private set; }
    public bool existPlayer = false;
    public override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        existPlayer = false;
        savePlayer = new SaveSetting();
        //_path = Application.persistentDataPath + "/save.txt";
        _path = Application.streamingAssetsPath + "/save.txt" ; // salva na pasta StreamingAssets  nos assets
        LoadGame();

    }



    [NaughtyAttributes.Button]
    public void ToSavePlayer()
    {
       
        string toJson =  JsonUtility.ToJson(savePlayer, true);    
        Debug.Log(toJson);
        SaveGame(toJson);
    }


    public void LastLevel(int lvl)
    {
        savePlayer.level = lvl;
        ToSavePlayer();
    }

    public int AtualLevel()
    {
        return savePlayer.level;
    }


    public void NamePlayer(string name)
    {
        savePlayer.name = name;
    }
    
    public void LivesPlayer(int lvl)
    {
        savePlayer.lives = lvl;
    }

    public bool IsLoadPlayer()
    {
        return existPlayer;
    }


    public void SaveStatusPlayer()
    {
        //savePlayer.score = score;
        savePlayer.coins = Itens.ItemManager.Instance.itemSetups.Find(i => i.itemtype == itemType.coin).amount.value;
        savePlayer.gems = Itens.ItemManager.Instance.itemSetups.Find(i => i.itemtype == itemType.gems).amount.value;
        ToSavePlayer();
    }


    [NaughtyAttributes.Button]
    public void LoadGame()
    {
        

        // 1. Verificar se o arquivo existe antes de tentar ler
        if (File.Exists(_path))
        {
            // 2. Ler o arquivo de texto
            string json = File.ReadAllText(_path);

            // 3. Converter o JSON para o objeto savePlayer
            // O "JsonUtility.FromJsonOverwrite" preenche o objeto que já existe
            JsonUtility.FromJsonOverwrite(json, savePlayer);

            Debug.Log("Jogo Carregado com Sucesso!");
            Debug.Log("Nome: " + savePlayer.name + " | Moedas: " + savePlayer.coins + "| level" + savePlayer.level);

            // 4. Aplicar os dados carregados ao ManagerScene ou Player
            ApplyLoadedData();
            existPlayer = true;
        }
        else
        {
            Debug.LogWarning("Arquivo de save não encontrado em: " + _path);
            existPlayer = false;
        }
    }


    public void NewPlayer()
    {
        
        savePlayer.name = "HDLU";
        savePlayer.level = 1;
        savePlayer.lives = 5;
        savePlayer.coins = 0;
        savePlayer.gems = 0;
        ToSavePlayer();
        ManagerScene.Instance.PlayScene();

    }




    private void ApplyLoadedData()
    {
        // Exemplo: Atualizar a fase atual no ManagerScene
        if (ManagerScene.Instance != null)
        {
            ManagerScene.Instance.fase = savePlayer.level;
            
        }
       

        // Se tiveres um sistema de itens, deves devolver as moedas para lá aqui
        // Exemplo: Itens.ItemManager.Instance.UpdateCoins(savePlayer.coins);
    }





    private void SaveGame(string json)
    {
        
        Debug.Log(_path);
        File.WriteAllText(_path, json); // salva o arquivo save.txt no caminho C:\Users\HD.FLOR\AppData\LocalLow\DefaultCompany\EBAC_Adventure3D\save.txt
    }



}

[System.Serializable]
public class SaveSetting
{
    public string name;
    public int level;
    public int lives;
    public int score;
    public int coins;
    public int gems;
    public int lifePack;
}

