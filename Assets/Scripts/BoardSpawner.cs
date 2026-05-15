using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Splines;

public class BoardSpawner : MonoBehaviour
{
    public GameObject boardPrefab;
    public SubmitManager submitManager;

    public GameObject board;
    public BoardData[] boards;
    public SplineContainer spline;
    public Inputs input;
    public Canvas canvas;

    public bool stopped;
    public bool resumed;

    int index = 0;
    bool boardWasActive = false;
    bool isReadyToResume = false;

    private void Update()
    {
        if (board != null)
            boardWasActive = true;

        if (boardWasActive && board == null)
        {
            boardWasActive = false;
            if (index >= boards.Length)
            {
                PlayerPrefs.SetInt("FinalScore", submitManager.correctCount);
                SceneManager.LoadScene("WinScreen");
            }
            else
                SpawnNext();
        }
    }

    public void SpawnNext()
    {
        if (index >= boards.Length || board != null)
            return;

        board = Instantiate(boardPrefab, canvas.transform, false);

        BoardFollowSpline bfs = board.GetComponent<BoardFollowSpline>();
        bfs.spline = spline;
        bfs.input = input;

        Vector3 startPos = spline.EvaluatePosition(0f);
        board.transform.position = new Vector3(startPos.x, startPos.y, 0f);

        PromptSpawner spawner = board.GetComponent<PromptSpawner>();
        spawner.submitManager = submitManager;
        spawner.SpawnPrompt(boards[index]);

        index++;
    }

    public void AllowResume()
    {
        isReadyToResume = true;
    }

    public void resumeBoard()
    {
        if (!isReadyToResume || board == null) return;
        BoardFollowSpline bfs = board.GetComponent<BoardFollowSpline>();
        if (!bfs.stopped) return;
        isReadyToResume = false;
        bfs.stopped = false;
        bfs.resumed = true;
    }

    public bool IsBoardStopped()
    {
        if (board == null) return false;
        return board.GetComponent<BoardFollowSpline>().stopped;
    }

    void Start()
    {
        submitManager.boardSpawner = this;
        SpawnNext();
    }
}
