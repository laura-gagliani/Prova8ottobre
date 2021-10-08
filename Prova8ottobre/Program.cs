using System;

namespace Prova8ottobre
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int[] ar = RndArrayGen(70);

            int[] userAr = UserArray(5);

            Console.WriteLine("\nBene! I numeri che hai scelto sono:");
            for (int i = 0; i < userAr.Length; i++)
            {
                Console.WriteLine(userAr[i]);
            }

            //Console.WriteLine(userAr.Length);
        }

        private static int[] RndArrayGen(int dimensArray)
        {
            int[] rndArray = new int[dimensArray];

            Random rndGen = new Random();
            int rndNum = rndGen.Next(1, 91); //genero il primo num
            rndArray[0] = rndNum;              //e lo metto in pos. 0
            bool doppione;
            int nextPosition = 1;

            while (nextPosition != dimensArray)
            {
                doppione = false;
                rndNum = rndGen.Next(1, 91);

                for (int i = 0; i < nextPosition; i++)
                {
                    if (rndArray[i] == rndNum)
                    {
                        doppione = true;
                    }

                }
                if (!doppione)
                {
                    rndArray[nextPosition] = rndNum;
                    nextPosition++;
                }
            }

            return rndArray;
        }


        private static int ChoseDifficulty()
        {
            int length = 0;

            string difficulty = Console.ReadLine();
            bool correct = false;

            if (difficulty == "facile" || difficulty == "medio" || difficulty == "difficile")
            {
                correct = true;
            }
            while (!correct)
            {
                Console.WriteLine("\n Errore! Risposta non valida. Inserire di nuovo");
                difficulty = Console.ReadLine();
                if (difficulty == "facile" || difficulty == "medio" || difficulty == "difficile")
                {
                    correct = true;
                }
            }

            switch (difficulty)
            {
                case "facile":
                    {
                        length = 70;
                    }
                    break;

                case "medio":
                    {
                        length = 40;
                    }
                    break;

                case "difficile":
                    {
                        length = 20;
                    }
                    break;

            }

            return length;
        }

        private static int VerificaInserimento()
        {
            bool isSuccessful = int.TryParse(Console.ReadLine(), out int userNum);
            bool limCorretti = true;

            if (userNum < 1 || userNum > 90)
            {
                limCorretti = false;

            }


            while (!isSuccessful || !limCorretti)
            {
                Console.WriteLine("Inserimento Errato");
                Console.WriteLine("Reinserisci il numero");
                isSuccessful = int.TryParse(Console.ReadLine(), out userNum);
                if (userNum > 0 && userNum < 91)
                {
                    limCorretti = true;

                }
            }


            return userNum;

        }

        private static int[] UserArray(int dimensUser)
        {
            //dimensUser = 5;
            int[] userArray = new int[dimensUser];


            Console.WriteLine("\nInserisci un numero intero da 1 a 90 compresi");
            int userNum = VerificaInserimento();

            userArray[0] = userNum;

            bool doppione;
            int nextPosition = 1;

            while (nextPosition != dimensUser)
            {
                doppione = false;
                userNum = VerificaInserimento();

                for (int i = 0; i < nextPosition; i++)
                {
                    if (userArray[i] == userNum)
                    {
                        doppione = true;
                        Console.WriteLine("Errore! Hai già inserito questo numero");
                    }

                }
                if (!doppione)
                {
                    userArray[nextPosition] = userNum;
                    nextPosition++;
                }
            }

            return userArray;

        }

        private static int[] Wins(int[] user, int[] ai, out int winsCount)
        {
            int[] userWinNums = new int[user.Length];
            winsCount = 0;
            bool found;

            for (int i = 0; i < user.Length; i++)
            {
                found = false;

                for (int j = 0; j < ai.Length; j++)
                {
                    if (user[i] == ai[j])
                    {
                        found = true;

                    }
                    if (found)
                    {
                        userWinNums[winsCount] = ai[j];
                        winsCount++;
                    }
                }

            }




            return userWinNums;

        }
    }
}
