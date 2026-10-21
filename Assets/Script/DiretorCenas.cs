using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DiretorCenas : MonoBehaviour
{
    public static DiretorCenas Instance;

    private void Awake()
    {
        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public void Comecar()
    {
        Debug.Log("Objeto clicado! Trocando de cena...");

        SceneManager.LoadScene("MainGame");
    }

   public void SairDoJogo()
{
    // Se estiver rodando dentro do Unity (Editor), ele para o Play
    #if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
    #else
    // Se for o jogo final compilado (Build), ele fecha o aplicativo normal
    Application.Quit();
    #endif
}
}

