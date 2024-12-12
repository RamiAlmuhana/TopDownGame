using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    private static int _enemyCount = 0;
    [SerializeField] private string _nextLevelName;

    private void Awake()
    {
        _enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    private void OnDestroy()
    {
        _enemyCount--;
        
        if (_enemyCount <= 0)
        {
            LoadNextLevel();
        }
    }

    private void LoadNextLevel()
    {
        if (!string.IsNullOrEmpty(_nextLevelName))
        {
            SceneManager.LoadScene(_nextLevelName);
        }
        else
        {
            Debug.LogError("Geen volgende level ingesteld!");
        }
    }
}