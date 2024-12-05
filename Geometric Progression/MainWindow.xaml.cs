using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Geometric_Progression
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent(); 

        }

        private void btnInfoProgrammist_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Студентка группы ИСП-31 Лосева Анастасия", "О разработчике: ");
        }

        private void btnInfoProga_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Создать интерфейс – серия чисел.\r\nСоздать класс – геометрическая прогрессия.\r\nКласс должен включать конструктор.\r\n Сравнение производить по шагу прогрессии.", "О программе: ");
        }

        private void FillInTheRow1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int b = int.Parse(b1.Text); // Первый элемент ряда 1
                int q = int.Parse(q1.Text); // Множитель ряда 1
                int count = 10; // Количество элементов ряда

                TwoSeries progression1 = new TwoSeries(b, q); // Создаем объект ряда 1
                row1.Items.Clear();

                for (int i = 0; i < count; i++)
                {
                    row1.Items.Add(progression1.GetNext()); // Добавляем числа в ListBox
                }

                progression1.Reset(); // Сбрасываем прогрессию для повторного использования
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка ввода");
            }
        }

        // Кнопка для заполнения ряда 2
        private void FillInTheRow2_Click(object sender, EventArgs e)
        {
            try
            {
                int b = int.Parse(b2.Text); // Первый элемент ряда 2
                int q = int.Parse(q2.Text); // Множитель ряда 2
                int count = 10; // Количество элементов ряда

                TwoSeries progression2 = new TwoSeries(b, q); // Создаем объект ряда 2
                row2.Items.Clear();

                for (int i = 0; i < count; i++)
                {
                    row2.Items.Add(progression2.GetNext()); // Добавляем числа в ListBox
                }

                progression2.Reset(); // Сбрасываем прогрессию для повторного использования
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка ввода");
            }
        }

        // Кнопка очистки
        private void btnClean_Click(object sender, EventArgs e)
        {
            row1.Items.Clear();
            row2.Items.Clear();
            b1.Clear();
            b2.Clear();
            q1.Clear();
            q2.Clear();
            rez.Clear();
        }

        // Кнопка выхода
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Кнопка Сравнения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompareRows_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int value_b1 = int.Parse(b1.Text); // Первый элемент ряда 1
                int value_q1 = int.Parse(q1.Text);  // Множитель ряда 1
                int value_b2 = int.Parse(b2.Text); // Первый элемент ряда 2
                int value_q2 = int.Parse(q2.Text);  // Множитель ряда 2

                // Создание объектов класса Series
                Series series1 = new Series(value_b1, value_q1);
                Series series2 = new Series(value_b2, value_q2);

                // Вызов метода CompareTo из класса Series
                if (series1.CompareTo(series2) == 0)
                {
                    rez.Text = $"Шаг ряда 1 равен шагу ряда 2";
                }
                else if (series1.CompareTo(series2) == 1)
                {
                    rez.Text = "Шаг 1 ряда больше шага 2 ряда";
                }
                else if (series1.CompareTo(series2) == -1)
                {
                    rez.Text = "Шаг 2 ряда больше шага 1 ряда";
                }

            }
            catch (FormatException)
            {
                MessageBox.Show("Пожалуйста, введите корректные числовые значения.", "Ошибка ввода");
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("Ошибка при сравнении объектов. Убедитесь, что введены корректные данные.", "Ошибка");
            }
        }
    }
}