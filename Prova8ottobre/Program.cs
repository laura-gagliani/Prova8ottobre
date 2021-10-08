using System;

namespace Prova8ottobre
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Benvenuto a Tombola!");
            bool playAgain = true;
            Console.ForegroundColor = ConsoleColor.White;

            do
            {
                int length = ChooseDifficulty();
                int userArDimension = ChooseNumAmount();

                int[] ar = RndArrayGen(length);
                int[] userAr = UserArray(userArDimension);

                Console.WriteLine("\nBene! I numeri che hai scelto sono:");
                for (int i = 0; i < userAr.Length; i++)
                {
                    Console.WriteLine(userAr[i]);
                }

                Console.WriteLine("\nI numeri estratti dalla tombola sono:");
                for (int j = 0; j < ar.Length; j++)
                {
                    Console.WriteLine(ar[j]);
                }

                int[] winsAr = Wins(userAr, ar, out int winsCount);

                Console.WriteLine($"\nI tuoi numeri vincenti sono:");
                for (int k = 0; k < winsAr.Length; k++)
                {
                    if (winsAr[k] != 0)
                    {
                        Console.WriteLine(winsAr[k]);
                    }

                }

                Console.WriteLine("\n" + Result(winsCount));

                Console.WriteLine("\nVuoi giocare di nuovo? Premi x per giocare ancora, qualsiasi altro tasto per chiudere");
                char agree = Console.ReadKey().KeyChar;
                Console.WriteLine("");
                if (agree != 'x')
                {
                    playAgain = false;
                }

            } while (playAgain);

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
        }  //crea e popola array di numeri estratti

        private static int ChooseDifficulty()
        {
            int length = 0;
            Console.WriteLine("\nScegli il livello di difficoltà:\n-facile\t\t(70 estrazioni)\n-medio\t\t(40 estrazioni)\n-difficile\t(20 estrazioni)\n");
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

        private static int ChooseNumAmount()
        {
            Console.WriteLine("\nVuoi giocare con 5 o con 15 numeri? Digita sotto il numero scelto");
            bool isSuccessful = int.TryParse(Console.ReadLine(), out int userArDimension);
            bool corretto = true;

            if (userArDimension != 5 && userArDimension != 15)
            {
                corretto = false;

            }


            while (!isSuccessful || !corretto)
            {
                Console.WriteLine("\nInserimento errato!");
                Console.WriteLine("Inserisci un numero corretto");
                isSuccessful = int.TryParse(Console.ReadLine(), out userArDimension);
                if (userArDimension == 5 || userArDimension == 15)
                {
                    corretto = true;

                }
            }


            return userArDimension;
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
                Console.WriteLine("Inserimento errato!");
                Console.WriteLine("Inserisci un numero corretto");
                isSuccessful = int.TryParse(Console.ReadLine(), out userNum);
                if (userNum > 0 && userNum < 91)
                {
                    limCorretti = true;

                }
            }


            return userNum;

        }           //controllo per UserArray

        private static int[] UserArray(int dimensUser)
        {

            int[] userArray = new int[dimensUser];


            Console.WriteLine($"\nInserisci {dimensUser} numeri interi da 1 a 90, estremi compresi");
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

        }       //crea e popola array con numeri inseriti dall'utente

        private static int[] Wins(int[] user, int[] ai, out int winsCount)
        {
            int[] userWinNums = new int[user.Length];
            winsCount = 0;
            bool found;
            int toCopy = 0;

            for (int i = 0; i < user.Length; i++)
            {
                found = false;

                for (int j = 0; j < ai.Length; j++)
                {
                    if (user[i] == ai[j])
                    {
                        found = true;
                        toCopy = ai[j];
                    }

                }

                if (found)
                {
                    userWinNums[winsCount] = toCopy;
                    winsCount++;
                }
            }

            return userWinNums;

        }       //rende array con numeri indovinati + contatore di numeri indovinati

        private static string Result(int winsCount)
        {
            string result = null;

            if (winsCount < 2)
            {
                result = "Hai perso...";
            }
            else if (winsCount == 2)
            {
                result = "Hai fatto ambo!";
            }
            else if (winsCount == 3)
            {
                result = "Hai fatto terno!";
            }
            else if (winsCount == 4)
            {
                result = "Hai fatto quaterna!";
            }
            else if (winsCount > 4 && winsCount < 15)
            {
                result = "Hai fatto cinquina!";
            }
            else if (winsCount == 15)
            {
                result = "Hai fatto tombola!";
            }

            return result;
        }   //stabilisce il risultato a seconda del contatore di numeri indovinati

    }
}
