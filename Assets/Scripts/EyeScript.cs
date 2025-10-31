using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;

public class EyeScript : MonoBehaviour
{

    public int Points = 0;
    public float AwkwardPoints = 0f;
    public TMP_Text PointText;
    public TMP_Text AwkwardPointText;
    public TMP_Text EndText;
    bool Warning = false;
    bool GameOver = false;

    public GameObject ArtEye1;
    public GameObject ArtEye2;
    public GameObject End;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(StartGame(5f));
    }

    // Update is called once per frame
    void Update()
    {
        if (AwkwardPoints >= 100) { GameOver = true; End.SetActive(true); EndText.text = "It got awkward (you lose)"; Application.Quit(); }
        if (Points >= 1000) { GameOver = true; End.SetActive(true); Application.Quit(); }
    }

    void OnTriggerStay2D(Collider2D detect)
    {
        if (!GameOver)
        {
            if (detect.gameObject.CompareTag("Hitbox"))
            {
                if (Warning == false)
                {
                    Points += 1;
                    PointText.text = "Points: " + Points;
                }
                else if (Warning == true)
                {
                    AwkwardPoints += 1;
                    AwkwardPointText.text = "Awkward Meter: " + AwkwardPoints;
                }
            }
        }
    }

    private IEnumerator ArtGuy(float WaitTime)
    {
        Warning = true;
        Debug.Log("He is staring");
        float RandomTime = Random.Range(3f, 8f);
        ArtEye1.transform.localPosition = new Vector3(-6.26f, 1.7f, -1f);
        ArtEye2.transform.localPosition = new Vector3(-4.52f, 1.7f, -1f);
        yield return new WaitForSeconds(WaitTime);
        Debug.Log("He isnt staring anymore");
        Warning = false;
        ArtEye1.transform.localPosition = new Vector3(-5.9312f, 1.3749f, -1f);
        ArtEye2.transform.localPosition = new Vector3(-4.31f, 1.3749f, -1f);

        yield return new WaitForSeconds(RandomTime);
        StartCoroutine(ArtGuy(3f));
    }

    private IEnumerator StartGame(float WaitTime)
    {
        Debug.Log("StartingGame");
        yield return new WaitForSeconds(WaitTime);
        StartCoroutine(ArtGuy(5f));
    }

    
}