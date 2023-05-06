using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовая_работа_2
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = Convert.ToInt32(Vvod("Введите число, которое необходимо перевести в двоичную систему счисления в пределе от -127 до 127 включительно: ", "int"));
            int[] r = new int[9];
            int i = 1;
            int num = n;
            if (num < 0)
            {
                num *= -1;
            }
            string result = "";
            while (num > 0)
            {
                result += (num % 2).ToString();
                num /= 2;
            }
            while (result.Length < 7)
            {
                result += "0";
            }
            if (n < 0)
            {
                result += "1";
            }
            else
            {
                result += "0";
            }
            result = new string(result.ToCharArray().Reverse().ToArray());
            if (n < 0)
            {
                Console.WriteLine($"Число {n} - отрицательное\nЗабираем число с положительным знаком, при этом первый бит выходного регистра будет 1.\nОЧ: Прибавляем значение к выходному регистру 00000000 + 10000000");
                n *= -1;
            }
            Console.WriteLine($"Число {n} подается на шину\nЗабираем число с шины.\nОЧ: проверка {n}>0?");
            while (n > 0)
            {
                r[0] = n;
                Console.WriteLine($"Ответ: true\nЧисло уходит на шину\nЗабираем число с шины\nУЧ: Записываем число в регистр R0\nЧисло уходит на шину\nЗабираем число с шины\nОЧ: остаток от деления {r[0]} mod 2");
                r[i] = r[0] % 2;
                Console.WriteLine($"Ответ: {r[i]}\nУЧ: Записываем число в регистр R{i}.\nУЧ: Чтение из регистра R0?\nЧисло уходит на шину\nЗабираем число с шины\nОЧ: делениe {r[0]} / 2");
                i++;
                r[0] = n / 2;
                n = r[0];
                Console.WriteLine($"Ответ: {r[0]}\nУЧ: Записываем число в регистр R0.\nЧисло уходит на шину\nЗабираем число с шины\nОЧ: проверка {n}>0?");
            }
            Console.WriteLine($"Ответ: false");
            for (int l = 1; l < 8; l++)
            {
                Console.WriteLine($"Содержимое регистра R{l} : 0000000{r[l]}");
            }
            Console.WriteLine($"По правилу умножим все ячейки на 2 в соответствующей степени и сложим результат и получим ответ");
            int j = 1;
            Console.WriteLine($"УЧ: Чтение из регистра R{j}\nОЧ: умножение 0000000{r[j]} * 1");
            if (r[j] == 0)
            {

                Console.WriteLine($"Результат: 00000000\nОЧ: Прибавляем значение к выходному регистру");
            }
            else
            {
                Console.WriteLine($"Результат: 00000001\nОЧ: Прибавляем значение к выходному регистру");
            }
            j++;
            Console.WriteLine($"УЧ: Чтение из регистра R{j}\nОЧ: умножение 0000000{r[j]} * 10");
            if (r[j] == 0)
            {
                Console.WriteLine($"Результат: 00000000\nОЧ: Прибавляем значение к выходному регистру");
            }
            else
            {
                Console.WriteLine($"Результат: 00000010\nОЧ: Прибавляем значение к выходному регистру");
            }
            j++;
            Console.WriteLine($"УЧ: Чтение из регистра R{j}\nОЧ: умножение 0000000{r[j]} * 100");
            if (r[j] == 0)
            {
                Console.WriteLine($"Результат: 00000000\nОЧ: Прибавляем значение к выходному регистру");
            }
            else
            {
                Console.WriteLine($"Результат: 00000100\nОЧ: Прибавляем значение к выходному регистру");
            }
            j++;
            Console.WriteLine($"УЧ: Чтение из регистра R{j}\nОЧ: умножение 0000000{r[j]} * 1000");
            if (r[j] == 0)
            {
                Console.WriteLine($"Результат: 00000000\nОЧ: Прибавляем значение к выходному регистру");
            }
            else
            {
                Console.WriteLine($"Результат: 00001000\nОЧ: Прибавляем значение к выходному регистру");
            }
            j++;
            Console.WriteLine($"УЧ: Чтение из регистра R{j}\nОЧ: умножение 0000000{r[j]} * 10000");
            if (r[j] == 0)
            {
                Console.WriteLine($"Результат: 00000000\nОЧ: Прибавляем значение к выходному регистру");
            }
            else
            {
                Console.WriteLine($"Результат: 00010000\nОЧ: Прибавляем значение к выходному регистру");
            }
            j++;
            Console.WriteLine($"УЧ: Чтение из регистра R{j}\nОЧ: умножение 0000000{r[j]} * 100000");
            if (r[j] == 0)
            {
                Console.WriteLine($"Результат: 00000000\nОЧ: Прибавляем значение к выходному регистру");
            }
            else
            {
                Console.WriteLine($"Результат: 00100000\nОЧ: Прибавляем значение к выходному регистру");
            }
            j++;
            Console.WriteLine($"УЧ: Чтение из регистра R{j}\nОЧ: умножение 0000000{r[j]} * 1000000");
            if (r[j] == 0)
            {
                Console.WriteLine($"Результат: 00000000\nОЧ: Прибавляем значение к выходному регистру");
            }
            else
            {
                Console.WriteLine($"Результат: 01000000\nОЧ: Прибавляем значение к выходному регистру");
            }
            Console.WriteLine($"Выходной регистр: {result} - искомое число в двоичной системе");
        }
        static string Vvod(string inf, string type)
        {
            bool ok1 = false;
            string itog = "";

            do
            {
                Console.Write($"{inf}");
                string temp = Console.ReadLine();
                switch (type)
                {
                    case ("int"):
                        {
                            int a;
                            ok1 = int.TryParse(temp, out a);
                            if (a > 127 || a < -127)
                            {
                                Console.WriteLine($"Неверный ввод!!! Введите число от -127 до 127.");
                                ok1 = false;
                            }
                            itog = a.ToString();
                        }
                        break;
                    case ("double"):
                        {
                            double a;
                            ok1 = double.TryParse(temp, out a);
                            itog = a.ToString();
                        }
                        break;
                    case ("string"):
                        {
                            itog = temp;
                            ok1 = true;
                        }
                        break;
                    case ("char"):
                        {
                            char a;
                            ok1 = char.TryParse(temp, out a);
                            itog = a.ToString();
                        }
                        break;
                }

            } while (!ok1);
            return itog;
        }
    }
}
