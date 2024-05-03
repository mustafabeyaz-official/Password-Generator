namespace PasswordEngine
{
    internal class Program
    {
        //declare global varibales
        static List<char> charContainer = new List<char>();
        static List<string> passwordContainer = new List<string>();
        static char[] customization = new char[4];
        static void Main(string[] args)
        {
            Console.WriteLine("STRONG PASSWORD GENERATOR");

            int index = 1;

            //get password customization details
            getRequestCustomization();

            //fill charContainer
            fillContainer();

            //get production details and start production
            getProductionDetails();

            //output the passwords
            Console.Clear();
            foreach (var item in passwordContainer)
            {
                Console.WriteLine($"{index}. password: {item}");
                index++;
            }
            Console.Write("\n\npress any key to close app");
            Console.ReadKey();
        }
        static void getRequestCustomization()
        {
            string input = "";

            do
            {
                Console.Write("\nadd lowercase characters (yes[y] no[n]): ");
                input = Console.ReadLine()!.ToLower();

                try
                {
                    if ((input[0] == 'y' || input[0] == 'n') && input.Length == 1)
                    {
                        customization[0] = input[0];
                        break;
                    }
                    Console.Write("\ninput is invalid!\n");
                }
                catch
                {
                    Console.Write("\ninput is invalid!\n");
                }
            }
            while (true);
            /*********************************************************************/
            do
            {
                Console.Write("\nadd uppercase characters (yes[y] no[n]): ");
                input = Console.ReadLine()!.ToLower();

                try
                {
                    if ((input[0] == 'y' || input[0] == 'n') && input.Length == 1)
                    {
                        customization[1] = input[0];
                        break;
                    }
                    Console.Write("\ninput is invalid!\n");
                }
                catch
                {
                    Console.Write("\ninput is invalid!\n");
                }
            }
            while (true);
            /*********************************************************************/
            do
            {
                Console.Write("\nadd numeric characters (yes[y] no[n]): ");
                input = Console.ReadLine()!.ToLower();

                try
                {
                    if ((input[0] == 'y' || input[0] == 'n') && input.Length == 1)
                    {
                        customization[2] = input[0];
                        break;
                    }
                    Console.Write("\ninput is invalid!\n");
                }
                catch
                {
                    Console.Write("\ninput is invalid!\n");
                }
            }
            while (true);
            /*********************************************************************/
            do
            {
                Console.Write("\nadd special characters (yes[y] no[n]): ");
                input = Console.ReadLine()!.ToLower();

                try
                {
                    if ((input[0] == 'y' || input[0] == 'n') && input.Length == 1)
                    {
                        customization[3] = input[0];
                        break;
                    }
                    Console.Write("\ninput is invalid!\n");
                }
                catch
                {
                    Console.Write("\ninput is invalid!\n");
                }
            }
            while (true);
        }
        static void fillContainer()
        {
            int counter = 0;
            foreach (var item in customization)
            {
                switch (counter)
                {
                    case 0:
                        if (item == 'y')
                        {
                            charContainer.AddRange(['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z']);
                        }
                        counter++;
                        break;
                    case 1:
                        if (item == 'y')
                        {
                            charContainer.AddRange(['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z']);
                        }
                        counter++;
                        break;
                    case 2:
                        if (item == 'y')
                        {
                            charContainer.AddRange(['1', '2', '3', '4', '5', '6', '7', '8', '9', '0']);
                        }
                        counter++;
                        break;
                    case 3:
                        if (item == 'y')
                        {
                            charContainer.AddRange(['~', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '|', '<', '>', '?', ':', '"', '{', '}']);
                            charContainer.AddRange(['`', '-', '=', '\\', ',', '.', '/', ';', '\'', '[', ']']);
                        }
                        counter++;
                        break;
                }
            }
        }
        static void getProductionDetails()
        {
            string input;
            byte demand, length;

            Console.Clear();

            do
            {
                Console.WriteLine($"how many password required? (limit: {Byte.MaxValue})");
                input = Console.ReadLine()!;

                try
                {
                    demand = Convert.ToByte(input);
                    break;
                }
                catch
                {
                    Console.Write("\ninput is invalid or out of limit! ");
                }
            }
            while (true);
            /*********************************************************************************/
            Console.WriteLine();
            do
            {
                Console.WriteLine($"what should be password length (limit: {Byte.MaxValue})");
                input = Console.ReadLine()!;

                try
                {
                    length = Convert.ToByte(input);
                    break;
                }
                catch
                {
                    Console.Write("\ninput is invalid or out of limit! ");
                }
            }
            while (true);

            productPassword(demand, length);
        }
        static void productPassword(byte demand, byte length)
        {
            string output;
            int entity = charContainer.Count;
            Random rand = new Random();

            for (byte i = 0; i < demand; i++)
            {
                output = "";

                for (byte j = 0; j < length; j++)
                {
                    output += charContainer[rand.Next(entity)];
                }

                passwordContainer.Add(output);
            }
        }
    }
}
