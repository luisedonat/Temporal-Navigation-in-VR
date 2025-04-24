using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSequenceRandom : MonoBehaviour
{
    public Color[][][] colorSequencesRandom = new Color[9][][];

    // Start is called before the first frame update
    void Start()
    {
        // Define base colors
        Color[] baseColors = new Color[]
        {
            Color.yellow, Color.green, Color.blue, Color.magenta, Color.grey, Color.black, Color.white, new Color(1f, 0.65f, 0f), new Color(0.5f, 0f, 0.5f), Color.red
        };

        // Initialize color sequences
        for (int i = 0; i < 9; i++)
        {
            colorSequencesRandom[i] = new Color[10][];
            // HashSet to track red ball index --> only one subsequence has exactly 4 red balls
            HashSet<int> redIndices = new HashSet<int>();

            // 4 red balls for exactly one subsequence: 
            int randomIndex = Random.Range(0, 10);
            colorSequencesRandom[i][randomIndex] = new Color[] 
            {
                Color.red, Color.red, Color.red, Color.red,
                baseColors[(i + 0) % baseColors.Length],
                baseColors[(i + 1) % baseColors.Length],
                baseColors[(i + 2) % baseColors.Length],
                baseColors[(i + 3) % baseColors.Length],
                baseColors[(i + 4) % baseColors.Length],
                baseColors[(i + 5) % baseColors.Length]
            };
            redIndices.Add(randomIndex);


            for (int j = 0; j < 10; j++)
            {
                if (!redIndices.Contains(j))
                {
                    colorSequencesRandom[i][j] = new Color[10];
                    int redCount = 0;
                    for (int k = 0; k < 10; k++)
                    {
                        colorSequencesRandom[i][j][k] = baseColors[(i + j + k) % baseColors.Length];
                        if (colorSequencesRandom[i][j][k] == Color.red)
                        {
                            redCount++;
                        }
                    }

                    // Ensure no other sequence has exactly 4 red balls
                    while (redCount == 4)
                    {
                        redCount = 0;
                        for (int k = 0; k < 10; k++)
                        {
                            colorSequencesRandom[i][j][k] = baseColors[(i + j + k + 1) % baseColors.Length];
                            if (colorSequencesRandom[i][j][k] == Color.red)
                            {
                                redCount++;
                            }
                        }
                    }
                }
                
            }
            
        }
    }
}
