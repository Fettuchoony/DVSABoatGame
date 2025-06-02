using UnityEngine;

public class PersistenceManager : MonoBehaviour
{
    
    public static PersistenceManager Instance;

    private void Awake()
    {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

}
