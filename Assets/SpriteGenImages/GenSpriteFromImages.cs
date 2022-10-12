using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GenSpriteFromImages : MonoBehaviour
{
    //800x600, đọc mặc định 100 pixel = 1 unit (x = 1) nên sẽ chiếm 8x6 ô trong unity
    ScrollingMap map;
    public string sourceImg;

    // Use this for initialization
    void Start()
    {
        map = new ScrollingMap(sourceImg, 3, 5, 0, 0, 800, 600);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public class ScrollingMap
    {
        GameObject[,] MapFragments;
        int nRows;
        int nCols;
        int Left;
        int Top;
        int FragmentWidth;
        int FragmentHeight;
        public ScrollingMap(string strResourceName, int nRows, int nCols, int Left, int Top, int FragmentWidth, int FragmentHeight)
        {
            // TODO: Complete member initialization
            this.nRows = nRows;
            this.nCols = nCols;
            this.Left = Left;
            this.Top = Top;
            this.FragmentHeight = FragmentHeight;
            this.FragmentWidth = FragmentWidth;
            CreateAllMapFragments(strResourceName, nRows, nCols, Left, Top, FragmentWidth, FragmentHeight);
        }

        private void CreateAllMapFragments(string strResourceName, int nRows, int nCols, int Left, int Top, int FragmentWidth, int FragmentHeight)
        {
            MapFragments = new GameObject[nRows, nCols]; // phải tạo game object cho mỗi 1 mảnh
            for (int r = 0; r < nRows; r++)
                for (int c = 0; c < nCols; c++)
                {
                    string MapPiece = strResourceName + r.ToString("00") + "_" + c.ToString("00");
                    MapFragments[r, c] = new GameObject(MapPiece);
                    Sprite temp = Resources.Load<Sprite>(MapPiece);
                    MapFragments[r, c].transform.gameObject.AddComponent<SpriteRenderer>();
                    MapFragments[r, c].GetComponent<SpriteRenderer>().sprite = temp;
                    Vector2 newPos = MapFragments[r, c].transform.position;
                    newPos.x = (float)(Left + c * (FragmentWidth / 100)); // 100 pixel = 1 unit trong Unity
                    newPos.y = -(float)(Top + r * (FragmentHeight / 100)); // 100 pixel = 1 unit trong Unity
                    MapFragments[r, c].transform.position = newPos;
                }
        }
    }
}
