
using System.Collections;
using System.Collections.Generic;
//using System.Drawing;
using UnityEngine;

public class ColorSequences : MonoBehaviour
{

    public Color[][][] colorSequences;
    public int[][] colorSequenceOrders; 

    void Awake()
    {
        // color Sequences
        colorSequences = new Color[28][][];

        colorSequences[0] = new Color[10][];
        colorSequences[0][0] = new Color[] { Color.yellow, Color.green, Color.green, Color.blue, Color.magenta, Color.grey, Color.black, Color.white, new Color(1f, 0.65f, 0f), new Color(0.5f, 0f, 0.5f) };
        colorSequences[0][1] = new Color[] { new Color(1f, 0.65f, 0f), Color.red, Color.grey, Color.blue, Color.magenta, Color.green, Color.black, Color.white, Color.yellow, new Color(0.5f, 0f, 0.5f) };
        colorSequences[0][2] = new Color[] { Color.white, Color.yellow, Color.blue, Color.red, Color.green, Color.grey, Color.magenta, new Color(1f, 0.65f, 0f), Color.black, new Color(0.5f, 0f, 0.5f) };
        colorSequences[0][3] = new Color[] { Color.green, Color.magenta, Color.blue, Color.red, Color.yellow, Color.grey, Color.black, Color.white, new Color(1f, 0.65f, 0f), new Color(0.5f, 0f, 0.5f) };
            colorSequences[0][4] = new Color[] { Color.red, Color.red, Color.blue, Color.green, Color.red, Color.magenta, Color.grey, Color.black, Color.white, Color.red };
        colorSequences[0][5] = new Color[] { Color.blue, Color.yellow, Color.green, Color.magenta, Color.grey, Color.red, new Color(1f, 0.65f, 0f), Color.white, Color.black, new Color(1f, 0.65f, 0f) };
        colorSequences[0][6] = new Color[] { Color.magenta, Color.black, new Color(1f, 0.65f, 0f), Color.yellow, Color.green, Color.blue, Color.red, Color.white, Color.grey, new Color(0.5f, 0f, 0.5f) };
        colorSequences[0][7] = new Color[] { Color.grey, Color.blue, Color.yellow, Color.green, new Color(1f, 0.65f, 0f), Color.red, Color.magenta, Color.white, new Color(1f, 0.65f, 0f), Color.black };
        colorSequences[0][8] = new Color[] { new Color(1f, 0.65f, 0f), Color.green, Color.yellow, Color.red, Color.blue, Color.magenta, Color.black, Color.white, Color.grey, new Color(0.5f, 0f, 0.5f) };
        colorSequences[0][9] = new Color[] { Color.white, Color.red, Color.blue, Color.green, Color.magenta, Color.yellow, Color.grey, Color.black, new Color(1f, 0.65f, 0f), new Color(1f, 0.65f, 0f) };

        colorSequences[1] = new Color[10][];
            colorSequences[1][0] = new Color[] { Color.yellow, Color.green, Color.red, Color.red, Color.red, Color.red, Color.blue, Color.magenta, Color.grey, Color.black };
        colorSequences[1][1] = new Color[] { Color.blue, Color.magenta, Color.grey, Color.black, Color.white, new Color(1f, 0.65f, 0f), Color.green, new Color(0.5f, 0f, 0.5f), Color.yellow, Color.red };
        colorSequences[1][2] = new Color[] { Color.green, Color.magenta, new Color(1f, 0.65f, 0f), Color.blue, Color.white, Color.black, Color.blue, Color.black, Color.red, Color.grey };
        colorSequences[1][3] = new Color[] { Color.white, Color.yellow, Color.blue, Color.green, Color.grey, Color.magenta, new Color(1f, 0.65f, 0f), Color.black, new Color(0.5f, 0f, 0.5f), Color.red };
        colorSequences[1][4] = new Color[] { Color.magenta, Color.black, Color.green, Color.blue, Color.red, Color.white, Color.grey, new Color(1f, 0.65f, 0f), new Color(0.5f, 0f, 0.5f), Color.yellow };
        colorSequences[1][5] = new Color[] { Color.green, Color.blue, Color.yellow, Color.red, Color.magenta, Color.grey, Color.black, Color.white, Color.red, new Color(1f, 0.65f, 0f) };
        colorSequences[1][6] = new Color[] { Color.grey, Color.red, Color.magenta, Color.green, Color.red, Color.red, Color.yellow, Color.white, Color.black, new Color(1f, 0.65f, 0f) };
        colorSequences[1][7] = new Color[] { Color.black, Color.white, Color.red, new Color(0.5f, 0f, 0.5f), Color.magenta, Color.blue, Color.green, Color.red, Color.grey, Color.yellow };
        colorSequences[1][8] = new Color[] { Color.blue, new Color(1f, 0.65f, 0f), Color.red, Color.green, Color.magenta, Color.grey, Color.yellow, Color.black, Color.red, new Color(0.5f, 0f, 0.5f) };
        colorSequences[1][9] = new Color[] { new Color(1f, 0.65f, 0f), Color.green, Color.red, Color.blue, Color.red, Color.magenta, Color.black, Color.grey, Color.yellow, new Color(0.5f, 0f, 0.5f) };

        colorSequences[2] = new Color[10][];
        colorSequences[2][0] = new Color[] { Color.green, Color.red, Color.blue, Color.red, Color.magenta, Color.grey, Color.yellow, Color.black, Color.white, new Color(1f, 0.65f, 0f) };
        colorSequences[2][1] = new Color[] { Color.yellow, Color.red, Color.magenta, Color.green, Color.red, Color.blue, Color.black, Color.grey, Color.white, new Color(0.5f, 0f, 0.5f) };
        colorSequences[2][2] = new Color[] { Color.magenta, Color.blue, Color.red, Color.red, Color.yellow, Color.black, new Color(1f, 0.65f, 0f), Color.green, Color.grey, Color.red };
        colorSequences[2][3] = new Color[] { new Color(0.5f, 0f, 0.5f), Color.green, Color.red, Color.blue, Color.red, Color.magenta, Color.black, Color.white, Color.grey, Color.yellow };
        colorSequences[2][4] = new Color[] { Color.black, Color.blue, Color.blue, Color.green, Color.white, Color.magenta, Color.grey, Color.black, Color.white, Color.green };
        colorSequences[2][5] = new Color[] { Color.blue, Color.yellow, Color.green, Color.magenta, Color.grey, Color.red, new Color(1f, 0.65f, 0f), Color.white, Color.black, new Color(1f, 0.65f, 0f) };
        colorSequences[2][6] = new Color[] { Color.magenta, Color.black, new Color(1f, 0.65f, 0f), Color.yellow, Color.green, Color.blue, Color.red, Color.white, Color.grey, new Color(0.5f, 0f, 0.5f) };
        colorSequences[2][7] = new Color[] { Color.grey, Color.blue, Color.yellow, Color.green, new Color(1f, 0.65f, 0f), Color.red, Color.magenta, Color.white, new Color(1f, 0.65f, 0f), Color.black };
        colorSequences[2][8] = new Color[] { new Color(1f, 0.65f, 0f), Color.green, Color.yellow, Color.red, Color.blue, Color.magenta, Color.black, Color.white, Color.grey, new Color(0.5f, 0f, 0.5f) };
            colorSequences[2][9] = new Color[] { Color.white, Color.red, Color.blue, Color.green, Color.red, Color.yellow, Color.red, Color.red, new Color(1f, 0.65f, 0f), new Color(1f, 0.65f, 0f) };

        colorSequences[3] = new Color[10][];
        colorSequences[3][0] = new Color[] { Color.magenta, Color.red, Color.green, Color.blue, Color.yellow, Color.grey, Color.black, Color.white, new Color(1f, 0.65f, 0f), new Color(0.5f, 0f, 0.5f) };
        colorSequences[3][1] = new Color[] { new Color(1f, 0.65f, 0f), Color.red, Color.grey, Color.blue, Color.magenta, Color.green, Color.red, Color.black, Color.white, Color.red };
        colorSequences[3][2] = new Color[] { Color.yellow, Color.red, Color.blue, Color.red, Color.red, Color.green, Color.grey, Color.magenta, new Color(1f, 0.65f, 0f), Color.black };
        colorSequences[3][3] = new Color[] { Color.green, Color.yellow, new Color(1f, 0.65f, 0f), Color.red, Color.white, Color.magenta, Color.grey, Color.yellow, Color.black, Color.white };
        colorSequences[3][4] = new Color[] { Color.magenta, Color.black, Color.green, Color.blue, Color.black, Color.white, Color.grey, new Color(1f, 0.65f, 0f), new Color(0.5f, 0f, 0.5f), Color.yellow };
            colorSequences[3][5] = new Color[] { Color.red, Color.blue, Color.red, Color.red, Color.magenta, Color.grey, Color.black, Color.white, Color.red, new Color(1f, 0.65f, 0f) };
        colorSequences[3][6] = new Color[] { Color.grey, Color.red, Color.magenta, Color.green, Color.red, Color.red, Color.yellow, Color.white, Color.black, new Color(1f, 0.65f, 0f) };
        colorSequences[3][7] = new Color[] { Color.black, Color.white, Color.red, new Color(0.5f, 0f, 0.5f), Color.magenta, Color.blue, Color.green, Color.red, Color.grey, Color.yellow };
        colorSequences[3][8] = new Color[] { Color.blue, new Color(1f, 0.65f, 0f), Color.red, Color.green, Color.magenta, Color.grey, Color.yellow, Color.black, Color.red, new Color(0.5f, 0f, 0.5f) };
        colorSequences[3][9] = new Color[] { new Color(1f, 0.65f, 0f), Color.green, Color.yellow, Color.blue, Color.red, Color.magenta, Color.black, Color.grey, Color.yellow, new Color(0.5f, 0f, 0.5f) };

        colorSequences[4] = new Color[10][];
        colorSequences[4][0] = new Color[] { Color.red, Color.green, Color.green, Color.blue, Color.magenta, Color.grey, Color.red, Color.white, new Color(1f, 0.65f, 0f), new Color(0.5f, 0f, 0.5f) };
        colorSequences[4][1] = new Color[] { new Color(1f, 0.65f, 0f), Color.red, Color.grey, Color.blue, Color.magenta, Color.green, Color.black, Color.white, Color.red, Color.red };
        colorSequences[4][2] = new Color[] { Color.white, Color.yellow, Color.blue, Color.red, Color.green, Color.grey, Color.red, new Color(1f, 0.65f, 0f), Color.red, new Color(0.5f, 0f, 0.5f) };
        colorSequences[4][3] = new Color[] { Color.green, Color.magenta, Color.blue, Color.red, Color.yellow, Color.grey, Color.black, Color.red, new Color(1f, 0.65f, 0f), new Color(0.5f, 0f, 0.5f) };
        colorSequences[4][4] = new Color[] { Color.magenta, Color.black, Color.green, Color.blue, Color.red, Color.white, Color.grey, new Color(1f, 0.65f, 0f), new Color(0.5f, 0f, 0.5f), Color.yellow };
        colorSequences[4][5] = new Color[] { Color.green, Color.blue, Color.yellow, Color.red, Color.magenta, Color.grey, Color.black, Color.white, Color.red, new Color(1f, 0.65f, 0f) };
            colorSequences[4][6] = new Color[] { Color.grey, Color.red, Color.magenta, Color.green, Color.red, Color.red, Color.yellow, Color.red, Color.black, new Color(1f, 0.65f, 0f) };
        colorSequences[4][7] = new Color[] { Color.black, Color.white, Color.red, new Color(0.5f, 0f, 0.5f), Color.magenta, Color.blue, Color.green, Color.red, Color.grey, Color.yellow };
        colorSequences[4][8] = new Color[] { Color.blue, new Color(1f, 0.65f, 0f), Color.red, Color.green, Color.magenta, Color.grey, Color.yellow, Color.black, Color.red, new Color(0.5f, 0f, 0.5f) };
        colorSequences[4][9] = new Color[] { new Color(1f, 0.65f, 0f), Color.green, Color.red, Color.blue, Color.red, Color.magenta, Color.black, Color.grey, Color.yellow, new Color(0.5f, 0f, 0.5f) };

        colorSequences[5] = new Color[10][];
        colorSequences[5][0] = new Color[] { Color.red, new Color(1f, 0.65f, 0f), Color.yellow, Color.green, Color.blue, Color.red, Color.blue, Color.magenta, Color.grey, Color.black };
        colorSequences[5][1] = new Color[] { Color.blue, Color.magenta, Color.grey, Color.black, Color.white, new Color(1f, 0.65f, 0f), Color.green, new Color(0.5f, 0f, 0.5f), Color.yellow, Color.red };
            colorSequences[5][2] = new Color[] { Color.green, Color.magenta, new Color(1f, 0.65f, 0f), Color.blue, Color.red, Color.black, Color.red, Color.red, Color.red, Color.grey };
        colorSequences[5][3] = new Color[] { Color.white, Color.yellow, Color.blue, Color.green, Color.grey, Color.magenta, new Color(1f, 0.65f, 0f), Color.black, new Color(0.5f, 0f, 0.5f), Color.red };
        colorSequences[5][4] = new Color[] { Color.magenta, Color.black, Color.green, Color.blue, Color.red, Color.white, Color.grey, new Color(1f, 0.65f, 0f), new Color(0.5f, 0f, 0.5f), Color.yellow };
        colorSequences[5][5] = new Color[] { Color.green, Color.blue, Color.yellow, Color.red, Color.magenta, Color.grey, Color.black, Color.white, Color.red, new Color(1f, 0.65f, 0f) };
        colorSequences[5][6] = new Color[] { Color.grey, Color.red, Color.magenta, Color.green, Color.red, Color.red, Color.yellow, Color.white, Color.black, new Color(1f, 0.65f, 0f) };
        colorSequences[5][7] = new Color[] { Color.black, Color.white, Color.red, new Color(0.5f, 0f, 0.5f), Color.magenta, Color.blue, Color.green, Color.red, Color.grey, Color.yellow };
        colorSequences[5][8] = new Color[] { Color.blue, new Color(1f, 0.65f, 0f), Color.red, Color.green, Color.magenta, Color.grey, Color.yellow, Color.black, Color.red, new Color(0.5f, 0f, 0.5f) };
        colorSequences[5][9] = new Color[] { new Color(1f, 0.65f, 0f), Color.green, Color.red, Color.blue, Color.red, Color.magenta, Color.black, Color.grey, Color.yellow, new Color(0.5f, 0f, 0.5f) };

        colorSequences[6] = new Color[10][];
        colorSequences[6][0] = new Color[] { Color.white, Color.black, Color.green, Color.blue, Color.magenta, Color.grey, Color.black, Color.white, new Color(1f, 0.65f, 0f), new Color(0.5f, 0f, 0.5f) };
            colorSequences[6][1] = new Color[] { Color.red, Color.red, Color.blue, Color.green, Color.red, Color.magenta, Color.grey, Color.black, Color.white, Color.red };       
        colorSequences[6][2] = new Color[] { Color.white, Color.yellow, Color.blue, Color.red, Color.green, Color.grey, Color.magenta, new Color(1f, 0.65f, 0f), Color.black, new Color(0.5f, 0f, 0.5f) };
        colorSequences[6][3] = new Color[] { Color.green, Color.magenta, Color.blue, Color.red, Color.yellow, Color.grey, Color.black, Color.white, new Color(1f, 0.65f, 0f), new Color(0.5f, 0f, 0.5f) };
        colorSequences[6][4] = new Color[] { new Color(1f, 0.65f, 0f), Color.red, Color.grey, Color.blue, Color.magenta, Color.green, Color.black, Color.white, Color.yellow, new Color(0.5f, 0f, 0.5f) };
        colorSequences[6][5] = new Color[] { Color.blue, Color.yellow, Color.green, Color.magenta, Color.grey, Color.red, new Color(1f, 0.65f, 0f), Color.white, Color.black, new Color(1f, 0.65f, 0f) };
        colorSequences[6][6] = new Color[] { Color.magenta, Color.black, new Color(1f, 0.65f, 0f), Color.yellow, Color.green, Color.blue, Color.red, Color.white, Color.grey, new Color(0.5f, 0f, 0.5f) };
        colorSequences[6][7] = new Color[] { Color.grey, Color.blue, Color.yellow, Color.green, new Color(1f, 0.65f, 0f), Color.red, Color.magenta, Color.white, new Color(1f, 0.65f, 0f), Color.black };
        colorSequences[6][8] = new Color[] { new Color(1f, 0.65f, 0f), Color.green, Color.yellow, Color.red, Color.blue, Color.magenta, Color.black, Color.white, Color.grey, new Color(0.5f, 0f, 0.5f) };
        colorSequences[6][9] = new Color[] { Color.white, Color.red, Color.blue, Color.green, Color.magenta, Color.yellow, Color.grey, Color.black, new Color(1f, 0.65f, 0f), new Color(1f, 0.65f, 0f) };

        colorSequences[7] = new Color[10][];
        colorSequences[7][0] = new Color[] { Color.blue, Color.green, Color.yellow, Color.red, Color.red, Color.yellow, Color.blue, Color.white, Color.grey, Color.black };
        colorSequences[7][1] = new Color[] { Color.blue, Color.magenta, Color.grey, Color.black, Color.white, new Color(1f, 0.65f, 0f), Color.green, new Color(0.5f, 0f, 0.5f), Color.yellow, Color.red };
        colorSequences[7][2] = new Color[] { Color.white, Color.yellow, Color.blue, Color.green, Color.grey, Color.magenta, new Color(1f, 0.65f, 0f), Color.black, new Color(0.5f, 0f, 0.5f), Color.red };
            colorSequences[7][3] = new Color[] { Color.green, Color.magenta, new Color(1f, 0.65f, 0f), Color.blue, Color.red, Color.black, Color.red, Color.red, Color.red, Color.grey };       
        colorSequences[7][4] = new Color[] { Color.magenta, Color.black, Color.green, Color.blue, Color.red, Color.white, Color.grey, new Color(1f, 0.65f, 0f), new Color(0.5f, 0f, 0.5f), Color.yellow };
        colorSequences[7][5] = new Color[] { Color.green, Color.blue, Color.yellow, Color.red, Color.magenta, Color.grey, Color.black, Color.white, Color.red, new Color(1f, 0.65f, 0f) };
        colorSequences[7][6] = new Color[] { Color.grey, Color.red, Color.magenta, Color.green, Color.white, Color.red, Color.yellow, Color.white, Color.black, new Color(1f, 0.65f, 0f) };
        colorSequences[7][7] = new Color[] { Color.black, Color.white, Color.red, new Color(0.5f, 0f, 0.5f), Color.magenta, Color.blue, Color.green, Color.red, Color.grey, Color.yellow };
        colorSequences[7][8] = new Color[] { Color.blue, new Color(1f, 0.65f, 0f), Color.red, Color.green, Color.magenta, Color.grey, Color.yellow, Color.black, Color.red, new Color(0.5f, 0f, 0.5f) };
        colorSequences[7][9] = new Color[] { new Color(1f, 0.65f, 0f), Color.green, Color.red, Color.blue, Color.red, Color.magenta, Color.black, Color.grey, Color.yellow, new Color(0.5f, 0f, 0.5f) };

        colorSequences[8] = new Color[10][];
        colorSequences[8][0] = new Color[] { Color.yellow, Color.green, Color.green, Color.blue, Color.magenta, Color.grey, Color.black, Color.white, new Color(1f, 0.65f, 0f), new Color(0.5f, 0f, 0.5f) };
        colorSequences[8][1] = new Color[] { new Color(1f, 0.65f, 0f), Color.red, Color.grey, Color.blue, Color.magenta, Color.green, Color.black, Color.white, Color.yellow, new Color(0.5f, 0f, 0.5f) };
        colorSequences[8][2] = new Color[] { Color.white, Color.yellow, Color.blue, Color.red, Color.green, Color.grey, Color.magenta, new Color(1f, 0.65f, 0f), Color.black, new Color(0.5f, 0f, 0.5f) };
        colorSequences[8][3] = new Color[] { Color.green, Color.magenta, Color.blue, Color.red, Color.yellow, Color.grey, Color.black, Color.white, new Color(1f, 0.65f, 0f), new Color(0.5f, 0f, 0.5f) };
        colorSequences[8][4] = new Color[] { Color.grey, Color.blue, Color.yellow, Color.green, new Color(1f, 0.65f, 0f), Color.red, Color.magenta, Color.white, new Color(1f, 0.65f, 0f), Color.black };
        colorSequences[8][5] = new Color[] { Color.blue, Color.yellow, Color.green, Color.magenta, Color.grey, Color.red, new Color(1f, 0.65f, 0f), Color.white, Color.black, new Color(1f, 0.65f, 0f) };
        colorSequences[8][6] = new Color[] { Color.magenta, Color.black, new Color(1f, 0.65f, 0f), Color.yellow, Color.green, Color.blue, Color.red, Color.white, Color.grey, new Color(0.5f, 0f, 0.5f) };
            colorSequences[8][7] = new Color[] { Color.red, Color.red, Color.blue, Color.green, Color.red, Color.magenta, Color.grey, Color.black, Color.white, Color.red };
        colorSequences[8][8] = new Color[] { new Color(1f, 0.65f, 0f), Color.green, Color.yellow, Color.red, Color.blue, Color.magenta, Color.black, Color.white, Color.grey, new Color(0.5f, 0f, 0.5f) };
        colorSequences[8][9] = new Color[] { Color.white, Color.red, Color.blue, Color.green, Color.magenta, Color.yellow, Color.grey, Color.black, new Color(1f, 0.65f, 0f), new Color(1f, 0.65f, 0f) };

        colorSequences[9] = new Color[10][];
        colorSequences[9][0] = new Color[] { Color.red, Color.green, Color.red, Color.red, Color.red, Color.red, Color.blue, Color.magenta, Color.grey, Color.black };
        colorSequences[9][1] = new Color[] { Color.blue, Color.magenta, Color.grey, Color.black, Color.white, new Color(1f, 0.65f, 0f), Color.green, new Color(0.5f, 0f, 0.5f), Color.yellow, Color.red };
        colorSequences[9][2] = new Color[] { Color.blue, new Color(1f, 0.65f, 0f), Color.red, Color.green, Color.magenta, Color.grey, Color.yellow, Color.black, Color.red, new Color(0.5f, 0f, 0.5f) };
        colorSequences[9][3] = new Color[] { Color.white, Color.yellow, Color.blue, Color.green, Color.grey, Color.magenta, new Color(1f, 0.65f, 0f), Color.black, new Color(0.5f, 0f, 0.5f), Color.red };
        colorSequences[9][4] = new Color[] { Color.magenta, Color.black, Color.green, Color.blue, Color.red, Color.white, Color.grey, new Color(1f, 0.65f, 0f), new Color(0.5f, 0f, 0.5f), Color.yellow };
        colorSequences[9][5] = new Color[] { Color.green, Color.blue, Color.yellow, Color.red, Color.magenta, Color.grey, Color.black, Color.white, Color.red, new Color(1f, 0.65f, 0f) };
        colorSequences[9][6] = new Color[] { Color.grey, Color.red, Color.magenta, Color.green, Color.red, Color.red, Color.yellow, Color.white, Color.black, new Color(1f, 0.65f, 0f) };
        colorSequences[9][7] = new Color[] { Color.black, Color.white, Color.red, new Color(0.5f, 0f, 0.5f), Color.magenta, Color.blue, Color.green, Color.red, Color.grey, Color.yellow };
            colorSequences[9][8] = new Color[] { Color.green, Color.magenta, new Color(1f, 0.65f, 0f), Color.blue, Color.red, Color.black, Color.red, Color.red, Color.red, Color.grey };
        colorSequences[9][9] = new Color[] { new Color(1f, 0.65f, 0f), Color.green, Color.red, Color.blue, Color.red, Color.magenta, Color.black, Color.grey, Color.yellow, new Color(0.5f, 0f, 0.5f) };

        colorSequences[10] = new Color[10][];
            colorSequences[10][0] = new Color[] { Color.red, Color.red, Color.red, Color.yellow, Color.green, Color.blue, Color.red, Color.grey, Color.black, Color.white };
        colorSequences[10][1] = new Color[] { Color.green, Color.blue, Color.yellow, Color.magenta, Color.grey, Color.black, Color.white, new Color(1f, 0.65f, 0f), new Color(0.5f, 0f, 0.5f), Color.red };
        colorSequences[10][2] = new Color[] { Color.white, Color.yellow, Color.blue, Color.red, new Color(0.5f, 0f, 0.5f), Color.green, Color.grey, Color.magenta, new Color(1f, 0.65f, 0f), Color.black };
        colorSequences[10][3] = new Color[] { Color.green, Color.magenta, new Color(0.5f, 0f, 0.5f), Color.blue, Color.red, Color.yellow, Color.grey, Color.black, Color.white, new Color(1f, 0.65f, 0f) };
        colorSequences[10][4] = new Color[] { Color.white, Color.green, Color.yellow, Color.blue, Color.black, Color.magenta, Color.grey, new Color(1f, 0.65f, 0f), Color.red, Color.red };
        colorSequences[10][5] = new Color[] { Color.blue, Color.yellow, new Color(0.5f, 0f, 0.5f), Color.green, Color.magenta, Color.grey, Color.red, new Color(1f, 0.65f, 0f), Color.white, Color.black};
        colorSequences[10][6] = new Color[] { Color.magenta, Color.black, new Color(1f, 0.65f, 0f), Color.yellow, Color.green, Color.blue, Color.red, Color.white, Color.grey, new Color(0.5f, 0f, 0.5f) };
        colorSequences[10][7] = new Color[] { Color.grey, Color.blue, Color.yellow, Color.green, new Color(1f, 0.65f, 0f), Color.red, Color.magenta, Color.white, Color.black, Color.black };
        colorSequences[10][8] = new Color[] { new Color(1f, 0.65f, 0f), Color.green, Color.yellow, Color.red, Color.blue, Color.magenta, Color.black, Color.white, Color.grey, Color.white };
        colorSequences[10][9] = new Color[] { Color.white, Color.red, Color.blue, Color.green, Color.magenta, new Color(0.5f, 0f, 0.5f), Color.yellow, Color.grey, Color.black, new Color(1f, 0.65f, 0f)};

        colorSequences[11] = new Color[10][];
            colorSequences[11][0] = new Color[] { Color.red, Color.green, Color.blue, Color.magenta, Color.red, Color.black, Color.red, new Color(1f, 0.65f, 0f), Color.yellow, Color.red };
        colorSequences[11][1] = new Color[] { Color.yellow, Color.blue, Color.green, Color.black, Color.red, new Color(0.5f, 0f, 0.5f), Color.magenta, Color.white, new Color(1f, 0.65f, 0f), Color.grey };
        colorSequences[11][2] = new Color[] { Color.white, Color.green, Color.grey, Color.yellow, new Color(0.5f, 0f, 0.5f), Color.magenta, Color.red, new Color(1f, 0.65f, 0f), Color.blue, Color.black };
        colorSequences[11][3] = new Color[] { Color.magenta, Color.yellow, new Color(1f, 0.65f, 0f), Color.blue, Color.grey, Color.black, Color.white, Color.green, new Color(0.5f, 0f, 0.5f), Color.red };
        colorSequences[11][4] = new Color[] { Color.blue, Color.white, Color.green, Color.red, Color.yellow, Color.grey, Color.black, new Color(1f, 0.65f, 0f), new Color(0.5f, 0f, 0.5f), Color.magenta };
        colorSequences[11][5] = new Color[] { new Color(1f, 0.65f, 0f), Color.red, Color.green, Color.magenta, Color.white, Color.black, Color.blue, Color.yellow, new Color(0.5f, 0f, 0.5f), Color.grey };
        colorSequences[11][6] = new Color[] { Color.grey, Color.magenta, Color.blue, Color.green, Color.black, Color.yellow, Color.white, new Color(1f, 0.65f, 0f), Color.red, new Color(0.5f, 0f, 0.5f) };
        colorSequences[11][7] = new Color[] { Color.black, Color.yellow, new Color(0.5f, 0f, 0.5f), Color.green, Color.red, Color.white, Color.grey, new Color(1f, 0.65f, 0f), Color.magenta, Color.blue };
        colorSequences[11][8] = new Color[] { Color.green, Color.blue, Color.magenta, Color.red, Color.grey, new Color(1f, 0.65f, 0f), Color.black, Color.white, Color.yellow, new Color(0.5f, 0f, 0.5f) };
        colorSequences[11][9] = new Color[] { new Color(0.5f, 0f, 0.5f), Color.red, Color.blue, Color.yellow, Color.white, Color.magenta, Color.grey, new Color(1f, 0.65f, 0f), Color.green, Color.black };

        colorSequences[12] = new Color[10][];
        colorSequences[12][0] = new Color[] { Color.yellow, new Color(0.5f, 0f, 0.5f), Color.green, Color.blue, Color.magenta, Color.grey, Color.black, new Color(1f, 0.65f, 0f), Color.white, Color.red };
        colorSequences[12][1] = new Color[] { new Color(1f, 0.65f, 0f), Color.red, Color.grey, Color.blue, Color.green, Color.magenta, Color.black, Color.white, Color.yellow, new Color(0.5f, 0f, 0.5f) };
        colorSequences[12][2] = new Color[] { Color.white, Color.yellow, Color.blue, Color.red, Color.green, Color.grey, Color.magenta, new Color(1f, 0.65f, 0f), Color.black, new Color(0.5f, 0f, 0.5f) };
        colorSequences[12][3] = new Color[] { Color.green, Color.magenta, Color.blue, Color.red, Color.yellow, Color.grey, Color.black, Color.white, new Color(1f, 0.65f, 0f), new Color(0.5f, 0f, 0.5f) };
            colorSequences[12][4] = new Color[] { Color.red, Color.blue, Color.green, Color.red, Color.magenta, Color.grey, Color.red, Color.white, Color.yellow, Color.red };
        colorSequences[12][5] = new Color[] { Color.blue, Color.yellow, Color.green, new Color(0.5f, 0f, 0.5f), Color.magenta, Color.grey, Color.red, new Color(1f, 0.65f, 0f), Color.white, Color.black };
        colorSequences[12][6] = new Color[] { Color.magenta, Color.black, new Color(1f, 0.65f, 0f), Color.yellow, Color.green, Color.blue, Color.red, Color.white, Color.grey, new Color(0.5f, 0f, 0.5f) };
        colorSequences[12][7] = new Color[] { Color.grey, Color.blue, Color.yellow, Color.green, new Color(1f, 0.65f, 0f), new Color(0.5f, 0f, 0.5f), Color.red, Color.magenta, Color.white, Color.black };
        colorSequences[12][8] = new Color[] { new Color(1f, 0.65f, 0f), Color.green, Color.yellow, Color.red, Color.blue, Color.magenta, Color.black, Color.white, Color.grey, new Color(0.5f, 0f, 0.5f) };
        colorSequences[12][9] = new Color[] { Color.white, Color.red, Color.blue, Color.green, Color.magenta, Color.yellow, Color.grey, Color.black, new Color(1f, 0.65f, 0f), new Color(0.5f, 0f, 0.5f) };

        colorSequences[13] = new Color[10][];
        colorSequences[13][0] = new Color[] { Color.red, Color.magenta, Color.green, Color.blue, Color.black, Color.yellow, Color.white, Color.grey, new Color(1f, 0.65f, 0f), new Color(0.5f, 0f, 0.5f) };
        colorSequences[13][1] = new Color[] { Color.green, new Color(1f, 0.65f, 0f), Color.magenta, Color.grey, Color.white, Color.black, Color.yellow, new Color(0.5f, 0f, 0.5f), Color.blue, Color.red };
        colorSequences[13][2] = new Color[] { Color.white, Color.yellow, Color.blue, Color.red, Color.green, Color.grey, Color.magenta, new Color(1f, 0.65f, 0f), Color.black, new Color(0.5f, 0f, 0.5f) };
        colorSequences[13][3] = new Color[] { Color.green, Color.magenta, Color.blue, Color.red, Color.yellow, Color.grey, Color.black, Color.white, new Color(1f, 0.65f, 0f), new Color(0.5f, 0f, 0.5f) };
            colorSequences[13][4] = new Color[] { Color.red, Color.red, Color.blue, Color.green, Color.red, Color.magenta, Color.grey, Color.black, Color.white, Color.red };
        colorSequences[13][5] = new Color[] { Color.blue, Color.yellow, new Color(0.5f, 0f, 0.5f), Color.green, Color.magenta, Color.grey, Color.red, new Color(1f, 0.65f, 0f), Color.white, Color.black,  };
        colorSequences[13][6] = new Color[] { Color.magenta, Color.black, new Color(1f, 0.65f, 0f), new Color(0.5f, 0f, 0.5f), Color.yellow, Color.green, Color.blue, Color.red, Color.white, Color.grey };
        colorSequences[13][7] = new Color[] { Color.grey, Color.blue, Color.yellow, Color.green, new Color(1f, 0.65f, 0f), Color.red, Color.magenta, Color.white, Color.black, new Color(0.5f, 0f, 0.5f) };
        colorSequences[13][8] = new Color[] { new Color(1f, 0.65f, 0f), Color.green, Color.yellow, Color.red, Color.blue, new Color(0.5f, 0f, 0.5f), Color.magenta, Color.black, Color.white, Color.grey };
        colorSequences[13][9] = new Color[] { Color.white, Color.red, Color.blue, Color.green, Color.magenta, Color.yellow, Color.grey, Color.black, new Color(1f, 0.65f, 0f), new Color(0.5f, 0f, 0.5f) };

        colorSequences[14] = new Color[10][];
        colorSequences[14][0] = new Color[] { Color.red, Color.green, Color.blue, Color.magenta, Color.grey, Color.black, Color.white, new Color(1f, 0.65f, 0f), Color.yellow, Color.yellow };
            colorSequences[14][1] = new Color[] { Color.yellow, Color.magenta, Color.green, Color.red, Color.red, new Color(0.5f, 0f, 0.5f), Color.red, Color.red, new Color(1f, 0.65f, 0f), Color.grey };
        colorSequences[14][2] = new Color[] { Color.white, Color.green, Color.grey, Color.yellow, new Color(0.5f, 0f, 0.5f), Color.magenta, Color.red, new Color(1f, 0.65f, 0f), Color.blue, Color.black };
        colorSequences[14][3] = new Color[] { Color.magenta, Color.yellow, new Color(1f, 0.65f, 0f), Color.blue, Color.grey, Color.black, Color.white, Color.green, Color.red, Color.yellow };
        colorSequences[14][4] = new Color[] { Color.blue, Color.white, Color.green, Color.red, Color.yellow, Color.grey, Color.black, new Color(1f, 0.65f, 0f), new Color(0.5f, 0f, 0.5f), Color.magenta };
        colorSequences[14][5] = new Color[] { new Color(1f, 0.65f, 0f), Color.red, Color.green, Color.magenta, Color.white, Color.black, Color.blue, Color.yellow, Color.grey, new Color(0.5f, 0f, 0.5f) };
        colorSequences[14][6] = new Color[] { Color.grey, Color.magenta, Color.blue, Color.green, Color.black, Color.yellow, Color.white, new Color(1f, 0.65f, 0f), Color.red, new Color(0.5f, 0f, 0.5f) };
        colorSequences[14][7] = new Color[] { Color.black, Color.yellow, new Color(0.5f, 0f, 0.5f), Color.green, Color.red, Color.white, Color.grey, new Color(1f, 0.65f, 0f), Color.magenta, Color.blue };
        colorSequences[14][8] = new Color[] { Color.green, Color.blue, Color.magenta, Color.red, Color.grey, new Color(1f, 0.65f, 0f), Color.black, Color.white, Color.yellow, new Color(0.5f, 0f, 0.5f) };
        colorSequences[14][9] = new Color[] { new Color(0.5f, 0f, 0.5f), Color.red, Color.blue, Color.yellow, Color.white, Color.magenta, Color.grey, new Color(1f, 0.65f, 0f), Color.green, Color.black };
       
        colorSequences[15] = new Color[10][];
        colorSequences[15][0] = new Color[] { Color.red, Color.magenta, Color.green, Color.blue, Color.black, Color.yellow, Color.white, Color.grey, new Color(1f, 0.65f, 0f), new Color(0.5f, 0f, 0.5f) };
        colorSequences[15][1] = new Color[] { Color.green, new Color(1f, 0.65f, 0f), Color.magenta, Color.grey, Color.white, Color.black, Color.yellow, Color.blue, Color.red, Color.yellow };
        colorSequences[15][2] = new Color[] { Color.white, Color.yellow, Color.blue, Color.red, Color.green, Color.grey, Color.magenta, new Color(1f, 0.65f, 0f), Color.black, Color.black };
        colorSequences[15][3] = new Color[] { Color.green, Color.magenta, Color.blue, Color.red, Color.yellow, Color.grey, Color.black, Color.white, new Color(1f, 0.65f, 0f), new Color(0.5f, 0f, 0.5f) };
            colorSequences[15][4] = new Color[] { Color.red, Color.red, Color.blue, Color.green, Color.red, Color.magenta, Color.grey, Color.black, Color.red, Color.yellow };
        colorSequences[15][5] = new Color[] { Color.blue, Color.yellow, Color.green, Color.magenta, Color.grey, Color.red, new Color(1f, 0.65f, 0f), Color.white, Color.black, Color.white };
        colorSequences[15][6] = new Color[] { Color.magenta, Color.black, new Color(1f, 0.65f, 0f), Color.yellow, Color.green, Color.blue, Color.red, Color.white, Color.grey, new Color(0.5f, 0f, 0.5f) };
        colorSequences[15][7] = new Color[] { Color.grey, Color.blue, Color.yellow, Color.green, new Color(1f, 0.65f, 0f), Color.red, Color.magenta, Color.white, Color.black, new Color(0.5f, 0f, 0.5f) };
        colorSequences[15][8] = new Color[] { new Color(1f, 0.65f, 0f), Color.green, Color.yellow, Color.red, Color.blue, Color.magenta, Color.black, Color.white, Color.grey, new Color(0.5f, 0f, 0.5f) };
        colorSequences[15][9] = new Color[] { Color.white, Color.red, Color.blue, Color.green, Color.magenta, Color.yellow, Color.grey, Color.black, new Color(1f, 0.65f, 0f), Color.yellow };
        
        colorSequences[16] = new Color[10][];
        colorSequences[16][0] = new Color[] { Color.green, Color.blue, Color.magenta, Color.red, Color.grey, new Color(1f, 0.65f, 0f), Color.black, Color.white, Color.yellow, new Color(0.5f, 0f, 0.5f) };
        colorSequences[16][1] = new Color[] { Color.red, Color.green, new Color(0.5f, 0f, 0.5f), new Color(1f, 0.65f, 0f), Color.magenta, Color.white, Color.black, Color.yellow, Color.blue, Color.grey };
        colorSequences[16][2] = new Color[] { Color.yellow, Color.black, Color.white, Color.green, Color.magenta, Color.red, Color.blue, new Color(0.5f, 0f, 0.5f), Color.grey, new Color(1f, 0.65f, 0f) };
        colorSequences[16][3] = new Color[] { Color.black, Color.grey, Color.white, Color.green, new Color(0.5f, 0f, 0.5f), new Color(1f, 0.65f, 0f), Color.yellow, Color.blue, Color.red, Color.magenta };
        colorSequences[16][4] = new Color[] { Color.white, Color.magenta, Color.red, Color.yellow, Color.green, Color.black, Color.grey, Color.blue, new Color(1f, 0.65f, 0f), new Color(0.5f, 0f, 0.5f) };
        colorSequences[16][5] = new Color[] { Color.grey, new Color(1f, 0.65f, 0f), new Color(0.5f, 0f, 0.5f), Color.red, Color.blue, Color.black, Color.white, Color.green, Color.magenta, Color.yellow };
        colorSequences[16][6] = new Color[] { Color.yellow, Color.white, Color.green, Color.blue, Color.magenta, new Color(0.5f, 0f, 0.5f), new Color(1f, 0.65f, 0f), Color.red, Color.black, Color.grey};
            colorSequences[16][7] = new Color[] { Color.red, Color.black, Color.white, Color.red, Color.yellow, Color.magenta, Color.green, Color.blue, Color.red, Color.red };
        colorSequences[16][8] = new Color[] { Color.blue, Color.green, Color.white, Color.red, Color.magenta, Color.yellow, Color.black, Color.grey, new Color(1f, 0.65f, 0f), new Color(0.5f, 0f, 0.5f) };
        colorSequences[16][9] = new Color[] { Color.black, Color.yellow, Color.white, Color.magenta, Color.red, Color.green, Color.blue, Color.grey, new Color(0.5f, 0f, 0.5f), new Color(1f, 0.65f, 0f) };

        colorSequences[17] = new Color[10][];
        colorSequences[17][0] = new Color[] { Color.green, Color.red, Color.blue, Color.magenta, Color.black, Color.yellow, Color.white, Color.grey, Color.blue, Color.red };
        colorSequences[17][1] = new Color[] { Color.yellow, Color.green, Color.red, Color.black, Color.magenta, Color.blue, Color.white, Color.grey, Color.green, Color.blue };
        colorSequences[17][2] = new Color[] { Color.white, Color.black, Color.blue, Color.green, Color.magenta, Color.red, Color.yellow, Color.grey, Color.blue, Color.red };
        colorSequences[17][3] = new Color[] { Color.blue, Color.red, Color.white, Color.black, Color.grey, Color.green, Color.magenta, Color.yellow, Color.green, Color.blue };
        colorSequences[17][4] = new Color[] { Color.black, Color.magenta, Color.green, Color.yellow, Color.white, Color.blue, Color.red, Color.grey, Color.blue, Color.red };
        colorSequences[17][5] = new Color[] { Color.red, Color.green, Color.white, Color.yellow, Color.black, Color.blue, Color.grey, Color.magenta, Color.green, Color.blue };
        colorSequences[17][6] = new Color[] { Color.magenta, Color.yellow, Color.blue, Color.red, Color.white, Color.green, Color.grey, Color.black, Color.red, Color.green };
        colorSequences[17][7] = new Color[] { Color.green, Color.grey, Color.white, Color.red, Color.blue, Color.black, Color.yellow, Color.magenta, Color.blue, Color.red };
        colorSequences[17][8] = new Color[] { Color.red, Color.yellow, Color.magenta, Color.green, Color.black, Color.blue, Color.white, Color.grey, Color.green, Color.blue };
            colorSequences[17][9] = new Color[] { Color.white, Color.red, Color.magenta, Color.red, Color.red, Color.yellow, Color.green, Color.blue, Color.red, Color.green };

        colorSequences[18] = new Color[10][];
        colorSequences[18][0] = new Color[] { Color.blue, new Color(0.5f, 0f, 0.5f), Color.red, new Color(1f, 0.65f, 0f), new Color(1f, 0.65f, 0f), new Color(0.5f, 0f, 0.5f), Color.white, Color.grey, Color.yellow, Color.green };
        colorSequences[18][1] = new Color[] { Color.yellow, Color.magenta, Color.green, Color.blue, Color.red, Color.black, Color.white, Color.grey, Color.green, Color.red };
            colorSequences[18][2] = new Color[] { Color.red, Color.red, Color.white, Color.magenta, Color.red, Color.yellow, Color.black, Color.red, Color.green, Color.blue };
        colorSequences[18][3] = new Color[] { Color.green, Color.red, Color.magenta, Color.yellow, Color.white, Color.black, Color.grey, Color.blue, new Color(0.5f, 0f, 0.5f), Color.green };
        colorSequences[18][4] = new Color[] { Color.black, Color.grey, Color.white, Color.blue, Color.red, Color.green, new Color(1f, 0.65f, 0f), Color.yellow, Color.green, Color.red };
        colorSequences[18][5] = new Color[] { Color.yellow, Color.blue, Color.green, Color.magenta, new Color(0.5f, 0f, 0.5f), Color.white, Color.red, Color.grey, Color.blue, Color.green };
        colorSequences[18][6] = new Color[] { Color.magenta, Color.red, Color.green, Color.black, Color.yellow, Color.white, Color.blue, Color.grey, Color.green, Color.blue };
        colorSequences[18][7] = new Color[] { new Color(1f, 0.65f, 0f), new Color(1f, 0.65f, 0f), Color.red, Color.green, Color.black, Color.grey, Color.magenta, Color.blue, Color.green, Color.red };
        colorSequences[18][8] = new Color[] { Color.grey, Color.green, Color.blue, Color.yellow, Color.black, Color.red, Color.magenta, Color.white, new Color(0.5f, 0f, 0.5f), Color.blue };
        colorSequences[18][9] = new Color[] { Color.blue, Color.red, new Color(0.5f, 0f, 0.5f), Color.magenta, Color.grey, new Color(1f, 0.65f, 0f), Color.white, Color.black, Color.green, Color.blue };

        colorSequences[19] = new Color[10][];
        colorSequences[19][0] = new Color[] { Color.green, Color.black, Color.red, Color.magenta, Color.blue, new Color(1f, 0.65f, 0f), Color.white, Color.grey, Color.yellow, new Color(0.5f, 0f, 0.5f) };
        colorSequences[19][1] = new Color[] { Color.red, Color.blue, Color.white, Color.green, Color.grey, Color.yellow, Color.magenta, Color.black, Color.green, Color.white };
        colorSequences[19][2] = new Color[] { Color.blue, Color.yellow, new Color(1f, 0.65f, 0f), Color.white, Color.black, Color.magenta, Color.grey, Color.red, Color.green, Color.blue };
        colorSequences[19][3] = new Color[] { Color.black, Color.green, new Color(0.5f, 0f, 0.5f), Color.yellow, Color.blue, Color.white, Color.magenta, Color.grey, Color.blue, Color.red };
        colorSequences[19][4] = new Color[] { Color.magenta, Color.white, Color.green, Color.yellow, Color.red, Color.blue, Color.black, Color.grey, Color.green, Color.blue };
            colorSequences[19][5] = new Color[] { Color.grey, Color.yellow, Color.blue, Color.red, Color.red, Color.white, Color.red, Color.magenta, Color.green, Color.red };
        colorSequences[19][6] = new Color[] { Color.yellow, Color.red, Color.magenta, Color.black, Color.green, Color.blue, Color.grey, Color.white, Color.green, Color.blue };
        colorSequences[19][7] = new Color[] { new Color(1f, 0.65f, 0f), Color.blue, Color.green, Color.yellow, Color.grey, Color.white, Color.black, Color.magenta, Color.green, Color.red };
        colorSequences[19][8] = new Color[] { Color.green, Color.white, Color.black, Color.yellow, new Color(0.5f, 0f, 0.5f), Color.magenta, Color.blue, Color.grey, Color.green, Color.blue };
        colorSequences[19][9] = new Color[] { Color.white, Color.green, new Color(1f, 0.65f, 0f), Color.yellow, new Color(1f, 0.65f, 0f), Color.red, Color.magenta, Color.grey, Color.green, new Color(0.5f, 0f, 0.5f) };

        colorSequences[20] = new Color[10][];
        colorSequences[20][0] = new Color[] { Color.black, new Color(1f, 0.65f, 0f), Color.green, Color.blue, Color.yellow, Color.white, new Color(0.5f, 0f, 0.5f), Color.magenta, Color.green, Color.yellow };
        colorSequences[20][1] = new Color[] { Color.red, Color.white, Color.blue, Color.magenta, Color.grey, Color.green, Color.black, Color.yellow, Color.green, new Color(1f, 0.65f, 0f) };
        colorSequences[20][2] = new Color[] { Color.green, Color.yellow, new Color(1f, 0.65f, 0f), Color.black, Color.white, Color.magenta, Color.blue, Color.grey, Color.red, Color.green };
        colorSequences[20][3] = new Color[] { Color.magenta, Color.green, Color.red, Color.blue, new Color(0.5f, 0f, 0.5f), Color.yellow, Color.black, Color.grey, Color.green, new Color(1f, 0.65f, 0f) };
        colorSequences[20][4] = new Color[] { Color.yellow, Color.grey, new Color(1f, 0.65f, 0f), Color.green, Color.black, Color.blue, Color.magenta, Color.white, Color.green, Color.yellow };
        colorSequences[20][5] = new Color[] { Color.white, Color.red, Color.green, Color.magenta, Color.yellow, Color.black, Color.blue, Color.grey, Color.yellow, Color.green };
        colorSequences[20][6] = new Color[] { Color.blue, new Color(0.5f, 0f, 0.5f), Color.green, Color.black, Color.yellow, Color.magenta, Color.white, Color.grey, Color.green, Color.blue };
            colorSequences[20][7] = new Color[] { Color.red, Color.yellow, Color.green, Color.white, Color.red, Color.blue, Color.red, Color.magenta, Color.green, Color.red };
        colorSequences[20][8] = new Color[] { Color.red, Color.blue, Color.white, Color.green, Color.magenta, Color.black, Color.grey, Color.yellow, Color.green, Color.red };
        colorSequences[20][9] = new Color[] { Color.black, Color.green, Color.red, Color.magenta, Color.white, Color.grey, new Color(0.5f, 0f, 0.5f), Color.blue, Color.green, new Color(1f, 0.65f, 0f) };

        colorSequences[21] = new Color[10][];
        colorSequences[21][0] = new Color[] { new Color(0.5f, 0f, 0.5f), new Color(0.5f, 0f, 0.5f), Color.green, Color.yellow, Color.black, Color.magenta, Color.white, Color.grey, Color.yellow, Color.green };
        colorSequences[21][1] = new Color[] { Color.green, Color.red, Color.white, Color.black, Color.grey, Color.yellow, Color.blue, Color.magenta, Color.red, Color.blue };
        colorSequences[21][2] = new Color[] { Color.blue, Color.black, new Color(0.5f, 0f, 0.5f), Color.green, Color.yellow, new Color(1f, 0.65f, 0f), Color.grey, Color.magenta, Color.green, new Color(1f, 0.65f, 0f) };
        colorSequences[21][3] = new Color[] { Color.yellow, Color.red, Color.green, Color.blue, Color.black, Color.white, Color.grey, Color.magenta, new Color(0.5f, 0f, 0.5f), Color.green };
            colorSequences[21][4] = new Color[] { Color.grey, Color.yellow, Color.red, Color.red, Color.green, Color.black, Color.red, Color.white, Color.red, Color.green };
        colorSequences[21][5] = new Color[] { Color.green, Color.white, Color.black, Color.red, Color.magenta, Color.blue, Color.grey, Color.yellow, Color.green, Color.red };
        colorSequences[21][6] = new Color[] { Color.black, Color.grey, new Color(1f, 0.65f, 0f), Color.green, Color.white, Color.yellow, Color.blue, Color.magenta, Color.green, new Color(0.5f, 0f, 0.5f) };
        colorSequences[21][7] = new Color[] { Color.red, Color.black, Color.blue, Color.green, Color.yellow, Color.white, Color.grey, Color.magenta, new Color(1f, 0.65f, 0f), Color.green };
        colorSequences[21][8] = new Color[] { Color.yellow, Color.green, new Color(1f, 0.65f, 0f), Color.black, Color.red, Color.white, Color.grey, Color.blue, Color.green, Color.red };
        colorSequences[21][9] = new Color[] { Color.white, new Color(0.5f, 0f, 0.5f), Color.yellow, Color.green, Color.black, Color.blue, new Color(0.5f, 0f, 0.5f), Color.grey, Color.green, Color.red };

        colorSequences[22] = new Color[10][];
            colorSequences[22][0] = new Color[] { Color.red, Color.green, Color.black, Color.red, new Color(0.5f, 0f, 0.5f), Color.grey, Color.magenta, Color.white, Color.red, Color.red };
        colorSequences[22][1] = new Color[] { Color.green, Color.yellow, Color.red, Color.black, Color.white, Color.grey, Color.magenta, Color.blue, new Color(0.5f, 0f, 0.5f), Color.green };
        colorSequences[22][2] = new Color[] { Color.red, Color.green, Color.white, Color.black, Color.blue, new Color(0.5f, 0f, 0.5f), Color.yellow, Color.grey, Color.green, Color.red };
        colorSequences[22][3] = new Color[] { Color.magenta, Color.red, Color.yellow, Color.green, Color.black, Color.white, Color.grey, Color.blue, Color.green, new Color(1f, 0.65f, 0f) };
        colorSequences[22][4] = new Color[] { Color.black, Color.white, new Color(0.5f, 0f, 0.5f), Color.red, Color.magenta, Color.yellow, Color.blue, Color.grey, Color.green, new Color(0.5f, 0f, 0.5f) };
        colorSequences[22][5] = new Color[] { Color.yellow, new Color(1f, 0.65f, 0f), Color.black, Color.blue, Color.green, Color.white, Color.magenta, Color.grey, Color.red, Color.green };
        colorSequences[22][6] = new Color[] { Color.blue, Color.green, Color.red, Color.yellow, Color.black, Color.white, Color.grey, Color.magenta, Color.green, new Color(1f, 0.65f, 0f) };
        colorSequences[22][7] = new Color[] { new Color(0.5f, 0f, 0.5f), Color.green, new Color(0.5f, 0f, 0.5f), Color.black, Color.magenta, Color.blue, Color.yellow, Color.grey, Color.green, Color.red };
        colorSequences[22][8] = new Color[] { Color.green, Color.black, new Color(1f, 0.65f, 0f), Color.yellow, Color.magenta, Color.white, Color.grey, Color.blue, new Color(1f, 0.65f, 0f), Color.green };
        colorSequences[22][9] = new Color[] { Color.grey, Color.red, Color.yellow, Color.blue, new Color(0.5f, 0f, 0.5f), Color.white, Color.black, Color.magenta, Color.green, new Color(1f, 0.65f, 0f) };

        colorSequences[23] = new Color[10][];
        colorSequences[23][0] = new Color[] { new Color(0.5f, 0f, 0.5f), new Color(1f, 0.65f, 0f), Color.blue, Color.green, Color.black, Color.white, Color.magenta, Color.grey, new Color(0.5f, 0f, 0.5f), Color.green };
        colorSequences[23][1] = new Color[] { Color.green, Color.red, Color.black, Color.blue, new Color(1f, 0.65f, 0f), Color.magenta, Color.yellow, Color.grey, Color.green, new Color(1f, 0.65f, 0f) };
        colorSequences[23][2] = new Color[] { Color.red, Color.green, Color.black, Color.white, Color.magenta, Color.grey, Color.yellow, Color.blue, new Color(1f, 0.65f, 0f), Color.red };
            colorSequences[23][3] = new Color[] { Color.black, Color.red, new Color(1f, 0.65f, 0f), Color.red, Color.magenta, Color.red, Color.blue, Color.grey, Color.red, Color.green };
        colorSequences[23][4] = new Color[] { Color.white, Color.blue, Color.red, Color.green, Color.magenta, Color.grey, Color.black, Color.yellow, Color.green, new Color(0.5f, 0f, 0.5f) };
        colorSequences[23][5] = new Color[] { Color.blue, Color.green, new Color(1f, 0.65f, 0f), new Color(0.5f, 0f, 0.5f), Color.black, Color.white, Color.grey, Color.yellow, Color.green, new Color(1f, 0.65f, 0f) };
        colorSequences[23][6] = new Color[] { Color.magenta, Color.yellow, Color.red, Color.black, Color.green, Color.white, Color.grey, new Color(0.5f, 0f, 0.5f), new Color(0.5f, 0f, 0.5f), Color.red };
        colorSequences[23][7] = new Color[] { Color.red, Color.green, Color.white, Color.blue, new Color(1f, 0.65f, 0f), Color.black, Color.magenta, Color.grey, Color.green, Color.red };
        colorSequences[23][8] = new Color[] { new Color(0.5f, 0f, 0.5f), Color.grey, Color.green, Color.red, Color.yellow, new Color(0.5f, 0f, 0.5f), Color.blue, Color.magenta, Color.green, new Color(0.5f, 0f, 0.5f) };
        colorSequences[23][9] = new Color[] { Color.yellow, new Color(1f, 0.65f, 0f), Color.black, Color.blue, Color.green, Color.magenta, Color.grey, Color.white, new Color(1f, 0.65f, 0f), Color.green };

        colorSequences[24] = new Color[10][];
        colorSequences[24][0] = new Color[] { Color.green, Color.black, Color.red, new Color(0.5f, 0f, 0.5f), Color.magenta, Color.white, Color.grey, Color.blue, new Color(1f, 0.65f, 0f), new Color(1f, 0.65f, 0f) };
        colorSequences[24][1] = new Color[] { Color.red, Color.yellow, Color.green, Color.black, Color.white, Color.blue, Color.magenta, Color.grey, Color.green, new Color(0.5f, 0f, 0.5f) };
        colorSequences[24][2] = new Color[] { Color.blue, Color.green, new Color(1f, 0.65f, 0f), new Color(0.5f, 0f, 0.5f), Color.yellow, Color.white, Color.black, Color.grey, Color.red, Color.green };
        colorSequences[24][3] = new Color[] { Color.yellow, Color.white, Color.red, Color.green, Color.black, Color.grey, Color.magenta, Color.blue, Color.green, new Color(0.5f, 0f, 0.5f) };
            colorSequences[24][4] = new Color[] { Color.magenta, Color.red, Color.red, Color.red, Color.black, new Color(1f, 0.65f, 0f), Color.blue, Color.grey, Color.red, Color.green };
        colorSequences[24][5] = new Color[] { Color.green, Color.blue, new Color(1f, 0.65f, 0f), Color.white, Color.black, Color.grey, Color.magenta, Color.yellow, Color.green, Color.red };
        colorSequences[24][6] = new Color[] { Color.red, Color.magenta, Color.white, Color.green, Color.grey, Color.black, Color.blue, Color.yellow, Color.green, Color.red };
        colorSequences[24][7] = new Color[] { new Color(0.5f, 0f, 0.5f), Color.green, Color.red, Color.blue, new Color(0.5f, 0f, 0.5f), Color.black, Color.yellow, Color.grey, Color.green, new Color(1f, 0.65f, 0f) };
        colorSequences[24][8] = new Color[] { Color.grey, Color.black, Color.red, Color.green, Color.blue, new Color(1f, 0.65f, 0f), Color.white, Color.magenta, Color.green, Color.red };
        colorSequences[24][9] = new Color[] { Color.green, Color.red, new Color(1f, 0.65f, 0f), Color.magenta, Color.blue, Color.yellow, Color.white, Color.grey, new Color(1f, 0.65f, 0f), Color.green };

        colorSequences[25] = new Color[10][];
        colorSequences[25][0] = new Color[] { new Color(0.5f, 0f, 0.5f), Color.green, new Color(1f, 0.65f, 0f), Color.blue, Color.yellow, Color.white, new Color(0.5f, 0f, 0.5f), new Color(0.5f, 0f, 0.5f), Color.green, Color.red };
        colorSequences[25][1] = new Color[] { Color.black, Color.blue, Color.yellow, Color.green, Color.red, Color.magenta, Color.white, Color.grey, Color.green, Color.red };
        colorSequences[25][2] = new Color[] { Color.magenta, new Color(1f, 0.65f, 0f), Color.green, Color.black, new Color(0.5f, 0f, 0.5f), Color.white, Color.blue, Color.grey, new Color(1f, 0.65f, 0f), Color.green };
        colorSequences[25][3] = new Color[] { Color.yellow, Color.green, new Color(1f, 0.65f, 0f), Color.red, Color.blue, Color.white, Color.magenta, Color.grey, Color.red, Color.green };
        colorSequences[25][4] = new Color[] { Color.white, Color.green, Color.black, Color.blue, new Color(0.5f, 0f, 0.5f), new Color(1f, 0.65f, 0f), Color.red, Color.grey, Color.green, new Color(0.5f, 0f, 0.5f) };
        colorSequences[25][5] = new Color[] { new Color(0.5f, 0f, 0.5f), Color.red, Color.blue, Color.yellow, Color.magenta, Color.black, Color.white, Color.grey, new Color(0.5f, 0f, 0.5f), Color.green };
        colorSequences[25][6] = new Color[] { Color.grey, Color.black, Color.green, new Color(0.5f, 0f, 0.5f), Color.blue, Color.magenta, Color.yellow, Color.white, Color.green, new Color(1f, 0.65f, 0f) };
        colorSequences[25][7] = new Color[] { Color.blue, Color.green, Color.red, new Color(1f, 0.65f, 0f), Color.black, Color.yellow, Color.white, Color.grey, new Color(0.5f, 0f, 0.5f), Color.red };
        colorSequences[25][8] = new Color[] { Color.green, new Color(0.5f, 0f, 0.5f), Color.magenta, Color.black, Color.blue, Color.yellow, Color.white, Color.grey, Color.green, Color.red };
            colorSequences[25][9] = new Color[] { Color.red, Color.red, Color.black, Color.green, new Color(1f, 0.65f, 0f), Color.white, Color.blue, Color.grey, Color.red, Color.red };

        colorSequences[26] = new Color[10][];
        colorSequences[26][0] = new Color[] { Color.red, new Color(1f, 0.65f, 0f), Color.blue, Color.yellow, Color.black, new Color(0.5f, 0f, 0.5f), Color.magenta, Color.white, Color.green, new Color(0.5f, 0f, 0.5f) };
        colorSequences[26][1] = new Color[] { Color.blue, Color.yellow, new Color(0.5f, 0f, 0.5f), Color.white, Color.red, Color.black, Color.grey, Color.magenta, Color.red, Color.green };
        colorSequences[26][2] = new Color[] { new Color(0.5f, 0f, 0.5f), Color.black, Color.yellow, Color.blue, new Color(0.5f, 0f, 0.5f), Color.magenta, Color.grey, Color.red, Color.green, new Color(1f, 0.65f, 0f) };
        colorSequences[26][3] = new Color[] { Color.yellow, Color.red, new Color(1f, 0.65f, 0f), Color.white, Color.blue, Color.black, Color.magenta, Color.grey, new Color(0.5f, 0f, 0.5f), Color.green };
        colorSequences[26][4] = new Color[] { Color.black, Color.green, Color.yellow, new Color(0.5f, 0f, 0.5f), Color.white, Color.grey, Color.magenta, Color.blue, Color.green, Color.red };
        colorSequences[26][5] = new Color[] { Color.red, Color.blue, Color.green, Color.black, Color.yellow, Color.white, new Color(0.5f, 0f, 0.5f), Color.grey, Color.red, Color.green };
            colorSequences[26][6] = new Color[] { Color.magenta, Color.white, Color.red, Color.red, Color.blue, Color.red, Color.red, Color.grey, new Color(0.5f, 0f, 0.5f), new Color(1f, 0.65f, 0f) };
        colorSequences[26][7] = new Color[] { Color.green, Color.red, Color.yellow, new Color(1f, 0.65f, 0f), Color.black, Color.white, Color.grey, Color.magenta, Color.red, Color.green };
        colorSequences[26][8] = new Color[] { Color.red, Color.green, Color.black, Color.blue, Color.yellow, new Color(1f, 0.65f, 0f), new Color(0.5f, 0f, 0.5f), Color.grey, Color.green, Color.red };
        colorSequences[26][9] = new Color[] { Color.grey, Color.black, new Color(0.5f, 0f, 0.5f), Color.green, Color.blue, Color.yellow, Color.magenta, Color.white, Color.green, new Color(0.5f, 0f, 0.5f) };

        colorSequences[27] = new Color[10][];
        colorSequences[27][0] = new Color[] { new Color(1f, 0.65f, 0f), Color.black, Color.red, new Color(0.5f, 0f, 0.5f), Color.yellow, Color.white, Color.magenta, Color.grey, new Color(1f, 0.65f, 0f), new Color(1f, 0.65f, 0f) };
        colorSequences[27][1] = new Color[] { Color.red, Color.yellow, Color.green, new Color(1f, 0.65f, 0f), new Color(0.5f, 0f, 0.5f), Color.blue, Color.magenta, Color.grey, Color.green, Color.red };
        colorSequences[27][2] = new Color[] { Color.yellow, Color.red, Color.green, Color.blue, Color.black, Color.white, Color.magenta, Color.grey, Color.red, new Color(0.5f, 0f, 0.5f) };
        colorSequences[27][3] = new Color[] { Color.black, Color.green, Color.red, Color.magenta, Color.yellow, new Color(1f, 0.65f, 0f), Color.grey, Color.blue, Color.green, Color.red };
        colorSequences[27][4] = new Color[] { new Color(0.5f, 0f, 0.5f), new Color(0.5f, 0f, 0.5f), Color.black, Color.blue, Color.red, Color.yellow, Color.magenta, Color.grey, new Color(1f, 0.65f, 0f), Color.red };
        colorSequences[27][5] = new Color[] { Color.blue, Color.yellow, Color.red, new Color(1f, 0.65f, 0f), Color.green, new Color(0.5f, 0f, 0.5f), Color.grey, Color.white, new Color(1f, 0.65f, 0f), Color.green };
        colorSequences[27][6] = new Color[] { Color.grey, Color.red, Color.green, Color.black, new Color(0.5f, 0f, 0.5f), Color.yellow, Color.white, Color.magenta, Color.green, Color.red };
        colorSequences[27][7] = new Color[] { Color.red, Color.green, Color.black, Color.magenta, Color.blue, Color.yellow, Color.white, Color.grey, Color.green, new Color(0.5f, 0f, 0.5f) };
            colorSequences[27][8] = new Color[] { Color.green, new Color(0.5f, 0f, 0.5f), Color.red, Color.white, Color.red, Color.red, Color.blue, Color.grey, Color.red, new Color(1f, 0.65f, 0f) };
        colorSequences[27][9] = new Color[] { Color.black, new Color(1f, 0.65f, 0f), Color.yellow, Color.blue, Color.white, new Color(1f, 0.65f, 0f), Color.red, Color.grey, Color.green, Color.red };

        // color Sequence Orders
        colorSequenceOrders = new int[27][];

        colorSequenceOrders[0] = new int[] { 1, 2, 0, 3, 26,
            4, 25, 5, 24, 6, 23, 7, 22,
            8, 21, 9, 20, 10, 19, 11, 18,
            12, 17, 13, 16, 14, 15 };

        colorSequenceOrders[1] = new int[] { 16, 15, 17, 14, 18,
            13, 19, 12, 20, 11, 21, 10, 22,
            9, 23, 8, 24, 7, 25, 6, 26,
            5, 0, 4, 1, 3, 2 };

        colorSequenceOrders[2] = new int[] { 15, 14,  16,  13,  17,  12,
            18,  11,  19,  10,  20,  9,  21,
            8,   22,  7,   23,  6,   24,  5,   25,
            4,   26,  3,   0,   2,   1 };

        colorSequenceOrders[3] = new int[] { 2, 3, 1, 4, 0, 5,
            26, 6, 25, 7, 24, 8, 23, 9,
            22, 10, 21, 11, 20, 12, 19, 13,
            18, 14, 17, 15, 16 };

        colorSequenceOrders[4] = new int[] { 17, 16, 18, 15, 19,
            14, 20, 13, 21, 12, 22, 11, 23,
            10, 24, 9, 25, 8, 26, 7, 0,
            6, 1, 5, 2, 4, 3 };

        colorSequenceOrders[5] = new int[] { 4, 5, 3, 6, 2,
            7, 1, 8, 0, 9, 26, 10, 25,
            11, 24, 12, 23, 13, 22, 14, 21,
            15, 20, 16, 19, 17, 18 };

        colorSequenceOrders[6] = new int[] { 19, 18, 20, 17, 21,
            16, 22, 15, 23, 14, 24, 13, 25,
            12, 26, 11, 0, 10, 1, 9, 2,
            8, 3, 7, 4, 6, 5 };

        colorSequenceOrders[7] = new int[] { 6, 7, 5, 8, 4,
            9, 3, 10, 2, 11, 1, 12, 0,
            13, 26, 14, 25, 15, 24, 16, 23,
            17, 22, 18, 21, 19, 20 };

        colorSequenceOrders[8] = new int[] { 21, 20, 22, 19, 23,
            18, 24, 17, 25, 16, 26, 15, 0,
            14, 1, 13, 2, 12, 3, 11, 4,
            10, 5, 9, 6, 8, 7 };

        colorSequenceOrders[9] = new int[] { 8, 9, 7, 10, 6,
            11, 5, 12, 4, 13, 3, 14, 2,
            15, 1, 16, 0, 17, 26, 18, 25,
            19, 24, 20, 23, 21, 22 };

        colorSequenceOrders[10] = new int[] { 23, 22, 24, 21, 25,
            20, 26, 19, 0, 18, 1, 17, 2,
            16, 3, 15, 4, 14, 5, 13, 6,
            12, 7, 11, 8, 10, 9 };

        colorSequenceOrders[11] = new int[] { 10, 11, 9, 12, 8,
            13, 7, 14, 6, 15, 5, 16, 4,
            17, 3, 18, 2, 19, 1, 20, 0,
            21, 26, 22, 25, 23, 24 };

        colorSequenceOrders[12] = new int[] { 25, 24, 26, 23, 0,
            22, 1, 21, 2, 20, 3, 19, 4,
            18, 5, 17, 6, 16, 7, 15, 8,
            14, 9, 13, 10, 12, 11 };

        colorSequenceOrders[13] = new int[] { 12, 13, 11, 14, 10,
            15, 9, 16, 8, 17, 7, 18, 6,
            19, 5, 20, 4, 21, 3, 22, 2,
            23, 1, 24, 0, 25, 26 };

        colorSequenceOrders[14] = new int[] { 0, 26, 1, 25, 2,
            24, 3, 23, 4, 22, 5, 21, 6,
            20, 7, 19, 8, 18, 9, 17, 10,
            16, 11, 15, 12, 14, 13 };

        colorSequenceOrders[15] = new int[] { 14, 15, 13, 16, 12,
            17, 11, 18, 10, 19, 9, 20, 8,
            21, 7, 22, 6, 23, 5, 24, 4,
            25, 3, 26, 2, 0, 1 };

        colorSequenceOrders[16] = new int[] { 2, 1, 3, 0, 4,
            26, 5, 25, 6, 24, 7, 23, 8,
            22, 9, 21, 10, 20, 11, 19, 12,
            18, 13, 17, 14, 16, 15 };

        colorSequenceOrders[17] = new int[] { 16, 17, 15, 18, 14,
            19, 13, 20, 12, 21, 11, 22, 10,
            23, 9, 24, 8, 25, 7, 26, 6,
            0, 5, 1, 4, 2, 3 };

        colorSequenceOrders[18] = new int[] { 4, 3, 5, 2, 6,
            1, 7, 0, 8, 26, 9, 25, 10,
            24, 11, 23, 12, 22, 13, 21, 14,
            20, 15, 19, 16, 18, 17 };

        colorSequenceOrders[19] = new int[] { 18, 19, 17, 20, 16,
            21, 15, 22, 14, 23, 13, 24, 12,
            25, 11, 26, 10, 0, 9, 1, 8,
            2, 7, 3, 6, 4, 5 };

        colorSequenceOrders[20] = new int[] { 6, 5, 7, 4, 8,
            3, 9, 2, 10, 1, 11, 0, 12,
            26, 13, 25, 14, 24, 15, 23, 16,
            22, 17, 21, 18, 20, 19 };

        colorSequenceOrders[21] = new int[] { 20, 21, 19, 22, 18,
            23, 17, 24, 16, 25, 15, 26, 14,
            0, 13, 1, 12, 2, 11, 3, 10,
            4, 9, 5, 8, 6, 7 };

        colorSequenceOrders[22] = new int[] { 8, 7, 9, 6, 10,
            5, 11, 4, 12, 3, 13, 2, 14,
            1, 15, 0, 16, 26, 17, 25, 18,
            24, 19, 23, 20, 22, 21 };

        colorSequenceOrders[23] = new int[] { 22, 23, 21, 24, 20,
            25, 19, 26, 18, 0, 17, 1, 16,
            2, 15, 3, 14, 4, 13, 5, 12,
            6, 11, 7, 10, 8, 9 };

        colorSequenceOrders[24] = new int[] { 10, 9, 11, 8, 12,
            7, 13, 6, 14, 5, 15, 4, 16,
            3, 17, 2, 18, 1, 19, 0, 20,
            26, 21, 25, 22, 24, 23 };

        colorSequenceOrders[25] = new int[] { 24, 25, 23, 26, 22,
            0, 21, 1, 20, 2, 19, 3, 18,
            4, 17, 5, 16, 6, 15, 7, 14,
            8, 13, 9, 12, 10, 11 };

        colorSequenceOrders[26] = new int[] { 12, 11, 13, 10, 14,
            9, 15, 8, 16, 7, 17, 6, 18,
            5, 19, 4, 20, 3, 21, 2, 22,
            1, 23, 0, 24, 26, 25 };

    }

}
