/*!
	\brief Класс хронящий в себе все операции калькулятора
*/
public class Calculator
{
    /*!
	\brief Метод сложения 
*/
    public double Sum(double firstNumber, double secondNumber)
    {
        return firstNumber + secondNumber;
    }
/*!
	\brief Метод умножения 
*/
    public double Multi(double firstNumber, double secondNumber)
    {
        return firstNumber * secondNumber;
    }
/*!
	\brief Метод вычитания
*/
    public double Sub(double firstNumber, double secondNumber)
    {
        return firstNumber - secondNumber;
    }
/*!
	\brief Метод деления 
    */
    public double Div(double firstNumber, double secondNumber)
    {
        if (secondNumber == 0)
        {
            throw new DivideByZeroException();
        }
        return firstNumber / secondNumber;
    }
}


/*!
	\brief Класс являющий входом в приложение 
*/
public class Program
{

/*!
	\brief Метод вызывающий экземпляр класса 
*/
    static void Main()
    {
        Calculator cal = new Calculator();
        Input(cal);
    }

/*!
	\brief Метод запрашивающий и обробатывающий запросы пользователя 
*/
    public static void Input(Calculator cal)
    {
        bool con = true;

        while (con)
        {
            double result = 0;

            try
            {
                Console.WriteLine("Введите 1 число");
                double firstNumber = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Введите 2 число");
                double secondNumber = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Выбирите операцию (+, *, -, /)");
                string operation = Console.ReadLine();

                if (operation == "+")
                {
                    result = cal.Sum(firstNumber, secondNumber);
                }
                else if (operation == "*")
                {
                    result = cal.Multi(firstNumber, secondNumber);
                }
                else if (operation == "-")
                {
                    result = cal.Sub(firstNumber, secondNumber);
                }
                else if (operation == "/")
                {
                    result = cal.Div(firstNumber, secondNumber);
                }
                else
                {
                    Console.WriteLine("Неизвестный оператор");
                }

                Console.WriteLine("Результат: " + result);
                
                Console.WriteLine("Продолжить? (Да/Нет)");
                string answer = Console.ReadLine();
                if (answer.ToLower() != "Да")
                {
                    Console.WriteLine("Очистить? (Да/Нет)");
                    answer = Console.ReadLine();
                    if (answer.ToLower() == "Да")
                    {
                        Console.Clear();
                        continue;
                    }
                    con = false;
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Error: Attempted to divide by zero");
            }
        }
    }
}
