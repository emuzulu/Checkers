using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkerboard : MonoBehaviour
{
    public Piece[,] pieces = new Piece[8, 8];
    public GameObject whitePiecePrefab;
    public GameObject blackPiecePrefab;
    public Vector3 boardOffset = new Vector3(-4.0f, 0, -4.0f);
    public Vector3 pOffset = new Vector3(0.5f, 0, 0.5f);
    private void Start()
    {
        MakeBoard();
    }
    private void MakeBoard() {
        for (int y = 0; y < 3; y++) {
            bool isOdd = ((y % 2) == 0);
            for (int x = 0; x < 8; x += 2) {
                if (isOdd)
                {
                    MakePiece(x, y);
                }
                else {
                    MakePiece(x + 1, y);
                }
            }
        }
        for (int y = 7; y > 4; y--)
        {
            bool isOdd = ((y % 2) == 0);
            for (int x = 0; x < 8; x += 2)
            {
                if (isOdd)
                {
                    MakePiece(x, y);
                }
                else
                {
                    MakePiece(x + 1, y);
                }
            }
        }
    }

    private void MakePiece(int x, int y) {
        bool isPWhite = (y > 3) ? false : true;
        GameObject gameObject = Instantiate((isPWhite)?whitePiecePrefab:blackPiecePrefab) as GameObject;
        gameObject.transform.SetParent(transform);
        Piece p = gameObject.GetComponent<Piece>();
        pieces[x, y] = p;
        MovePiece(p, x, y);
    }
    private void MovePiece(Piece p, int x, int y) {
        p.transform.position = (Vector3.right * x) + (Vector3.forward * y) + boardOffset + pOffset;
    }
}
