namespace Lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Решение квадратного уравнения");
            string line;

            try
            {
                StreamReader stream = new StreamReader("C:\\Users\\Артём\\OneDrive\\Рабочий стол\\Тестирование и отладка программного обеспечения\\Git\\Lab_2\\Квадратное уравнение.txt");
                line = stream.ReadLine();
                stream.Close();

                double a; // 1 переменная
                double b; // 2 переменная
                double c; // 3 переменная
                double x1; // 1 корень уравнения
                double x2; // 2 корень уравнения

                double[] numbers = line.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
                a = numbers[0];
                b = numbers[1];
                c = numbers[2];
                Console.WriteLine("Коэффициент a - " + a);
                Console.WriteLine("Коэффициент b - " + b);
                Console.WriteLine("Коэффициент c - " + c);

                double Discriminant; // Дискриминант
                Discriminant = Math.Pow(b, 2) - 4 * a * c;
                Console.WriteLine("Дискриминант = " + Discriminant);

                if (Discriminant < 0)
                {
                    throw new DiscriminantLessZero();
                }

                if (Discriminant == 0)
                {
                    x1 = -b / (2 * a);
                    throw new DiscriminantDravZero("Корень уравнения x1 = " + x1);
                }

                x1 = (-b + Math.Sqrt(Discriminant)) / (2 * a);
                x2 = (-b - Math.Sqrt(Discriminant)) / (2 * a);
                Console.WriteLine("Корень уравнения x1 = " + x1);
                Console.WriteLine("Корень уравнения x2 = " + x2);               
            }
            catch (FileNotFoundException e) // Файл отсутствует
            {
                Console.WriteLine("Обнаружена ошибка: Файл не был найден. \n" + e.Message);
            }
            catch (FormatException e) // Переменные отличны от чисел
            {
                Console.WriteLine("Обнаружена ошибка: Не все коэфициенты являются числами. \n" + e.Message);
            }
            catch (DiscriminantLessZero e) // Дискриминант меньше нуля
            {
                Console.WriteLine("Обнаружена ошибка: Дискриминант меньше нуля - Уравнение не имеет решения.");
            }
            catch (DiscriminantDravZero e) // Дискриминант равен нулю
            {
                Console.WriteLine($"Дискриминант равен нулю - Уравнение имеет одно решение. \n" + e.Message);
            }
            finally
            {
                Console.WriteLine("Конец программы");
            }
            Console.ReadLine();
        }
    }

    class DiscriminantDravZero : Exception
    {
        public DiscriminantDravZero(string? message) : base(message)
        {
        }
    }

    class DiscriminantLessZero : Exception
    {

    }

}
