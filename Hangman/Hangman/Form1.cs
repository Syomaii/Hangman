using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hangman
{
    public partial class Form1 : Form
    {
        private const int MaxGuess = 6;
        private string word;
        private char[] gword;
        private int wrongGuess;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGuess_Click(object sender, EventArgs e)
        {
            char letter = txtBoxGuessWord.Text[0];
            txtBoxGuessWord.Text = "";

            bool RightAns = false;
            for(int i = 0; i < word.Length; i++)
            {
                if (word[i] == letter)
                {
                    gword[i] = letter;
                    RightAns = true;
                }
            }
            if (RightAns)
            {
                if(new string(gword) == word)
                {
                    MessageBox.Show("YOU WIN!!!");
                }    
            }
            else
            {
                wrongGuess++;
                if(wrongGuess >= MaxGuess)
                {
                    MessageBox.Show($"You failed, the word is {word}");
                }
            }
            UpGuesses();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            word = lblWord.Text.ToLower();
            word = "Banana";
            gword = new char[word.Length];
            for(int i = 0; i<gword.Length; i++)
            {
                gword[i] = '*';
            }
            wrongGuess = 0;
            UpGuesses();
        }

        private void UpGuesses()
        {
            lblWord.Text = new string(gword);
            lblGuesses.Text = $"Incorrect guesses: {wrongGuess}/{MaxGuess}";
        }
    }
}
