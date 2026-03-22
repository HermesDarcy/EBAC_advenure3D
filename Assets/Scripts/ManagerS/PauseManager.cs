using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject painelGame, painelPause;
    private bool jogoPausado = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (jogoPausado)
                Continuar();
            else
                Pausar();
        }
    }



    public void OnOffPause()
    {
        if (jogoPausado)
            Continuar();
        else
            Pausar();
    }

    public void Pausar()
    {
        painelGame.SetActive(false);
        painelPause.SetActive(true);
        Time.timeScale = 0f;         // Congela o mundo físico e animações
        jogoPausado = true;

        // Opcional: Liberar o mouse para interagir com o menu
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Continuar()
    {
        painelGame.SetActive(true);
        painelPause.SetActive(false);
        Time.timeScale = 1f;          // Retoma o tempo normal
        jogoPausado = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void toMainMenu()
    {
        
        ManagerScene.Instance.MenuScene();
    }
}


