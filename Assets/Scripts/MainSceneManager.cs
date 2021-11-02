using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainSceneManager : MonoBehaviour
{
    private int score = 0;

    public GameObject item;
    public GameObject enemy;
    public Text scoreText;
    public Text timeText;

    void Start()
    {
        StartCoroutine(MakeItem());
        StartCoroutine(MakeEnemy());
        StartCoroutine(TimeShow());
        StartCoroutine(TimeStop(2.0f));
    }

    public void addScore(int addval = 1)
    {
        score += addval;
        scoreText.text = "Score:" + score.ToString("D2");
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        StartCoroutine(GameOver2());
    }

    private IEnumerator MakeItem()
    {
        while (true)
        {
            Vector3 randomPos = new Vector3(Random.Range(-6.5f, 6.5f), 1, Random.Range(-3.5f, 3.5f));
            Instantiate(item, randomPos, Quaternion.identity);
            yield return new WaitForSeconds(1.5f);
        }
    }

    private IEnumerator MakeEnemy()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject tmpEnemy = Instantiate(enemy, Vector3.zero, Quaternion.identity);
            tmpEnemy.transform.Rotate(Vector3.up * Random.Range(0, 4) * 90);
            yield return new WaitForSeconds(5.0f - i * 0.5f);
        }
        for(int i = 0; i < 8; i++)
        {
            GameObject tmpEnemy = Instantiate(enemy, Vector3.zero, Quaternion.identity);
            tmpEnemy.transform.Rotate(Vector3.up * Random.Range(0, 4) * 90);
            yield return new WaitForSeconds(3.0f - i * 0.25f);
        }
        while (true)
        {
            GameObject tmpEnemy = Instantiate(enemy, Vector3.zero, Quaternion.identity);
            tmpEnemy.transform.Rotate(Vector3.up * Random.Range(0, 4) * 90);
            yield return new WaitForSeconds(1.0f);
        }
    }

    private IEnumerator GameOver2()
    {
        yield return new WaitForSecondsRealtime(2.0f);
        Time.timeScale = 1;
        SceneManager.LoadScene("GameoverScene");
    }

    private IEnumerator TimeStop(float time)
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(time);
        Time.timeScale = 1;
    }

    private IEnumerator TimeShow()
    {
        int timeleft = 0;
        timeText.text = "Time:" + timeleft;
        while (true)
        {
            timeText.text = "Time:" + timeleft++;
            yield return new WaitForSeconds(1);
        }
    }
}
