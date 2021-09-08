using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AverageMarkLibrary.utils;
using AverageMarkLibrary;
namespace AverageMarkCalculator
{
    public partial class FormStart : Form
    {
        Dictionary<string,Group> groups;
        Group group;
        Pupil pupil;
        public FormStart()
        {
            InitializeComponent();
            groups = FileSchool.Read();
            foreach (var group in groups.Keys)
            {
                comboBoxGroup.Items.Add(group);
            }
        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите закрыть программу?", "Закрытие программы", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Разработчик: Голубев Кирилл. Группа: 12-КД9-2ИСП", "Справка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void buttonContinue_Click(object sender, EventArgs e)
        {
            if (group != null && pupil != null)
            {
                FormResult formResult = new FormResult(pupil);
                formResult.Show();
            }
            else
            {
                if (group == null)
                {
                    MessageBox.Show("Не был выбран класс", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Не был выбран ученик", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void comboBoxGroup_SelectedIndexChanged(object sender, EventArgs e)
        {  
            comboBoxSurname.Items.Clear();
            comboBoxSurname.Text = "";
            if(groups.TryGetValue(comboBoxGroup.Text,out Group group))
            {
                pupil = null;
                this.group = group;
                foreach (var pupil in group.Pupils)
                {
                    comboBoxSurname.Items.Add(pupil.Surname);
                }
            }
        }

        private void comboBoxSurname_SelectedIndexChanged(object sender, EventArgs e)
        {
            pupil = group.Pupils[comboBoxSurname.SelectedIndex];
        }
    }
}
