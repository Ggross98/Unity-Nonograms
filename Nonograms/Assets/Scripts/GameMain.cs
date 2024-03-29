﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 游戏主进程
/// </summary>
public class GameMain : MonoBehaviour
{
    public static int DEFAULT_ROW = 5, DEFAULT_COLUMN = 5;

    public int row = DEFAULT_ROW, column = DEFAULT_COLUMN;

    public Grid grid;

    public float rate = 0.5f;

    public static int[,] puzzle00 = {
        { 1, 0, 1, 0, 1 },
        { 1, 1, 0, 0, 1 },
        { 0, 0, 1, 1, 1 },
        { 0, 0, 0, 0, 1 },
        { 1, 0, 1, 1, 1 },};

    public static int[,] puzzle01 = {
        { 0, 0, 1, 0, 1, 1, 0, 1, 0, 1 },
        { 1, 0, 1, 0, 1, 1, 0, 1, 0, 0 },
        { 1, 1, 1, 1, 1, 0, 0, 1, 0, 1 },
        { 1, 0, 0, 0, 1, 1, 0, 1, 0, 0 },
        { 1, 0, 1, 0, 1, 1, 0, 1, 0, 1 },
        { 1, 0, 1, 0, 1, 1, 0, 1, 0, 1 },
        { 1, 0, 1, 0, 1, 0, 0, 1, 0, 1 },
        { 1, 0, 0, 0, 0, 0, 0, 1, 0, 1 },
        { 0, 0, 1, 0, 1, 1, 0, 1, 1, 1 },
        { 0, 0, 1, 0, 1, 1, 0, 1, 1, 1 },


        };

    //public int[,] solution;
    
    //public int[,] 

    void Start()
    {
        if (PlayerPrefs.HasKey("Row"))
            row = PlayerPrefs.GetInt("Row");
        else row = DEFAULT_ROW;

        if (PlayerPrefs.HasKey("Column"))
            column = PlayerPrefs.GetInt("Column");
        else column = DEFAULT_COLUMN;

        int[,] puzzle = CreatePuzzle(row, column);
        
        grid.LoadPuzzle(row,column,puzzle);
        grid.playing = true;
    }

    public int[,] CreatePuzzle(int r, int c)
    {
        //float rate = 0.5f;

        int[,] p = new int[c, r];

        for(int i = 0; i < c; i++)
        {
            for(int j = 0; j < r; j++)
            {
                float flag = Random.Range(0, 1f);
                if (flag < rate) p[i, j] = 1;
                else p[i, j] = 0;
            }
        }

        return p;
    }

}
