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
            //If it's not a postback then we got a GET request, and then we can just initiate a new SN and store it in the Page.Session
            if (!Page.IsPostBack)
            {
                SecretNumber sn = new SecretNumber();
                Page.Session["secretnumber"] = sn;
            }
        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            Guess.Focus();
            if(Page.IsValid)
            {
                SecretNumber sn = (SecretNumber)Page.Session["secretnumber"];
                int guess = int.Parse(Guess.Text);
                Outcome outcome = sn.MakeGuess(guess);

                foreach(int i in sn.PreviousGuesses)
                {
                    Resultat.Text += i.ToString() + ", ";
                }

                switch(outcome)
                {
                    case GissaHemligtTal.Outcome.High:
                        Resultat.Text += " Too high! ";
                        break;
                    case GissaHemligtTal.Outcome.Correct:
                        Resultat.Text = "Correct!";
                        GuessButton.Enabled = false;
                        //ResetButton.Visible = true;
                        Guess.Enabled = false;
                        PlaceHolder1.Visible = true;
                        Number.Text = "The number is " + sn.Number.Value.ToString();
                        break;
                    case GissaHemligtTal.Outcome.Low:
                        Resultat.Text += " Too low!";
                        break;
                    case GissaHemligtTal.Outcome.NoMoreGuesses:
                        Resultat.Text = "You got no more guesses";
                        GuessButton.Enabled = false;
                        //ResetButton.Visible = true;
                        Guess.Enabled = false;
                        PlaceHolder1.Visible = true;
                        Number.Text = "Numret är " + sn.Number.Value;
                        break;
                    case GissaHemligtTal.Outcome.PreviousGuess:
                        Resultat.Text += " You've already guessed that before";
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
            //Reset the Secretnumber stored in Page.Session
            ((SecretNumber)Page.Session["secretnumber"]).Initialize();
            PlaceHolder1.Visible = false;
            //Remove the button we don't want
            //ResetButton.Visible = false;
            GuessButton.Enabled = true;
            //Reset the text values
            Guess.Text = "";
            Resultat.Text = "Resultat";
            Number.Text = "Number";
        }
    }
}