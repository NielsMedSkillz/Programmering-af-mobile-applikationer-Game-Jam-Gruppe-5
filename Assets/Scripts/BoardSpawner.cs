using UnityEngine;
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

    int index = 0;

    private void Update()
    {
        if (input.complete.triggered)
            SpawnNext();
    }

    public void SpawnNext()
    {
        if (index >= boards.Length || board != null)
            return;

        board = Instantiate(boardPrefab, canvas.transform, false);

        board.GetComponent<BoardFollowSpline>().spline = spline;
        board.GetComponent<BoardFollowSpline>().input = input;

        PromptSpawner spawner = board.GetComponent<PromptSpawner>();
        spawner.submitManager = submitManager;

        spawner.SpawnPrompt(boards[index]);

        index++;
    }

    void Start()
    {
        SpawnNext();
    }
}