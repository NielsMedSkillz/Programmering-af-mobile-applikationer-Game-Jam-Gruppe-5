using UnityEngine;
using UnityEngine.Splines;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class BoardSpawner : MonoBehaviour
{
    public GameObject boardPrefab;
    public SubmitManager submitManager;

    public GameObject board;
    public BoardData[] boards;
    public SplineContainer spline;
    public Inputs input;
    public Canvas canvas;

    public TextMeshProUGUI visualTimer;

    public bool stopped;
    public bool resumed;

    public bool decreaseTime = false;

    public float questionTime;

    int index = 0;

    void Start()
    {
        SpawnNext();
    }
    private void Update()
    {
        if (input.complete.triggered)
            SpawnNext();
        if (decreaseTime == true)
        {
            questionTime -= Time.deltaTime;
        }
        visualTimer.text = questionTime.ToString("0");
        if (questionTime <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        if (questionTime <= 5)
        {
            visualTimer.color = Color.red;
        } 
    }

    public void SpawnNext()
    {
        if (index >= boards.Length || board != null)
            return;

        questionTime = 15f;
        visualTimer.color = Color.white;

        decreaseTime = true;

        board = Instantiate(boardPrefab, canvas.transform, false);

        board.GetComponent<BoardFollowSpline>().spline = spline;
        board.GetComponent<BoardFollowSpline>().input = input;

        PromptSpawner spawner = board.GetComponent<PromptSpawner>();
        spawner.submitManager = submitManager;
        spawner.SpawnPrompt(boards[index]);

        index++;
    }
    
    public void resumeBoard()
    {
        board.GetComponent<BoardFollowSpline>().stopped = false;
        board.GetComponent<BoardFollowSpline>().resumed = true;
    }


}