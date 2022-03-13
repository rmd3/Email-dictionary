using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Microsoft.VisualBasic;
using System.Web.Script.Serialization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D_Anjolell_9_10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Dictionary<string, string> emailDictionary = new Dictionary<string, string>();

        private void btnExit_Click(object sender, EventArgs e)
        {
            //Closes the program
            this.Close();
        }

        private void btnLkUp_Click(object sender, EventArgs e)
        {
            //Richard D'Anjolell
            //Try catch statement if there is an error accessing the file
            try
            {
                //Declare Variables
                string emailerName;
                string fileLine;
                StreamReader emailFile;

                //Open dictionary file
                emailFile = File.OpenText("..\\..\\emailDictionary.txt");

                int indexNum = 0;
                while (!emailFile.EndOfStream) 
                {
                    fileLine = emailFile.ReadLine();
                    string[] fileSplit = fileLine.Split(' ');
                    emailDictionary.Add(fileSplit[indexNum], fileSplit[indexNum+1]);
                    indexNum += 2;
                }

                emailerName = txtName.Text;

                if (emailDictionary.ContainsKey(emailerName))
                {
                    string outOfStock = emailerName + "'s email is " + emailDictionary[emailerName];
                    string windowTitle = "Email Lookup";
                    MessageBox.Show(outOfStock, windowTitle);
                }

                else 
                {
                    string outOfStock = emailerName + " has no entry in this dictionary.";
                    string windowTitle = "Email Lookup";
                    MessageBox.Show(outOfStock, windowTitle);
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string emailerName = txtName.Text;
            string newEmail;
            newEmail = Interaction.InputBox("Enter the email address:", "Email Creator", "");
            emailDictionary.Add(emailerName, newEmail);
            string outOfStock = emailerName + " and their email has been added to the dictionary.";
            string windowTitle = "Email Created";
            MessageBox.Show(outOfStock, windowTitle);
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            //Try catch statement if there is an error accessing the file
            try
            {
                //Declare Variables
                string emailerName;
                string changedEmail;
                string fileLine;
                StreamReader emailFile;

                //Open dictionary file
                emailFile = File.OpenText("..\\..\\emailDictionary.txt");

                int indexNum = 0;
                while (!emailFile.EndOfStream)
                {
                    fileLine = emailFile.ReadLine();
                    string[] fileSplit = fileLine.Split(' ');
                    emailDictionary.Add(fileSplit[indexNum], fileSplit[indexNum + 1]);
                    indexNum += 2;
                }

                emailerName = txtName.Text;

                if (emailDictionary.ContainsKey(emailerName))
                {
                    changedEmail = Interaction.InputBox("Enter their new email address:", "Email Changer", "");
                    emailDictionary[emailerName] = changedEmail;
                    string outOfStock = emailerName + "'s email has been changed.";
                    string windowTitle = "Email Changer";
                    MessageBox.Show(outOfStock, windowTitle);
                }

                else
                {
                    string outOfStock = emailerName + " has no entry in this dictionary.";
                    string windowTitle = "Email Changer";
                    MessageBox.Show(outOfStock, windowTitle);
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Try catch statement if there is an error accessing the file
            try
            {
                //Declare Variables
                string emailerName;
                string fileLine;
                StreamReader emailFile;

                //Open dictionary file
                emailFile = File.OpenText("..\\..\\emailDictionary.txt");

                int indexNum = 0;
                while (!emailFile.EndOfStream)
                {
                    fileLine = emailFile.ReadLine();
                    string[] fileSplit = fileLine.Split(' ');
                    emailDictionary.Add(fileSplit[indexNum], fileSplit[indexNum + 1]);
                    indexNum += 2;
                }

                emailerName = txtName.Text;

                if (emailDictionary.ContainsKey(emailerName))
                {
                    emailDictionary.Remove(emailerName);
                    string outOfStock = emailerName + " and their email has been deleted from the dictionary.";
                    string windowTitle = "Email Deleter";
                    MessageBox.Show(outOfStock, windowTitle);
                }

                else
                {
                    string outOfStock = emailerName + " has no entry in this dictionary.";
                    string windowTitle = "Email Deleter";
                    MessageBox.Show(outOfStock, windowTitle);
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
