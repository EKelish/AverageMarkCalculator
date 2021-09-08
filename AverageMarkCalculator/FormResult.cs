using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AverageMarkLibrary;
using AverageMarkLibrary.utils;

namespace AverageMarkCalculator
{
    public partial class FormResult : Form
    {

        Pupil pupil;
        List<byte> marks;
        double count = 0;
        public FormResult(Pupil pupil)
        {
            this.pupil = pupil;
            InitializeComponent();
            labelSubject.Text = "";
            comboBoxSubject.Items.Add("Общий");
            foreach (var subject in pupil.Marks.Keys)
            {
                comboBoxSubject.Items.Add(subject);
                comboBoxSubject.SelectedIndex = 0;
            }
        }
        private void comboBoxSubject_SelectedIndexChanged(object sender, EventArgs e)/////////////
        {
            RadioButtonCheck.RadioButtonChecking(pupil, labelSubject, radioButtonAll, radioButtonAverage, comboBoxSubject, !comboBoxSubject.SelectedItem.Equals("Общий"));
        }

        private void radioButtonAll_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxSubject_SelectedIndexChanged(sender, e);
        }
        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
