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

namespace TK_Testirovaniee
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// Главное окно приложения для расчета стоимости проезда
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Конструктор окна, загрузка данных
        /// Инициализирует компоненты главного окна приложения
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

        }
        /// <summary>
        /// Обработчик нажатия кнопки расчета стоимости билетов.
        /// Выполняет валидацию введенных данных, рассчитывает стоимость
        /// с учетом расстояния, количества билетов и коэффициента комфортабельности.
        /// </summary>
        /// <param name="sender">Источник события (кнопка "Рассчитать")</param>
        /// <param name="e">Аргументы события, содержащие данные о событии нажатия</param>
        private void Calculate_Click(object sender, RoutedEventArgs e)
            {
                try
                {
                    /// <summary>
                    /// Проверка корректности введенного расстояния.
                    /// Должно быть числовым значением больше или равным нулю.
                    /// </summary>
                    if (!double.TryParse(DistanceBox.Text, out double distance) || distance < 0)
                        {
                            ResultText.Text = "Ошибка: введите корректное расстояние!";
                            return;
                        }
                    /// <summary>
                    /// Проверка корректности введенного количества билетов.
                    /// Должно быть целым числом больше или равным нулю.
                    /// </summary>
                    if (!int.TryParse(TicketsBox.Text, out int tickets) || tickets < 0)
                        {
                            ResultText.Text = "Ошибка: введите корректное количество билетов!";
                            return;
                        }
                        /// <summary>
                        /// Вызов метода.
                        /// Получение коэффициента комфортабельности
                        /// на основе выбранного типа вагона.
                        /// </summary>
                        double coef = GetComfortCoefficient();

                        /// <summary>
                        /// Формула расчета: расстояние * 8 (базовый тариф) * коэффициент * количество билетов
                        /// </summary>
                        double result = distance * 8 * coef * tickets;

                        /// <summary>
                        /// Вывод результата с форматированием до двух знаков после запятой
                        /// </summary>
                        ResultText.Text = $"Стоимость билетов с учетом комфортабельности: {result:F2} руб.";
                    }
                    catch (Exception)
                    {
                        ResultText.Text = "Произошла ошибка!";
                    }
                }

        /// <summary>
        /// Определение коэффициента комфортабельности в зависимости от выбранного типа вагона.
        /// Коэффициенты: Плацкарт (по умолчанию) - 1.0, Купе - 1.1, Полулюкс - 1.2, Люкс - 1.3
        /// </summary>
        private double GetComfortCoefficient()
            {
                if (Coupe.IsChecked == true)
                    return 1.1;

                if (SemiLux.IsChecked == true)
                    return 1.2;

                if (Lux.IsChecked == true)
                    return 1.3;

                return 1.0;
            }
        }
    }