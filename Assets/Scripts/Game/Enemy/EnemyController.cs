using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    private static int _enemyCount = 0;
    [SerializeField]
    private string _nextLevelName;
    [SerializeField]
    private GameObject bombPrefab;

    private void Awake()
    {
        _enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    private void OnDestroy()
    {
        
        DropBomb();
        
        _enemyCount--;
        
        if (_enemyCount <= 0)
        {
            LoadNextLevel();
        }
    }
    
    private void DropBomb()
    {
        if (bombPrefab != null)
        {
            Instantiate(bombPrefab, transform.position, Quaternion.identity);
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