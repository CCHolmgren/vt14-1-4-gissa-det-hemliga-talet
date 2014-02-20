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
            //If secretnumber is empty, then we create a new object
            if (Page.Session["secretnumber"] == null)
            {
                SecretNumber sn = new SecretNumber();
                Page.Session["secretnumber"] = sn;
            }
            //If it's not a postback then we got a GET request, and then we can just initiate a new SN and store it in the Page.Session
            /*if (!Page.IsPostBack)
            {
               SecretNumber sn = new SecretNumber();
                Page.Session["secretnumber"] = sn; 
            }*/
        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            //Focus the Guess input every time you click the GuessButton
            Guess.Focus();
            //We don't want a unhandeled exception so we check if it's valid inputs
            if(Page.IsValid)
            {
                //Page.Session["secretnumber"] stores our SecretNumber object in each session
                //This is so that we can keep guessing
                SecretNumber sn = (SecretNumber)Page.Session["secretnumber"];
                int guess = int.Parse(Guess.Text);
                Outcome outcome = sn.MakeGuess(guess);

                //sn.PreviousGuesses is a ReadOnlyCollection, which we loop over to get all previous guesses done
                foreach(int i in sn.PreviousGuesses)
                {
                    Resultat.Text += i.ToString() + ", ";
                }

                switch(outcome)
                {
                    case GissaHemligtTal.Outcome.High:
                        Resultat.Text += " För högt!";
                        break;
                    case GissaHemligtTal.Outcome.Low:
                        Resultat.Text += " För lågt!";
                        break;
                    case GissaHemligtTal.Outcome.PreviousGuess:
                        Resultat.Text += " Du har redan gissat det förut.";
                        break;
                    case GissaHemligtTal.Outcome.Correct:
                        Resultat.Text = "Rätt!";
                        GuessButton.Enabled = false;
                        Guess.Enabled = false;
                        PlaceHolder1.Visible = true;
                        Number.Text = "Numret var: " + sn.Number.Value.ToString();
                        ResetButton.Focus();
                        break;
                    case GissaHemligtTal.Outcome.NoMoreGuesses:
                        Resultat.Text = "Du har inga fler gissningar.";
                        GuessButton.Enabled = false;
                        Guess.Enabled = false;
                        PlaceHolder1.Visible = true;
                        Number.Text = "Numret var: " + sn.Number.Value;
                        ResetButton.Focus();
                        break;
                        //We should never get here
                        //But if we do, just redirect to the Error page
                    case GissaHemligtTal.Outcome.Indefinite:
                        Response.Redirect("Error.aspx");
                        /*Resultat.Text = "Something is broken";
                        GuessButton.Enabled = false;
                        ResetButton.Visible = true;*/
                        break;
                }
            }
            
        }
        /// <summary>
        /// Resets the input boxes and the button as it was from the start
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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