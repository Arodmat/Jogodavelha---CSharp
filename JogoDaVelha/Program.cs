using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaVelha
{
    internal class Program
    {
        static void ShowMenu(string[,] mat)
        {
            //Console.Clear();
            Console.WriteLine();
            Console.WriteLine($"[{mat[0,0]}] [{mat[0, 1]}] [{mat[0, 2]}]");
            Console.WriteLine();
            Console.WriteLine($"[{mat[1,0]}] [{mat[1, 1]}] [{mat[1, 2]}]");
            Console.WriteLine();
            Console.WriteLine($"[{mat[2,0]}] [{mat[2, 1]}] [{mat[2, 2]}]");
            Console.WriteLine();

        }
       
        static void Cabecalho(int X, int O)
        {
            Console.Clear();
            Console.WriteLine("JOGO DA VELHA");
            Console.WriteLine("-----------------");
            Console.WriteLine();
            Console.WriteLine("PLACAR ");
            Console.WriteLine($"Jogador X: {X}");
            Console.WriteLine($"Jogador O: {O}");
            Console.WriteLine();
            Console.WriteLine("-----------------");
        }
        static void Inserir(ref int num, ref string[,] mat, string aux, ref int line, ref int column)
        {
            switch (num)
            {
                case 1:
                    mat[0, 0] = aux;
                    line = 0;
                    column = 0;
                    break;

                case 2:
                    mat[0, 1] = aux;
                    line = 0;
                    column = 1;

                    break;

                case 3:
                    mat[0, 2] = aux;
                    line = 0;
                    column = 2;
                    break;

                case 4:
                    mat[1, 0] = aux;
                    line = 1;
                    column = 0;
                    break;

                case 5:
                    mat[1, 1] = aux;
                    line = 1;
                    column = 1;
                    break;

                case 6:
                    mat[1, 2] = aux;
                    line = 1;
                    column = 2;
                    break;

                case 7:
                    mat[2, 0] = aux;
                    line = 2;
                    column = 0;
                    break;

                case 8:
                    mat[2, 1] = aux;
                    line = 2;
                    column = 1;

                    break;

                case 9:
                    mat[2, 2] = aux;
                    line = 2;
                    column = 2;
                    break;
            }

        }

        static bool VitoriaLinha(ref string[,] mat, ref int line)
        {
            if (string.Equals(mat[line, 0], mat[line, 1]))
            {
                if (string.Equals(mat[line, 0], mat[line, 2]))
                    return true;

                else
                    return false;
            }
            else
                return false;
        }

        static bool VitoriaColuna(ref string[,] mat, ref int column)
        {
            if (string.Equals(mat[0, column], mat[1, column]))
            {
                if (string.Equals(mat[0, column], mat[2, column]))
                    return true;

                else
                    return false;
            }
            else
                return false;

        }

        static bool VitoriaDiagonal(ref string[,] mat)
        {
            if (string.Equals(mat[1,1], mat[0,2]))
            {
                if (string.Equals(mat[1, 1], mat[2, 0]))
                    return true;

                else
                    return false;
            }

            else if (string.Equals(mat[1, 1], mat[0, 0]))
            {
                if (string.Equals(mat[1, 1], mat[2, 2]))
                    return true;

                else
                    return false;
            }

            else
                return false;

        }

        static void Main(string[] args)
        {
            int opcao, linha = 0, coluna = 0, jogadas = 0, placarX = 0, placarO = 0, cont = 0, FimDeJogo = 1;
            string[,] grade = new string[3, 3];
            string aux;


            while (FimDeJogo == 1)
            {
                jogadas = 0;linha= 0;coluna= 0;cont = 0;

                //inicializando a matriz
                grade[0, 0] = "1"; grade[0, 1] = "2"; grade[0, 2] = "3";
                grade[1, 0] = "4"; grade[1, 1] = "5"; grade[1, 2] = "6";
                grade[2, 0] = "7"; grade[2, 1] = "8"; grade[2, 2] = "9";


                // 
                while (jogadas < 9 && (!VitoriaColuna(ref grade, ref coluna) && !VitoriaLinha(ref grade, ref linha) && !VitoriaDiagonal(ref grade)))
                {
                    do
                    {
                        Cabecalho(placarX, placarO);
                        ShowMenu(grade);
                        if ((!VitoriaLinha(ref grade, ref linha) && !VitoriaColuna(ref grade, ref coluna) && !VitoriaDiagonal(ref grade)) && jogadas!=9)
                        {
                            Console.WriteLine();
                            Console.Write("Escolha um botão: ");

                        }

                        opcao = int.Parse(Console.ReadLine());

                    } while (opcao < 1 || opcao > 9); // fica rodando enquanto o numero for invalido

                    cont++; // Serve para alterar as jogadas entre X e O
                    if (cont % 2 == 0)
                        Inserir(ref opcao, ref grade, "O", ref linha, ref coluna);
                    else
                        Inserir(ref opcao, ref grade, "X", ref linha, ref coluna);

                    jogadas++;//conta uma jogada
                    Cabecalho(placarX, placarO); // Mostra o placar
                    ShowMenu(grade);
                    if ((!VitoriaLinha(ref grade, ref linha) && !VitoriaColuna(ref grade, ref coluna) && !VitoriaDiagonal(ref grade)) && jogadas!=9)
                    {
                        Console.WriteLine();
                        Console.Write("Escolha um botão: ");

                    }
                }

                //Atualizando os placares

                if (cont % 2 == 0)
                {
                    placarO++;
                    aux = "O";
                }

                else
                {
                    placarX++;  
                    aux = "X";
                }

                if ((VitoriaLinha(ref grade, ref linha) || VitoriaColuna(ref grade, ref coluna) || VitoriaDiagonal(ref grade)))
                {
                    Console.WriteLine("---------------------------");
                    Console.WriteLine($"VITORIA DO {aux}!");

                }

                else if (jogadas == 9 && (!VitoriaColuna(ref grade, ref coluna) || !VitoriaLinha(ref grade, ref linha) || !VitoriaDiagonal(ref grade)))
                {
                    Console.WriteLine("---------------------------");
                    Console.WriteLine("EMPATE!");

                }

                Console.WriteLine();
                do
                {
                    Console.WriteLine();
                    Console.WriteLine("---------------------------");
                    Console.WriteLine("Novo jogo?");
                    Console.Write("1 - SIM      2 - NAO");
                    Console.WriteLine();
                    FimDeJogo = int.Parse(Console.ReadLine());
                } while (FimDeJogo < 1 || FimDeJogo > 2);

            }
        }
    }
}
