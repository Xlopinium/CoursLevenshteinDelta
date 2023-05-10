using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DotnetNoise;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LevenshteinDistance
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //trying realese perlinnoise on backgrond
        public class PerlinNoiseTexture
        {
            public static System.Drawing.Bitmap GenerateTexture(int width, int height)
            {
                System.Drawing.Color color1 = System.Drawing.Color.FromArgb(227, 229, 252);
                System.Drawing.Color color2 = System.Drawing.Color.FromArgb(252, 247, 227);
                FastNoise dotnetNoise = new FastNoise();
                //SetNoiseType Default: OpenSimplex2
                //Frequncy Default 0.01 sorce: documtation

                System.Drawing.Bitmap texture = new System.Drawing.Bitmap(width, height);

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        float noiseValue = dotnetNoise.GetNoise(x, y);
                        int colorValue;

                        if (noiseValue < -0.5f)
                        {
                            colorValue = (int)(255 * (1 - (noiseValue + 0.2f) / 0.2f));
                            if (colorValue < 0) colorValue = 0;
                        }
                        else if (noiseValue < 0.2f)
                        {
                            colorValue = 122;
                        }
                        else
                        {
                            colorValue = (int)(180 * (1 - (noiseValue - 0.2f) / 0.8f));
                            if (colorValue < 0) colorValue = 0;
                        }

                        System.Drawing.Color color;

                        if (x < width / 2) // first half of texture
                        {
                            float t = (float)x / (width / 2);
                            int r = (int)(color1.R * (1 - t) + color2.R * t);
                            int g = (int)(color1.G * (1 - t) + color2.G * t);
                            int b = (int)(color1.B * (1 - t) + color2.B * t);
                            color = System.Drawing.Color.FromArgb(r, g, b);
                        }
                        else // second half of texture
                        {
                            // calculate t as the relative position of the current pixel in the second half of the texture
                            float t = (float)(x - (width / 2)) / (width / 2);

                            // interpolate between color2 and color1 based on t
                            int r = (int)(color2.R * (1 - t) + color1.R * t);
                            int g = (int)(color2.G * (1 - t) + color1.G * t);
                            int b = (int)(color2.B * (1 - t) + color1.B * t);
                            color = System.Drawing.Color.FromArgb(r, g, b);
                        }

                        texture.SetPixel(x, y, color);
                    }
                }

                return texture;
            }
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            string str1 = firstStringTextBox.Text;
            string str2 = secondStringTextBox.Text;

            int distance = CalculateLevenshteinDistance(str1, str2);

            distanceLabel.Text = $"Levenshtein distance: {distance}";

            List<string> operations = GetLevenshteinOperations(str1, str2);
            operationsListBox.Items.Clear();
            operationsListBox.Items.AddRange(operations.ToArray());
        }

        //let's define implementation of the Levenshtein algorithm for calculating the editing distance
        private int CalculateLevenshteinDistance(string str1, string str2)
        {
            //Define the ultimate level of the register
            str1 = str1.ToLower();
            str2 = str2.ToLower();

            //array realese
            int[,] matrix = new int[str1.Length + 1, str2.Length + 1];
            //The first column of the array is filled in
            for (int i = 0; i <= str1.Length; i++)
            {
                matrix[i, 0] = i;
            }
            
            for (int j = 0; j <= str2.Length; j++)
            {
                matrix[0, j] = j;
            }
            //The value in each cell of the array is calculated
            for (int i = 1; i <= str1.Length; i++)
            {
                for (int j = 1; j <= str2.Length; j++)
                {
                    int cost = (str1[i - 1] == str2[j - 1]) ? 0 : 1;

                    matrix[i, j] = Math.Min(Math.Min(matrix[i - 1, j] + 1, matrix[i, j - 1] + 1), matrix[i - 1, j - 1] + cost);
                }
            }
            //trying to make an egg
            //if (str1.ToLower() == "нтирандекура")
            //{
            //    distanceLabel.Text = "The creator";
           // }
           // else
           // {
           //     distanceLabel.Text = "";
           // }

            return matrix[str1.Length, str2.Length];
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Place the button in the center of the form
            CalculateButton.Left = (this.ClientSize.Width - CalculateButton.Width) / 2;
            CalculateButton.Top = (this.ClientSize.Height - CalculateButton.Height) / 2;

            // Place the TextBox1 text field in the center of the form
            firstStringTextBox.Left = (this.ClientSize.Width - firstStringTextBox.Width) / 2;
            firstStringTextBox.Top = (this.ClientSize.Height - firstStringTextBox.Height) / 2 - 50;

            // Place the TextBox2 text field in the center of the form
            secondStringTextBox.Left = (this.ClientSize.Width - secondStringTextBox.Width) / 2;
            secondStringTextBox.Top = (this.ClientSize.Height - secondStringTextBox.Height) / 2 + 50;

            // Place Label location regarding of TextBox2
            distanceLabel.Location = new Point(secondStringTextBox.Location.X, secondStringTextBox.Location.Y + secondStringTextBox.Height + 10);



            // Generate a Perlin noise texture with a width and height of 800 pixels
            Bitmap texture = PerlinNoiseTexture.GenerateTexture(500, 400);

            // Set the background image of the form to the generated texture
            BackgroundImage = texture;

        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CalculateButton_Click(sender, e);
            }
        }

        private List<string> GetLevenshteinOperations(string str1, string str2)
        {
            //Define the ultimate level of the register
            str1 = str1.ToLower();
            str2 = str2.ToLower();
            //Initialization of variables and data structures:
            List<string> operations = new List<string>();
            int[,] matrix = new int[str1.Length + 1, str2.Length + 1];

            //filling of array cells
            for (int i = 0; i <= str1.Length; i++)
            {
                matrix[i, 0] = i;
            }

            for (int j = 0; j <= str2.Length; j++)
            {
                matrix[0, j] = j;
            }

            for (int i = 1; i <= str1.Length; i++)
            {
                for (int j = 1; j <= str2.Length; j++)
                {
                    int cost = (str1[i - 1] == str2[j - 1]) ? 0 : 1;

                    int deletion = matrix[i - 1, j] + 1;
                    int insertion = matrix[i, j - 1] + 1;
                    int substitution = matrix[i - 1, j - 1] + cost;

                    matrix[i, j] = Math.Min(Math.Min(deletion, insertion), substitution);
                }
            }
            //Building a list of operations required for string
            int row = str1.Length;
            int col = str2.Length;

            while (row > 0 || col > 0)
            {
                if (row > 0 && matrix[row - 1, col] + 1 == matrix[row, col])
                {
                    operations.Insert(0, $"Delete '{str1[row - 1]}' from position {row - 1}");
                    row--;
                }
                else if (col > 0 && matrix[row, col - 1] + 1 == matrix[row, col])
                {
                    operations.Insert(0, $"Insert '{str2[col - 1]}' at position {row}");
                    col--;
                }
                else
                {
                    if (row > 0 && col > 0 && matrix[row - 1, col - 1] + (str1[row - 1] == str2[col - 1] ? 0 : 1) == matrix[row, col])
                    {
                        if (str1[row - 1] != str2[col - 1])
                        {
                            operations.Insert(0, $"Substitute '{str1[row - 1]}' with '{str2[col - 1]}' at position {row - 1}");
                        }

                        row--;
                        col--;
                    }
                    else
                    {
                        throw new Exception("Unexpected error in Levenshtein Distance calculation");
                    }
                }
            }
            return operations;
        }
    }
}
