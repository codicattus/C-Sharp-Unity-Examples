using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 1. Propiedad estática con getter público y setter privado
    public static GameManager Instance { get; private set; }

    [SerializeField] private int playerScore = 0;

    private void Awake()
    {
        // 2. Lógica de control para asegurar la unicidad
        if (Instance != null && Instance != this)
        {
            // Si ya existe otra instancia en escena, destruimos esta copia
            Destroy(gameObject);
            return;
        }

        // 3. Asignar la instancia principal
        Instance = this;

        // Opcional: Mantener el objeto vivo al cambiar de escena
        DontDestroyOnLoad(gameObject);
    }

    private void OnDestroy()
    {
        // 4. Limpieza de la referencia estática
        if (Instance == this)
        {
            Instance = null;
        }
    }

    // Método de ejemplo expuesto de forma global
    public void AddScore(int amount)
    {
        playerScore += amount;
        Debug.Log($"Puntuación actual: {playerScore}");
    }
}
