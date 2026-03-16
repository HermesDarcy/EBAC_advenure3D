using UnityEngine;
using UnityEngine.SceneManagement;
using Play.HD.Singleton;
using UnityEngine.UI;
using System.Collections;



public class ManagerScene : Singleton<ManagerScene>  //MonoBehaviour
{

    public int fase;
    public Slider slider;
    public GameObject telaLoad;


    public override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }


    /*
    public void SaveGame()
    {
        if(SaveManager.Instance != null)
        {
            SaveManager.Instance.ToSavePlayer();
        }
        
    }


    public void LoadGame()
    {
        if (SaveManager.Instance != null)
        {
            SaveManager.Instance.LoadGame();
            // Após carregar os dados, podemos mudar para a fase salva
            PlayScene(SaveManager.Instance.savePlayer.level);
        }
    }
    
    */
    public void PlayScene()
    {
        Debug.Log("carregando  cena" + SaveManager.Instance.savePlayer.level);
        StartCoroutine(CarregarCenaAsync(SaveManager.Instance.savePlayer.level));
    }

    public void MenuScene()
    {
        StartCoroutine(CarregarCenaAsync(0));
    }


    IEnumerator  CarregarCenaAsync(int indexDaCena)
    {
        // 1. Ativa a interface de carregamento
        telaLoad.SetActive(true);
        yield return new WaitForSeconds(.5f);
        // 2. Cria a operação de carregamento
        AsyncOperation operacao = SceneManager.LoadSceneAsync(indexDaCena);

        // 3. Enquanto a cena não termina de carregar...
        while (!operacao.isDone)
        {
            // O progresso vai de 0 a 0.9 (o último 0.1 é a ativação da cena)
            // Normalizamos para 0 a 1 para o Slider
            float progresso = Mathf.Clamp01(operacao.progress / 0.9f);

            // Atualiza o valor da barra
            slider.value = progresso;

            // Espera até ao próximo frame antes de continuar o loop
            yield return new WaitForEndOfFrame();
        }
    }

}
