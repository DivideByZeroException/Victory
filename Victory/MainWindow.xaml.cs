using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Victory
{
    public partial class MainWindow : Window
    {
        public string data2 ;
        public List<Button> buttons;
        
        public MainWindow()
        {
            InitializeComponent();
            buttons = new List<Button>();
            Button_Click(new Button(),new RoutedEventArgs());

        }
        private void LabelEdit(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;

            Otvet.Content = Otvet.Content + btn.Content.ToString();
            btn.IsEnabled = false;
            buttons.Add(btn);
            if(Otvet.Content.ToString() == data2)
            {
                MessageBox.Show("Вы победили");
                Otvet.Content = "";
                buttons.Clear();
                Question.Content = "";
                for (int i = 0; i < 10; i++)
                {
                    ButtonGrid1.Children.RemoveAt(0);
                    ButtonGrid2.Children.RemoveAt(0);
                    ButtonGrid3.Children.RemoveAt(0);
                    ButtonGrid4.Children.RemoveAt(0);
                }
                Button_Click(sender,e);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Otvet.Content = "";
            buttons.Clear();
            Question.Content = "";
            if (ButtonGrid1.Children.Count != 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    ButtonGrid1.Children.RemoveAt(0);
                    ButtonGrid2.Children.RemoveAt(0);
                    ButtonGrid3.Children.RemoveAt(0);
                    ButtonGrid4.Children.RemoveAt(0);
                }
            }
            Random rnd = new Random();
            var a = Database.GetAll();
            int value = rnd.Next(0, a.Count);
            string data = a[value].Vopr;
            string quest = a[value].Otvet;
            Question.Content = quest;
            data2 = data.ToUpper();
            char[] letters = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ".ToCharArray();
            Random rand = new Random();

            string word = "";
            for (int j = 1; j <= 40-data.Length; j++)
            {
                int letter_num = rand.Next(0, letters.Length - 1);
                word += letters[letter_num];
            }
            data += word;
            data = data.ToUpper();
            var datarand = data.ToCharArray();
            
            Random random = new Random();
            for (int i = datarand.Length - 1; i >= 1; i--)
            {
                int j = random.Next(i + 1);

                var temp = datarand[j];
                datarand[j] = datarand[i];
                datarand[i] = temp;
            }
            int line = 1;
            for (int i = 0; i < datarand.Length; i++)
            {
                var button = new Button
                {
                    Name = "button" + i,
                    Content = datarand[i],
                    Width = 20,
                    Height = 20,
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Left
                };
                button.Click += new RoutedEventHandler(LabelEdit);
                if (line == 1) { 
                    this.ButtonGrid1.Children.Add(button);
                    line = 2;
                }
                else if (line == 2)
                {
                    this.ButtonGrid2.Children.Add(button);
                    line = 3;
                }
                else if (line == 3)
                {
                    this.ButtonGrid3.Children.Add(button);
                    line = 4;
                }
                else if (line == 4)
                {
                    this.ButtonGrid4.Children.Add(button);
                    line = 1;
                }
            }    
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (buttons.Count != 0)
            {
                
                buttons.Last().IsEnabled = true;
                Otvet.Content = Otvet.Content.ToString().TrimEnd(Convert.ToChar(buttons.Last().Content.ToString()));
                buttons.RemoveAt(buttons.Count - 1);
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Database.AddToDB(new QuestionsAndAnswers(V.Text, O.Text));
            V.Text = "";
            O.Text = "";
        }
    }
}
