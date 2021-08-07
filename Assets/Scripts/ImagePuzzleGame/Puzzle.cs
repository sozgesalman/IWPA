using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    public ImageBox boxPrefab;

    public ImageBox[,] boxes = new ImageBox[4, 4];

    public Sprite[] sprites;
    
    void Start()
    {
        Init();
        for(int i = 0; i < 999; i++)
            Shuffle();
        
        
    }

    void Init()
    {
        int n = 0;
        for (int y = 3; y >= 0; y--)
            for (int x = 0; x < 4; x++)
            {
                ImageBox box = Instantiate(boxPrefab, new Vector2(x, y), Quaternion.identity);
                box.Init(x, y, n + 1, sprites[n], ClickToSwap);
                boxes[x, y] = box;
                n++;
            }
    }

    void ClickToSwap(int x, int y)
    {
        int dx = getDx(x, y);
        int dy = getDy(x, y);
        Swap(x, y, dx, dy);
    }
    void Swap(int x, int y, int dx, int dy)
    {
        
        var from = boxes[x, y];
        var target = boxes[x + dx, y + dy];

        //swap this 2 boxes
        boxes[x, y] = target;
        boxes[x + dx, y + dy] = from;

        //Update boxes position
        from.UpdatePosition(x + dx, y + dy);
        target.UpdatePosition(x, y);

    }

    int getDx(int x, int y)
    {
        if (x < 3 && boxes[x + 1, y].IsEmpty())
            return 1;
        if (x > 0 && boxes[x - 1, y].IsEmpty())
            return -1;
        return 0;
    }
    int getDy(int x, int y)
    {
        if (y < 3 && boxes[x, y+1].IsEmpty())
            return 1;
        if (y > 0 && boxes[x, y-1].IsEmpty())
            return -1;
        return 0;
    }

    void Shuffle()
    {
        for(int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (boxes[i, j].IsEmpty())
                {
                    Vector2 position = GetValidMove(i, j);
                    Swap(i, j, (int)position.x, (int)position.y);
                }
            }
        }
    }

    private Vector2 lastMove;
    Vector2 GetValidMove(int x, int y)
    {
        Vector2 position = new Vector2();

        do
        {
            int n = Random.Range(0, 4);
            if (n == 0)
            {
                position = Vector2.left;
            }
            else if (n == 1)
            {
                position = Vector2.right;
            }
            else if (n == 2)
            {
                position = Vector2.up;
            }
            else
            {
                position = Vector2.down;
            }
        } while (!(isValidRange(x + (int)position.x) && isValidRange(y + (int)position.y)) || isRepeatMove(position));

        lastMove = position;
        return position;
    }

    bool isValidRange(int n)
    {
        return n >= 0 && n <= 3;
    }
    bool isRepeatMove(Vector2 position)
    {

        return position * -1 == lastMove;
    }
    
}
