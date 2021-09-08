using System;
using System.Collections.Generic;
using AverageMarkLibrary;

namespace AverageMarkLibrary
{
    public class Pupil
    {
        string surname;
        Dictionary<string, List<byte>> marks = new Dictionary<string, List<byte>>();

        public Pupil(string surname)
        {
            this.surname = surname;
        }
        public string Surname { get => surname; set => surname = value; }
        public Dictionary<string, List<byte>> Marks { get => marks; set => marks = value; }

        public void AddMarks(string line)
        {
            var lineSplit = line.Split(' ');
            List<byte> marksbyte = new List<byte>();
            foreach (var mark in lineSplit[1].Split(','))
                marksbyte.Add(Byte.Parse(mark));
            this.marks.Add(lineSplit[0], marksbyte);
        }
    }
}
