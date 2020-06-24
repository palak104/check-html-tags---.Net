// Palak Depani, 000787449
// Date - 15 November 2019
// I, Palak depani, student no 000787449, cerify that all code submitted is my own work;that i have not copied from any other source .
//I also certify that i have not allowed my work to be copied by other
// purpose - it check for inserted html file tags , like all tags are closed or not and diplay the result


using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4B

{

    /// <summary>
    /// this is form code for input tags and validated it 
    /// </summary>
    public partial class Form1 : Form
    {

        // creating stack for input file
        Stack htmlFile = new Stack();
        Stack noTagsFile = new Stack();


        /// <summary>
        /// initialize the form components
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Stack to find all HTML tags 
        /// </summary>
        /// <returns></returns>
        private static object Stack()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// this load file tool menu allow users to load file from computer drive
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void loadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // this openFileDialog and allow html file for input
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "HTML files (*.html)|*.html";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;


            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // declare htmlName variable to save the file
                string htmlName;

                // this file object reads the inserted file 
                StreamReader file = new StreamReader(openFileDialog.FileName);
                fileLabel.Text = openFileDialog.SafeFileName;
                openFileDialog.RestoreDirectory = true;

                // check for null 
                while ((htmlName = file.ReadLine()) != null)
                {
                    htmlFile.Push(htmlName);
                }

                // this close the insert file application
                file.Close();
            }
        }

       

        /// <summary>
        /// Check HTML tags option to check whether all tags are completed with opening and closing tags in the loaded file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkHTMLTagsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // tags which are not ging to check we insert them in array
            string noTags = "img hr br";
            string[] noTagsplit = noTags.Split(' ');
            foreach (string noTagslist in noTagsplit)
            {
                noTagsFile.Push(noTagslist);
            }

            // this check that does it has closing tag at the end of the file or not
            Stack htmlBelowTag = new Stack();

            do
            {
                htmlBelowTag.Push(htmlFile.Pop());
            } while (htmlFile.Count != 0);

            // this one check tag stack for tags
            Stack tagsCheck = new Stack();
            foreach (string codeInLine in htmlBelowTag)
            {
                string[] openBrackets = codeInLine.Split('<');
                foreach (string code in openBrackets)
                {
                    if (code.Contains('>'))
                    {
                        string[] code2 = code.Split('>');
                        if (noTags.Contains(code2[0]))
                        {
                            string[] codeClass = code2[0].Split(' ');
                            // display not contained tags
                            listBox.Items.Add("Non-container tags found: <" + code2[0] + ">");
                        }
                        else if (code2[0].Contains(" "))
                        {
                            string[] codeClass = code2[0].Split(' ');
                            if (!noTags.Contains(codeClass[0]))
                            {

                                //this display all the opening tags of file
                                listBox.Items.Add("Opening tags found: <" + codeClass[0] + ">");
                                tagsCheck.Push(codeClass[0].ToLower());
                            }
                            else
                            {

                                //this display all the not contained tags of file
                                listBox.Items.Add("Non-container tags found: <" + codeClass[0] + ">");
                            }
                        }
                        else if (code2[0].Contains("/"))
                        {
                            string[] codeClass = code2[0].Split('/');
                            // display the closing tags
                            listBox.Items.Add("Closing tags found: </" + codeClass[1] + ">");
                            if (codeClass[1].ToLower() == (string)tagsCheck.Peek())
                            {
                                tagsCheck.Pop();
                            }
                        }
                        else
                        {
                            // display the opening tags of file
                            listBox.Items.Add("opening tags found: <" + code2[0] + ">");
                            tagsCheck.Push(code2[0].ToLower());
                        }

                    }
                }
            }

            // display conclusion after checking file
            if (tagsCheck.Count <= 0)
            {
                // Display the result if all tags are balanced
                fileLabel.Text += " has balanced tags";
            }
            else
            {
                // Display the result if tags are not balanced
                fileLabel.Text += " has not all balanced tags";
            }
        }

        /// <summary>
        /// exit menu option to close application 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

