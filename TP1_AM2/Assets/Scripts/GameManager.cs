using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int _enemiesKilled = default, _enemiesToWin = 15;

    [SerializeField] private TextMeshProUGUI _killedEnemiesText;

    void Start() => _killedEnemiesText.text = "Enemigos derrotados: " + _enemiesKilled + "/" + _enemiesToWin;

    void Update()
    {
        _killedEnemiesText.text = "Enemigos derrotados: " + _enemiesKilled + "/" + _enemiesToWin;
        if (_enemiesKilled >= _enemiesToWin)
        {
            SceneManager.LoadScene("Win Screen");
        }
    }

    public void AddKilledEnemy() => _enemiesKilled++;

    public void PlayerDied() => SceneManager.LoadScene("Death Scene");

    public void changeObjective(int enemiesObjective)
    {
        _enemiesToWin = enemiesObjective;
    }
}
