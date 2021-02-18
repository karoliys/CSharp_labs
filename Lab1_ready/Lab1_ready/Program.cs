using System;

namespace Lab1_ready
{
    class Players
    {
        private static int[][] _polegame = new int[3][];
        private static int hod = 1;
        public static void Pole()
        {
            // Pole
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("     0   1   2");


            for (int Stb = 0; Stb < 3; Stb++)
            {

                Console.Write(Stb + "| |");


                for (int line = 0; line < 3; line++)
                {

                    Console.Write(" " + Players.PlayerType(line, Stb) + " ");
                    Console.Write("|");

                }

                Console.WriteLine();
            }

        }
        public static void CheckGame() { // Check Win of oponent
            int endGame = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int k = 0; k < 3; k++)
                {
                    if (_polegame[i][k] == 0)
                    {
                        endGame++;
                    }
                    
                }
            }
            if (endGame == 0)
            {
                StartResetGame();
            }
            for (int i = 0; i < 3; i++)
            {
                if (_polegame[i][0] != 0 && _polegame[i][0] == _polegame[i][1] && _polegame[i][1] == _polegame[i][2])
                {
                    
                    Console.WriteLine("Player " + _polegame[i][1] + " Win!");
                    Console.ReadKey();
                    StartResetGame();
                }
                else if (_polegame[0][i] != 0 && _polegame[0][i] == _polegame[1][i] && _polegame[1][i] == _polegame[2][i])
                {
                   
                    Console.WriteLine("Player " + _polegame[0][i] + " Win!");
                    Console.ReadKey();
                    StartResetGame();
                }
                else if (_polegame[0][0] != 0 && _polegame[0][0] == _polegame[1][1] && _polegame[1][1] == _polegame[2][2])
                {
                    
                    Console.WriteLine("Player " + _polegame[0][0] + " Win!");
                    Console.ReadKey();
                    StartResetGame();
                }
                else if (_polegame[0][2] != 0 && _polegame[0][2] == _polegame[1][1] && _polegame[1][1] == _polegame[2][0])
                {
                   
                    Console.WriteLine("Player " + _polegame[0][2] + " Win!");
                    Console.ReadKey();
                    StartResetGame();
                }
            }
            
        }
        private static void _SetType(int stb, int str) // sdelat' hod
        {
            if (_polegame[stb][str] == 0)
            {
                _polegame[stb][str] = hod;
                switch (hod)
                {
                    case 1: hod = 2; break;

                    default:
                        hod = 1;
                        break;
                }
            }

        }
        private static void _CheckMove(ref int skip) { // hod for win
            for (int k = 0; k < 3; k++) 
            {
                if (_polegame[k][0] == 2 && _polegame[k][1] == 2 && _polegame[k][2] == 0)// win po gorizontali
                {
                    _SetType(k, 2);
                    skip = 1;
                    break;
                }
                else if (_polegame[k][0] == 2 && _polegame[k][2] == 2 && _polegame[k][1] == 0)
                {
                    _SetType(k, 1);
                    skip = 1;
                    break;
                }
                else if (_polegame[k][1] == 2 && _polegame[k][2] == 2 && _polegame[k][0] == 0)
                {
                    _SetType(k, 0);
                    skip = 1;
                    break;
                }
                if (_polegame[0][k] == 2 && _polegame[1][k] == 2 && _polegame[2][k] == 0) // Win po verticali
                {
                    _SetType(2, k);
                    skip = 1;
                    break;
                }
                else if (_polegame[0][k] == 2 && _polegame[2][k] == 2 && _polegame[1][k] == 0)
                {
                    _SetType(1, k);
                    skip = 1;
                    break;
                }
                else if (_polegame[1][k] == 2 && _polegame[2][k] == 2 && _polegame[0][k] == 0)
                {
                    _SetType(0, k);
                    skip = 1;
                    break;
                }
                if (_polegame[0+k][0] == 2 && _polegame[1][1] == 2 && _polegame[2-k][2] == 0) // Win po diagonali
                {
                    _SetType(2-k, 2);
                    skip = 1;
                    break;
                }
                else if (_polegame[0 + k][0] == 0 && _polegame[1][1] == 2 && _polegame[2 - k][2] == 2)
                {
                    _SetType(0+k, 0);
                    skip = 1;
                    break;
                }
            }
            
           
        }
        private static void _CheckEnemyMove(ref int skip) // poisk zahit
        {
            for (int k = 0; k < 3; k++) 
            {
                if (_polegame[k][0] == 1 && _polegame[k][1] == 1 && _polegame[k][2] == 0)// Zashita po gorizontali
                {
                    _SetType(k, 2);
                    skip = 1;
                    break;
                }
                else if (_polegame[k][0] == 1 && _polegame[k][2] == 1 && _polegame[k][1] == 0)
                {
                    _SetType(k, 1);
                    skip = 1;
                    break;
                }
                else if (_polegame[k][1] == 1 && _polegame[k][2] == 1 && _polegame[k][0] == 0)
                {
                    _SetType(k, 0);
                    skip = 1;
                    break;
                }
                if (_polegame[0][k] == 1 && _polegame[1][k] == 1 && _polegame[2][k] == 0)// Zashita po vertikali
                {
                    _SetType(2, k);
                    skip = 1;
                    break;
                }
                else if (_polegame[0][k] == 1 && _polegame[2][k] == 1 && _polegame[1][k] == 0)
                {
                    _SetType(1, k);
                    skip = 1;
                    break;
                }
                else if (_polegame[1][k] == 1 && _polegame[2][k] == 1 && _polegame[0][k] == 0)
                {
                    _SetType(0, k);
                    skip = 1;
                    break;
                }
                if (_polegame[0 + k][0] == 1 && _polegame[1][1] == 1 && _polegame[2 - k][2] == 0) // Zashita po diagonali
                {
                    _SetType(2 - k, 2);
                    skip = 1;
                    break;
                }
                else if (_polegame[0 + k][0] == 0 && _polegame[1][1] == 1 && _polegame[2 - k][2] == 1)
                {
                    _SetType(0 + k, 0);
                    skip = 1;
                    break;
                }
            }
           


        }
        private static void _GameBot() //skript hoda bota
        {
            int skip = 0;
            _CheckMove(ref skip);
            
            if (skip == 1)
            {
                skip = 0;
                return;
            }
            _CheckEnemyMove(ref skip);
            
            if (skip == 1)
            {
                skip = 0;
                return;
                
            }
            
            if (_polegame[1][1] == 0)
            {
                _SetType(1, 1);
                return;
            }
            else if (_polegame[1][1] == 1)
            {
                if (_polegame[0][2] == 0)
                {
                    _SetType(0, 2);
                    return;
                }
                else if (_polegame[0][0] == 0)
                {
                    _SetType(0, 0);
                    return;
                }
                else
                {
                    for (int i = 0; i < 3; i++)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            if (_polegame[i][k] == 0)
                            {
                                _SetType(i, k);
                                return;
                            }
                        }
                    }
                }

            }
            else
            {
                if ((_polegame[0][0] == 1 || _polegame[0][2] == 1 || _polegame[2][0] == 1 || _polegame[2][2] == 1) && _polegame[0][1] == 0)
                {
                    _SetType(0,1);
                    return;
                }
                for (int i = 0; i < 3; i++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        if (_polegame[i][k] == 0)
                        {
                            _SetType(i,k);
                            return;
                        }
                    }
                }

            }
        }
        public static void StartResetGame() // Reset game
        {
            
            hod = 1;
            for (int i = 0; i < 3; i++)
            {
                _polegame[i] = new int[3] { 0, 0, 0 };
            }
            Pole();
        }
        public static void Move() // hod of player
        {
            if (hod == 1)
            {


                int endMove = 0;
                do
                {
                    string CellPlayer = Console.ReadLine();
                    if (CellPlayer.Length == 3 && '0' <= CellPlayer[0] && CellPlayer[0] < '9' && CellPlayer[1] == ' ' && '0' <= CellPlayer[2] && CellPlayer[2] < '9')
                    {
                        

                        string[] CellPlayerАrr = CellPlayer.Split();
                        int stb = int.Parse(CellPlayerАrr[0]);
                        int str = int.Parse(CellPlayerАrr[1]);
                        _SetType(stb, str);
                        endMove = 1;


                    }
                    else
                    {
                        Console.WriteLine("Try again!");
                    }
                }
                while (endMove == 0);
            }
            else _GameBot();
        }
        public static char PlayerType(int str, int stb)
        {
            switch (_polegame[stb][str])
            {
                case 1: return 'X';
                case 2: return 'O';
                default: return ' ';

            }

        }
    }
    class Program
    {
        static void menu() {
            Console.WriteLine("tic tac toe");
            Console.WriteLine("1-Game\n2-Rules");

            string answer = "0";
            answer = Console.ReadLine();
            switch (answer)
            {
                case "2": Console.Clear(); Console.WriteLine("Tic Tac Toe.\n You are player number 1, and your opponent is a robot (player number 2)\n Control: Enter 2 numbers separated by a space. 1 Row  2 column"); Console.ReadKey(); break;
                default: break;  
            }
        }
        static void Main()
        {
            menu();
            Players.StartResetGame();
            while (true)
            {
                Players.Pole();
                Players.CheckGame();
                Players.Move();
            }
        }  
    }
}
