using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Character_Formatting
{
    public partial class Form1 : Form
    {
        Encoding ascii = Encoding.ASCII;
        Encoding unicode = Encoding.Unicode;
        List<int> offendingChars = new List<int>();

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private bool inList(List<int> list, int thing)
        {
            bool test = false;

            foreach (int item in list)
            {
                if (thing == item)
                {
                    return true;
                }
            }
            return test;
        }

        private void show_bad_chars()
        {
            textBox1.Text = "";
            bad_characters_output.Text = "";
            Console.Write(offendingChars.ToString());
            textBox1.Text = string.Join(", ", offendingChars.ToArray());
            
            for (int i = 0; i < input_box.Text.Length; i++)
            {
               if (inList(offendingChars, i))
                {
                    bad_characters_output.Text = bad_characters_output.Text + input_box.Text[i];
                }
               else
                {
                    bad_characters_output.Text = bad_characters_output.Text + " ";
                }
            }
        }

        private void input_box_TextChanged(object sender, EventArgs e)
        {
            //reset the strings so we can get them fresh each time
              string text_string = input_box.Text;
            //trim if checked
            if (trim_flag.Checked)
            {
                text_string = text_string.Trim();
            }
            offendingChars = new List<int>();
            output_box.Text = "";
            string output_string = "";

            byte[] asciiBytes = Encoding.ASCII.GetBytes(text_string);
            char[] chars = Encoding.ASCII.GetChars(asciiBytes);
            string line = new String(chars);

            int i = 0;
            

            foreach (var ch in line)
            {

                if (ch == 63)
                {
                    if (text_string[i] == '?')
                    {
                        //byte[] oneChar = new byte[ch];
                        output_string = output_string + ch;
                    }
                    else
                    {
                        //this char is unicode so store its index away for later
                        offendingChars.Add(i);
                    }
                }
                else
                {
                    //byte[] oneChar = new byte[ch];
                    output_string = output_string + ch;
                }

                //last thing
                i++;
            }
            if (trim_flag.Checked) {
                output_string = output_string.Trim();
            }
            output_box.Text = output_string;

            //Finally, show the bad characters
            show_bad_chars();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void trim_flag_CheckedChanged(object sender, EventArgs e)
        {
            if (trim_flag.Checked) {
                trim_flag.Text = "Will Trim";
            }
            else
            {
                trim_flag.Text = "Won't Trim";
            }
        }
    }
}
