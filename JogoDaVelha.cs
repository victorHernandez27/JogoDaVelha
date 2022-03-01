using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaVelha
{
    internal class JogoDaVelha
    {
        private bool fimDoJogo;
        private string[,] posicoes;
        private string vez;
        private int jogadas;

        public JogoDaVelha()
        {
            fimDoJogo = false;
            posicoes = new string[3, 3];

            posicoes[0, 0] = " ";
            posicoes[0, 1] = " ";
            posicoes[0, 2] = " ";
            posicoes[1, 0] = " ";
            posicoes[1, 1] = " ";
            posicoes[1, 2] = " ";
            posicoes[2, 0] = " ";
            posicoes[2, 1] = " ";
            posicoes[2, 2] = " ";

            vez = "X";
            jogadas = 0;
        }

        public void Iniciar()
        {
            do
            {
                Imprimir_Jogo();
                EscolhaJogador();
                Imprimir_Jogo();
                VerificaStatus(posicoes);
                PassarVez();
            } while (fimDoJogo == false);
        }


        private void Imprimir_Jogo()
        {
            Console.Clear();
            Console.WriteLine(DesenharTabela());
        }


        private void EscolhaJogador()
        {
            Console.WriteLine("Jogador {0}, Escolha uma das Linhas (0 a 2) disponíveis  para jogar: ", vez);
            bool validaLinha = int.TryParse(Console.ReadLine(), out int posicaoEscolhidaLinha);

            Console.WriteLine("Jogador {0}, Escolha uma das Colunas (0 a 2) disponíveis  para jogar: ", vez);
            bool validaColuna = int.TryParse(Console.ReadLine(), out int posicaoEscolhidaColuna);

            while (!validaLinha || !validaColuna || !PosicaoDisponivel(posicaoEscolhidaLinha, posicaoEscolhidaColuna))
            {
                Console.WriteLine("Valor Digitado é invalido! Digite valores da Linha que estão disponíveis na tabela!");
                validaLinha = int.TryParse(Console.ReadLine(), out posicaoEscolhidaLinha);
                Console.WriteLine("Valor Digitado é invalido! Digite valores da Coluna que estão disponíveis na tabela!");
                validaColuna = int.TryParse(Console.ReadLine(), out posicaoEscolhidaColuna);
            }

            PocisionaEscolha(posicaoEscolhidaLinha, posicaoEscolhidaColuna);
        }


        private void PocisionaEscolha(int posicaoEscolhidaLiha, int posicaoEscolhidaColuna)
        {
            posicoes[posicaoEscolhidaLiha, posicaoEscolhidaColuna] = vez;
            jogadas++;

        }

        private bool PosicaoDisponivel(int posicaoEscolhidaLiha, int posicaoEscolhidaColuna)
        {

            if (posicoes[posicaoEscolhidaLiha, posicaoEscolhidaColuna] != "O" && posicoes[posicaoEscolhidaLiha, posicaoEscolhidaColuna] != "X")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void VerificaStatus(string[,] posicoes)
        {

            if (jogadas >= 5)
            {
                if (VitoriaVertical() || VitoriaDiagonal() || VitoriaHorizontal())
                {
                    fimDoJogo = true;
                    Console.WriteLine("Fim de Jogo!!! Vitória de {0}", vez);

                }
                else
                {
                    if (jogadas == 9)
                    {
                        fimDoJogo = true;
                        Console.WriteLine("Fim de Jogo!!! EMPATE");
                    }
                }
            }

        }

        private bool VitoriaHorizontal()
        {
            if ((posicoes[0,0] == "X") && (posicoes[0,1] == "X") && (posicoes[0,2] == "X") || (posicoes[0, 0] == "O") && (posicoes[0, 1] == "O") && (posicoes[0, 2] == "O"))
            {
                return true;
            }
            else
            {
                if ((posicoes[1, 0] == "X") && (posicoes[1, 1] == "X") && (posicoes[1, 2] == "X") || (posicoes[1, 0] == "O") && (posicoes[1, 1] == "O") && (posicoes[1, 2] == "O"))
                {
                    return true;
                }
                else
                {
                    if ((posicoes[2, 0] == "X") && (posicoes[2, 1] == "X") && (posicoes[2, 2] == "X") || (posicoes[2, 0] == "O") && (posicoes[2, 1] == "O") && (posicoes[2, 2] == "O"))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        private bool VitoriaVertical()
        {

            if ((posicoes[0, 0] == "X") && (posicoes[1, 0] == "X") && (posicoes[2, 0] == "X") || (posicoes[0, 0] == "O") && (posicoes[1, 0] == "O") && (posicoes[2, 0] == "O"))
            {
                return true;
            }
            else
            {
                if ((posicoes[0, 1] == "X") && (posicoes[1, 1] == "X") && (posicoes[2, 1] == "X") || (posicoes[0, 1] == "O") && (posicoes[1, 1] == "O") && (posicoes[2, 1] == "O"))
                {
                    return true;
                }
                else
                {
                    if ((posicoes[0, 2] == "X") && (posicoes[1, 2] == "X") && (posicoes[2, 2] == "X") || (posicoes[0, 2] == "O") && (posicoes[1, 2] == "O") && (posicoes[2, 2] == "O"))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

        }
        private bool VitoriaDiagonal()
        {
            if ((posicoes[0, 0] == "X") && (posicoes[1, 1] == "X") && (posicoes[2, 2] == "X") || (posicoes[0, 0] == "O") && (posicoes[1, 1] == "O") && (posicoes[2, 2] == "O"))
            {
                return true;
            }
            else
            {
                if ((posicoes[0, 2] == "X") && (posicoes[1, 1] == "X") && (posicoes[2, 0] == "X") || (posicoes[0, 2] == "O") && (posicoes[1, 1] == "O") && (posicoes[2, 0] == "O"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        private void PassarVez()
        {
            if (vez == "X")
            {
                vez = "O";
            }
            else
            {
                vez = "X";
            }
        }

        private string DesenharTabela()
        {
            return "\t\tJogando\n\n" +
                   "\t\tColunas\n\n" +
                   "\t___0__|__1__|__2__\n" +
                   "\t0__" + posicoes[0, 0] + "__|__" + posicoes[0, 1] + "__|__" + posicoes[0, 2] + "__\n" +
                   "Linhas\t1__" + posicoes[1, 0] + "__|__" + posicoes[1, 1] + "__|__" + posicoes[1, 2] + "__\n" +
                   "\t2__" + posicoes[2, 0] + "__|__" + posicoes[2, 1] + "__|__" + posicoes[2, 2] + "__\n\n";
        }
    }
}
