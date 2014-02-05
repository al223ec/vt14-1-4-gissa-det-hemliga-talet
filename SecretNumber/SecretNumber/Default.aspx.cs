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
            get { return Session["Secretnumber"] as Model.SecretNumber ?? (Model.SecretNumber)(Session["Secretnumber"] = new Model.SecretNumber()); }
            //The ?? operator is called the null-coalescing operator. It returns the left-hand operand if the operand is not null; otherwise it returns the right hand operand.
        }
        protected void Page_Load(object sender, EventArgs e){ }
        protected void GuessButton_Click(object sender, EventArgs e)
        {
            //Denna kontrollerar ifall session har gått ut, dvs användaren har väntat längre än 20 minuter. 
            //if (Session.IsNewSession)
            //{
            //    // Felmeddelande!!!
            //}

            if (IsValid)
            {
                SecretNumberObj.MakeGuess(int.Parse(GuessTextBox.Text));

                GuessedNumbersLiteral.Text = String.Format(GuessedNumbersLiteral.Text, String.Join(", ", SecretNumberObj.PreviousGuesses.ToArray()));

                if (SecretNumberObj.CanMakeGuess)
                {
                    OutputLiteral.Text = SecretNumberObj.Outcome.toTextString();
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
                    GuessButton.Enabled = false;
                    GuessTextBox.Enabled = false;
                    restartPanel.Visible = true; 
                }

                OutputPanel.Visible = true;
            }
        }
        protected void RestartButton_Click(object sender, EventArgs e)
        {
            SecretNumberObj.Initialize();
        }
    }
}