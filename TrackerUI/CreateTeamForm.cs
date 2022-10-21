using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class CreateTeamForm : Form
    {
        private List<PersonModel> availableTeamMembers = GlobalConfig.Connection.GetPerson_All();
        private List<PersonModel> selectedTeamMembers = new List<PersonModel>();

        public CreateTeamForm()
        {
            InitializeComponent();

            //CreateSampleData(); // TODO - Delete

            WireUpLists();
        }

        /// <summary>
        /// Wire up the dropdown list and list box
        /// </summary>
        private void WireUpLists()
        {
            // "refresh" the datasource so the dropdown reflects changes from addMemberButton click
            selectMemberDropdown.DataSource = null; // TODO - this seems wonky. Is there a better way to do it?

            selectMemberDropdown.DataSource = availableTeamMembers;
            selectMemberDropdown.DisplayMember = "FullName";

            // "refresh" the datasource so the listbox reflects changes from addMemberButton click
            teamMembersListbox.DataSource = null; // TODO - this seems wonky. Is there a better way to do it?

            teamMembersListbox.DataSource = selectedTeamMembers;
            teamMembersListbox.DisplayMember = "FullName";
        }

        // TODO - Delete this - creates sample data for testing
        private void CreateSampleData()
        {
            availableTeamMembers.Add(new PersonModel { FirstName = "Marshall", LastName = "Harris" });
            availableTeamMembers.Add(new PersonModel { FirstName = "Krystle", LastName = "Berry" });
            availableTeamMembers.Add(new PersonModel { FirstName = "Asha", LastName = "Harris" });

            selectedTeamMembers.Add(new PersonModel { FirstName = "Captain", LastName = "America" });
            selectedTeamMembers.Add(new PersonModel { FirstName = "The", LastName = "Hulk" });
            selectedTeamMembers.Add(new PersonModel { FirstName = "Iron", LastName = "Man" });
        }

        private void createMemberButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PersonModel p = new PersonModel();
                
                // Set properties of PersonalModel
                p.FirstName = firstNameValue.Text;
                p.LastName = lastNameValue.Text;
                p.EmailAddress = emailValue.Text;
                p.CellphoneNumber = cellphoneValue.Text;

                // Save to database or text file
                GlobalConfig.Connection.CreatePerson(p);

                // Clear form fields
                firstNameValue.Text = "";
                lastNameValue.Text = "";
                emailValue.Text = "";
                cellphoneValue.Text = "";
            }
            else
            {
                MessageBox.Show("Please fill in all the fields.");
            }
        }

        private bool ValidateForm()
        {
            // TODO - Add validation to the form
            if(firstNameValue.Text.Length == 0)
            {
                return false;
            }

            if (lastNameValue.Text.Length == 0)
            {
                return false;
            }

            if (emailValue.Text.Length == 0)
            {
                return false;
            }

            if (cellphoneValue.Text.Length == 0)
            {
                return false;
            }

            return true;
        }

        private void addMemberButton_Click(object sender, EventArgs e)
        {
            PersonModel p = (PersonModel)selectMemberDropdown.SelectedItem;

            availableTeamMembers.Remove(p);
            selectedTeamMembers.Add(p);

            WireUpLists(); 
        }

        private void removeSelectedMemberButton_Click(object sender, EventArgs e)
        {
            PersonModel p = (PersonModel)teamMembersListbox.SelectedItem;

            selectedTeamMembers.Remove(p);
            availableTeamMembers.Add(p);

            WireUpLists(); 
        }
    }
}
