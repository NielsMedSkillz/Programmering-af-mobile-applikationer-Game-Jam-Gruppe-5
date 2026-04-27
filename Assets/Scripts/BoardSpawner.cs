using UnityEngine;
using UnityEngine.Splines;

public class BoardSpawner : MonoBehaviour
{
    public GameObject boardPrefab;
    public BoardData[] boards;
    public SplineContainer spline;
    public Inputs input;

    int index = 0;

    private void Update()
    {
        if (input.complete.triggered)
            SpawnNext();
    }

    public void SpawnNext()
    {
        if (index >= boards.Length) return;

        GameObject board = Instantiate(boardPrefab, new Vector2(-10.7f, 6.3f), Quaternion.identity);

        board.GetComponent<BoardFollowSpline>().spline = spline;
        board.GetComponent<BoardFollowSpline>().input = input;

        board.GetComponentInChildren<BoardDisplay>().Setup(boards[index]);

        index++;
    }

    void Start()
    {
        SpawnNext();
    }
}