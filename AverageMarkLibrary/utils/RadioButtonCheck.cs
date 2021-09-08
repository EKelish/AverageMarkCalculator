using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AverageMarkLibrary.utils
{
    static public class RadioButtonCheck
    {
        static private double count = 0;
        static public string RadioButtonChecking(Pupil pupil,Label label, RadioButton buttonAll, RadioButton buttonAverage, ComboBox boxSubject, bool mode = true)
        {
            if (mode)
            {
                label.Text = "";
                if (pupil.Marks.TryGetValue(boxSubject.Text, out List<byte> marks))
                {
                    if (buttonAll.Checked)
                    {
                        label.Text += $"{boxSubject.Text}:";
                        foreach (var mark in marks)
                            label.Text += $" {mark}";
                        label.Text += $".";
                        return label.Text;
                    }
                    else if (buttonAverage.Checked)
                    {
                        label.Text += $"{boxSubject.Text}:";
                        count = 0;
                        foreach (var mark in marks)
                            count += mark;
                        count = count / marks.Count;
                        label.Text += $" {Math.Round(count, 2)}.";
                        return label.Text;
                    }
                }
            }
            else
            {
                label.Text = "";
                if (buttonAll.Checked)
                {
                    foreach (var subject in pupil.Marks)
                    {
                        label.Text += $"{subject.Key}:";
                        foreach (var mark in subject.Value)
                            label.Text += $" {mark}";
                        label.Text += $".\n";
                    }
                    return label.Text;
                }
                else if (buttonAverage.Checked)
                {
                    foreach (var subject in pupil.Marks)
                    {
                        label.Text += $"{subject.Key}:";
                        count = 0;
                        foreach (var mark in subject.Value)
                            count += mark;
                        count = count / subject.Value.Count;
                        label.Text += $" {Math.Round(count, 2)}.\n";
                    }
                    return label.Text;
                }
            }
            return label.Text;
        }
    }
}
