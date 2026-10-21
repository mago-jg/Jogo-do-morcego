using UnityEngine;
using UnityEngine.EventSystems;

public class Tamagotchi : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public enum Estado
    {
        Neutro,
        Feliz,
        Fome,
        Doente,
        Tedio,
        Morto
    }

    [Header("Estado atual")]
    public Estado estadoAtual = Estado.Neutro;

    [Header("Tempos")]
    public float tempoParaDoente = 5f;
    public float tempoParaTedio = 7f;
    public float tempoParaMorrer = 10f;

    private float contadorEstado = 0f;

    private SpriteRenderer sr;
    private Color corPadrao;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        corPadrao = sr.color;

        AtualizaCor();
    }

    void Update()
    {
        contadorEstado += Time.deltaTime;

        // Se estiver com fome por 5 segundos, fica doente
        if (estadoAtual == Estado.Fome &&
            contadorEstado >= tempoParaDoente)
        {
            MudarEstado(Estado.Doente);
        }

        // Se ficar neutro/parado por 7 segundos, fica entediado
        if (estadoAtual == Estado.Neutro &&
            contadorEstado >= tempoParaTedio)
        {
            MudarEstado(Estado.Tedio);
        }

        // Se ficar doente por 10 segundos, morre
        if (estadoAtual == Estado.Doente &&
            contadorEstado >= tempoParaMorrer)
        {
            MudarEstado(Estado.Morto);
        }
    }

    void OnMouseDown()
    {
        // Clique no bichinho

        if (estadoAtual == Estado.Morto)
        {
            Debug.Log("O bichinho morreu!");
            return;
        }

        if (estadoAtual == Estado.Fome)
        {
            // Clique vermelho = alimentar
            MudarEstado(Estado.Feliz);
            Debug.Log("Você alimentou o bichinho!");
        }
        else if (estadoAtual == Estado.Doente)
        {
            // Clique quando doente = curar
            MudarEstado(Estado.Feliz);
            Debug.Log("Você curou o bichinho!");
        }
        else
        {
            // Clique normal = feliz
            MudarEstado(Estado.Feliz);
        }
    }

    void MudarEstado(Estado novoEstado)
    {
        estadoAtual = novoEstado;
        contadorEstado = 0f;

        AtualizaCor();

        Debug.Log("Estado atual: " + estadoAtual);
    }

    void AtualizaCor()
    {
        switch (estadoAtual)
        {
            case Estado.Neutro:
                sr.color = corPadrao;
                break;

            case Estado.Feliz:
                sr.color = Color.yellow;
                break;

            case Estado.Fome:
                sr.color = Color.red;
                break;

            case Estado.Doente:
                sr.color = Color.green;
                break;

            case Estado.Tedio:
                sr.color = new Color(0.5f, 0.5f, 0.5f);
                break;

            case Estado.Morto:
                sr.color = Color.white;
                break;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse entrou no bichinho");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Mouse saiu do bichinho");
    }
}