using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GissaHemligtTal;

namespace GissaHemligtTal
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SecretNumber sn = new SecretNumber();
                Page.Session["secretnumber"] = sn;
            }
        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                int guess = int.Parse(Guess.Text);
                Outcome outcome = ((SecretNumber)Page.Session["secretnumber"]).MakeGuess(guess);
                Resultat.Text += outcome.ToString();
                //Number.Text += ((SecretNumber)Page.Session["secretnumber"]).Number;
                switch(outcome)
                {
                    case GissaHemligtTal.Outcome.High:
                        Resultat.Text += "Too high! ";
                        break;
                    case GissaHemligtTal.Outcome.Correct:
                        Resultat.Text = "Correct!";
                        GuessButton.Enabled = false;
                        ResetButton.Visible = true;
                        Number.Text = "Numret är " + ((SecretNumber)Page.Session["secretnumber"]).Number.ToString();
                        break;
                    case GissaHemligtTal.Outcome.Low:
                        Resultat.Text += "Too low!";
                        break;
                    case GissaHemligtTal.Outcome.NoMoreGuesses:
                        Resultat.Text = "You got no more guesses";
                        GuessButton.Enabled = false;
                        ResetButton.Visible = true;
                        Number.Text = "Numret är " + ((SecretNumber)Page.Session["secretnumber"]).Number.ToString();
                        break;
                    case GissaHemligtTal.Outcome.PreviosuGuess:
                        Resultat.Text += "You've already guessed that before";
                        break;
                    case GissaHemligtTal.Outcome.Indefinite:
                        Resultat.Text = "Something is broken, blame Tyler";
                        GuessButton.Enabled = false;
                        ResetButton.Visible = true;
                        break;

                }
            }
            
        }

        protected void ResetButton_Click(object sender, EventArgs e)
        {
            ((SecretNumber)Page.Session["secretnumber"]).Initialize();
            ResetButton.Visible = false;
            GuessButton.Enabled = true;
            Guess.Text = "";
            Resultat.Text = "Resultat";
            Number.Text = "Number";
        }
    }
}