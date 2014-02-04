using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SecretNumber.Model; 

namespace SecretNumber
{
    public partial class Default : System.Web.UI.Page
    {
        private Model.SecretNumber SecretNumberObj
        {
            get { return Session["Secretnumber"] as Model.SecretNumber; }
            set { Session["Secretnumber"] = value; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {}
        protected void GuessButton_Click(object sender, EventArgs e)
        {
            if (SecretNumberObj != null)
            {
                SecretNumberObj.MakeGuess(int.Parse(GuessTextBox.Text));
            }
            else
            {
                SecretNumberObj = new Model.SecretNumber();
                SecretNumberObj.MakeGuess(int.Parse(GuessTextBox.Text)); 
            }

            GuessedNumbersLiteral.Text = String.Format(GuessedNumbersLiteral.Text, String.Join(", ", SecretNumberObj.PreviousGuesses.ToArray())); 

            if (SecretNumberObj.CanMakeGuess)
            {
                OutputLiteral.Text = String.Format("{0}", SecretNumberObj.Outcome.ToString());
            }
            else
            {
                if (SecretNumberObj.Outcome == Outcome.Correct)
                {
                    OutputLiteral.Text = String.Format("Grattis du gissade rätt, {0} var det hemliga talet", SecretNumberObj.Number);
                }
                else
                {
                    OutputLiteral.Text = String.Format("Game Over {0} var det hemliga talet", SecretNumberObj.Number);
                }
                GuessButton.Text = "Starta om spelet";
                SecretNumberObj.Initialize();
            }
            OutputPanel.Visible = true;
        }
    }
}