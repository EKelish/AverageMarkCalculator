using System;
using System.Collections.Generic;
using System.IO;

namespace AverageMarkLibrary.utils
{
    static public class FileSchool
    {
        static public Dictionary<string, Group> Read()
        {
            Dictionary<string, Group> groups = new Dictionary<string, Group>();
            foreach (var directory in Directory.GetDirectories(@"Files"))
            {
                Group group = new Group(directory.Split('\\')[1]);
                groups.Add(group.Name, group);
                foreach (var file in Directory.GetFiles(directory, "*.txt"))
                {
                    string[] lines = File.ReadAllLines(file);
                    Pupil pupil = new Pupil(lines[0]);
                    group.Pupils.Add(pupil);
                    for (int i = 1; i < lines.Length; i++)
                    {
                        pupil.AddMarks(lines[i]);
                    }
                }
            }
            return groups;
        } 
    }
}
