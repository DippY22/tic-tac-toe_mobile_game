using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    // [SerializeField]
    // private float moveSpeed = 0.01f;
    // private MoveState moveState = MoveState.Idle;
    private (float x, float y) fieldCellSize;
    private (float x, float y) edgeCellsCoordinates;

    [SerializeField]
    private GameFieldManager gfm;

    public void MoveHero(Vector2 direction)
    {
        var destinationPoint = new Vector2(transform.position.x + direction.x * fieldCellSize.x, transform.position.y + direction.y * fieldCellSize.y);
        if(Mathf.Abs(destinationPoint.x) <= Mathf.Abs(edgeCellsCoordinates.x) && Mathf.Abs(destinationPoint.y) <= Mathf.Abs(edgeCellsCoordinates.y))
            transform.position = destinationPoint;
    }

    private void OnSwipe(Vector2 direction)
    {
        MoveHero(direction);
    }

    void Start()
    {
        SwipeDetection.SwipeEvent += OnSwipe;
        fieldCellSize = gfm.GetFieldCellSize();
        edgeCellsCoordinates = gfm.GetEdgeCellsCoords();
    }
}
