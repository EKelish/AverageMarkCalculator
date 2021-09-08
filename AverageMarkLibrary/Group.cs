using System;
using System.Collections.Generic;

namespace AverageMarkLibrary
{
    public class Group
    {
        string name;
        List<Pupil> pupils = new List<Pupil>();
        public Group(string name)
        {
            this.name = name;
        }
        public string Name { get => name; set => name = value; }
        public List<Pupil> Pupils { get => pupils; set => pupils = value; }
    }
}
