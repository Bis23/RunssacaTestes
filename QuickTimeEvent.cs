using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class QuickTimeEvent : MonoBehaviour
{
    public float timeLimit = 2.0f;
    private float timer;
    private bool eventActive = false;

    private KeyCode[] possibleKeys = { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D };
    private KeyCode currentKey;

    public TextMeshProUGUI promptText;
    public Transform playerTransform;
    public float moveDistance = 10.0f;

    public float limiteFinalX = -100f; // Ajuste com base no fim da câmera

    void Start()
    {
        playerTransform.position = new Vector3(-339f, -83f, -9.9726f);
        StartQTE();
    }

    void Update()
    {
        if (!eventActive)
            return;

        timer -= Time.deltaTime;

        if (Input.GetKeyDown(currentKey))
        {
            Success();
        }
        else if (timer <= 0)
        {
            Fail();
        }
    }

    void StartQTE()
    {
        if (playerTransform.position.x >= limiteFinalX)
        {
            promptText.text = "Fim! Você completou o evento!";
            eventActive = false;
            return;
        }

        currentKey = possibleKeys[Random.Range(0, possibleKeys.Length)];
        timer = timeLimit;
        eventActive = true;

        promptText.text = "Pressione: " + currentKey.ToString();
    }

    void Success()
    {
        eventActive = false;
        promptText.text = "";

        Vector3 novaPosicao = playerTransform.position + new Vector3(moveDistance, 0f, 0f);

        if (novaPosicao.x >= limiteFinalX)
        {
            playerTransform.position = new Vector3(limiteFinalX, playerTransform.position.y, playerTransform.position.z);
            promptText.text = "Fim! Você completou o evento!";
        }
        else
        {
            playerTransform.position = novaPosicao;
            Invoke(nameof(StartQTE), 0.5f);
        }
    }

    void Fail()
    {
        eventActive = false;
        promptText.text = "Você caiu e não chegara em casa!";
        Debug.Log("Você caiu e não chegara em casa!");
        Invoke(nameof(FecharJogo), 5f);
    }

    void FecharJogo()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
