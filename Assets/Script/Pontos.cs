using UnityEngine;
using UnityEngine.EventSystems;
// 1. OBRIGATÓRIO: Adicione essa linha para o script reconhecer o TextMeshPro
using TMPro;

public class Pontos : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private SpriteRenderer sr;
    private Color colorpadrao;

    public string[] nomes;
    public string[] estados;
    public int pontos = 0;

    // 2. CAMPO DO TEXTO: Aqui vamos arrastar o texto da tela lá no Inspector
    public TextMeshProUGUI textoPontos;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        if (sr != null) colorpadrao = sr.color;

        nomes = new string[] { "Entediado", "Faminto", "Doente", "Feliz" };
        estados = new string[] { "Fome", "Feliz" };

        // Atualiza o texto logo no começo do jogo para garantir que comece em 0
        AtualizarTextoDePontos();
    }

    public void GanhaPontos()
    {
        pontos = pontos + 10;
        Debug.Log($"O morcego brincou! Pontos atuais: {pontos}");

        // 3. ATUALIZA A TELA: Toda vez que ganha pontos, o texto da tela muda!
        AtualizarTextoDePontos();
    }

    // Função simples para atualizar o que está escrito na tela
    void AtualizarTextoDePontos()
    {
        if (textoPontos != null)
        {
            textoPontos.text = "Pontos: " + pontos;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (sr != null) sr.color = Color.red;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (sr != null) sr.color = colorpadrao;
    }
}
