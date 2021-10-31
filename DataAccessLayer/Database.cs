using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace DataAccessLayer
{
    class Database
    {
        public static String[] ReadNameFromFile(String Login)
        {
            StreamReader read = new StreamReader("Data/" + Login + '/' + Login + ".txt");
            for (int i = 0; i < 2; i++) read.ReadLine();
            String[] Mas = read.ReadLine().Split();
            read.Close();
            return Mas;
        }

        public static void AddElementInFile(String File, String Login, String Date, String Time, String Categories, String Comment, String Amount)
        {
            StreamWriter write = new StreamWriter("Data/" + Login + '/' + File + ".txt", true);
            write.WriteLine(Date + '|' + Time + '|' + Categories + '|' + Comment + '|' + Amount);
            write.Close();
        }

        public static void FileCheck(ref bool same, ref bool err, ref bool Tpass, TextBox login, TextBox pass)
        {
            StreamReader Read = new StreamReader("Data/accounts.txt");
            while (!Read.EndOfStream)
            {
                string str = Read.ReadLine();
                string[] StrMas = str.Split();
                if (StrMas.Length != 2 || StrMas[1] == "") { err = true; break; }
                if (StrMas[0] == login.Text) { same = true; if (StrMas[1] == pass.Text) Tpass = true; break; }
            }
            Read.Close();
        }

        public static void CreateNewUser(String login, String pass, String Name, String Name2)
        {
            StreamWriter Write = new StreamWriter("Data/accounts.txt", true);
            Write.WriteLine(login + ' ' + pass);
            Write.Close();
            Directory.CreateDirectory("Data/" + login);
            WriteUserData(login, pass, Name, Name2,true);
            File.Create("Data/" + login + "/Expenses.txt").Close();
            File.Create("Data/" + login + "/Income.txt").Close();
            File.Create("Data/" + login + "/Months.txt").Close();
        }

        public static void WriteUserData(String login, String pass, String Name, String Name2,bool flag=false)
        {
            StreamWriter WR = new StreamWriter("Data/" + login + '/' + login + ".txt");
            WR.WriteLine(login);
            WR.WriteLine(pass);
            WR.WriteLine(Name + ' ' + Name2);
            if (flag)
            {
                WR.WriteLine("Общее");
                WR.WriteLine("Общее");
            }
            WR.Close();
        }

        public static void WriteNewCategorie(String login, ComboBox categories)
        {
            StringBuilder categorie = new StringBuilder();
            for (int i=0; i<categories.Items.Count;i++)
            {
                categorie.Append(categories.Items[i]);
                if(i!= categories.Items.Count-1) categorie.Append('|');
            }
            StreamWriter WR = new StreamWriter("Data/" + login + '/' + login + ".txt",true);
            WR.WriteLine(categorie);
            WR.Close();
        }
        public static bool IsFileEmpty(String login, String File)
        {
            bool Flag = true;
            StreamReader read = new StreamReader("Data/" + login + '/' + File + ".txt");
            if (!read.EndOfStream) Flag = false;
            read.Close();
            return Flag;
        }

        public static List<String> ReadAllFile(String File)
        {
            List<String> elements = new List<string>();
            StreamReader read = new StreamReader(File);
            while (!read.EndOfStream)
            {
                elements.Add(read.ReadLine());
            }
            read.Close();
            return elements;

        }

        public static void ReadCategoriesFromFile(String login ,ComboBox categories, ComboBox categories2)
        {
            StreamReader read = new StreamReader("Data/" + login + '/' + login + ".txt");
            int i = 0;
            while (!read.EndOfStream)
            {
                if (i == 3) categories.Items.AddRange(read.ReadLine().Split('|'));
                else if (i == 4) categories2.Items.AddRange(read.ReadLine().Split('|'));
                else read.ReadLine();
                i++;
            }
            read.Close();
        }
    }
}
