using UnityEngine;
using UnityEngine.EventSystems;

public class Lista : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private SpriteRenderer sr;
    private Color colorpadrao;

    // Listas de textos simples
    public string[] nomes;
    public string[] estados;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            colorpadrao = sr.color;
        }

        // Criando a lista de nomes dos estados em texto
        nomes = new string[] { "Entediado", "Faminto", "Doente", "Feliz" };

        // Agora a lista de estados ativos também usa textos simples!
        estados = new string[] { "Fome", "Feliz" };

        // Sorteia um estado aleatório da nossa lista de nomes
        int indiceAleatorio = Random.Range(0, nomes.Length);
        string estadoAtual = nomes[indiceAleatorio];

        Debug.Log($"O Bicho está: {estadoAtual}");
    }

    // Quando o mouse passa por cima do objeto
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerEnter != null)
        {
            Debug.Log($"Mouse entrou em: {eventData.pointerEnter.name}");
        }

        if (sr != null)
        {
            sr.color = Color.red; // Muda para vermelho
        }
    }

    // Quando o mouse sai de cima do objeto
    public void OnPointerExit(PointerEventData eventData)
    {
        if (sr != null)
        {
            sr.color = colorpadrao; // Volta para a cor original
        }
    }
}
