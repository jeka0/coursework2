using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using BusinessLayer;
using DataAccessLayer;

namespace ServiceLayer
{
    public class ApplicationWork
    {
        public static void AddNewElement(String login,ref TextBox Old, ref int index, Panel Screen, String DateStr, String TimeStr, String Categories, String Comment, String Amount, String file, bool Flag)
        {
            Point point = new Point(0, index);
            if (Old != null) Screen.ScrollControlIntoView(Old);
            TextBox[] textBoxes = new TextBox[5];
            for (int i = 0; i < 5; i++)
            {
                textBoxes[i] = new TextBox();
                textBoxes[i].BackColor = Color.FromArgb(45, 45, 48);
                textBoxes[i].ForeColor = Color.White;
                textBoxes[i].Font = new Font(textBoxes[i].Font.Name, 11, textBoxes[i].Font.Style, textBoxes[i].Font.Unit);
                textBoxes[i].BorderStyle = BorderStyle.FixedSingle;
                textBoxes[i].ReadOnly = true;
                switch (i)
                {
                    case 0: textBoxes[i].Size = new Size(97, 24); point.X = 17; textBoxes[i].Text = DateStr; break;
                    case 1: textBoxes[i].Size = new Size(97, 24); point.X = 120; textBoxes[i].Text = TimeStr; break;
                    case 2: textBoxes[i].Size = new Size(165, 24); point.X = 223; textBoxes[i].Text = Categories; break;
                    case 3: textBoxes[i].Size = new Size(291, 24); point.X = 394; textBoxes[i].Text = Comment; break;
                    case 4: textBoxes[i].Size = new Size(115, 24); point.X = 691; textBoxes[i].Text = Amount + " руб."; break;
                }
                textBoxes[i].Location = point;
                Screen.Controls.Add(textBoxes[i]);
            }
            Screen.ScrollControlIntoView(textBoxes[0]);
            if (Flag) Database.AddElementInFile(file, login, DateStr, TimeStr, Categories, Comment, Amount);
            Old = textBoxes[0];
            if (index < 430) index += 30; else if (index == 430) index += 13;
        }

        public static void AddElementFromFile(String file, String login,ref TextBox old, ref int index, Panel screen)
        {
            List<String> elements = Database.ReadAllFile("Data/" + login + '/' + file + ".txt");
            foreach(String element in elements)
            {
                String[] strElement = element.Split('|');
                AddNewElement(login, ref old, ref index, screen, strElement[0], strElement[1], strElement[2], strElement[3], strElement[4], file,false);
            }
        }

        public static bool CheckCategories(String categorie, ComboBox categories)
        {
            bool Flag = false;
            for (int i = 0; i < categories.Items.Count; i++)
            {
                if (categorie == categories.Items[i].ToString()) { Flag = true; break; }
            }
            return Flag;
        }
    }
}
