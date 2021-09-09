using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EpicSpiesChallenge
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Using a PostBack
            if (!Page.IsPostBack)
            {
                previousCalendar.SelectedDate = DateTime.Now.Date;
                newCalendar.SelectedDate = DateTime.Now.Date.AddDays(14);
                endCalendar.SelectedDate = DateTime.Now.Date.AddDays(21);
            }
        }

        protected void assignSpyButton_Click(object sender, EventArgs e)
        {
            // Using DateTime and TimeSpan
            // Spies cost $500 per day
            TimeSpan totalDurationOfAssignment = endCalendar.SelectedDate.Subtract(newCalendar.SelectedDate);
            double totalCost = totalDurationOfAssignment.TotalDays * 500.0;

            // Conditional Statements
            // If > 21 days, then add $1000
            if (totalDurationOfAssignment.TotalDays > 21)
            {
                totalCost = totalCost + 1000.0;
            }

            // Message to display in result once spy is assigned
            resultLabel.Text = String.Format("Assignment of {0} to assignment of {1} is authorized. Budget total: {2:C}", 
                codeNameTextBox.Text, 
                assignmentNameTextBox.Text, 
                totalCost);

            // Timespan rule in order to allow 2 weeks of vacation
            TimeSpan timeBetweenAssignments = newCalendar.SelectedDate.Subtract(previousCalendar.SelectedDate);
                if (timeBetweenAssignments.TotalDays < 14)
            {
                resultLabel.Text = "Error: Must allow at least two weeks between previous assignment and new assignment.";

                DateTime earliestNewAssignmentDate = previousCalendar.SelectedDate.AddDays(14);

                newCalendar.SelectedDate = earliestNewAssignmentDate;
                newCalendar.VisibleDate = earliestNewAssignmentDate;
            }


        }
    }
}