using System;

namespace Revisão.NET_C_
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;
            string opçãoUsuario =ObterOpçãoUsuario();

            while (opçãoUsuario.ToUpper() != "X")
            {
                switch (opçãoUsuario)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do aluno:");
                        var aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("informe a nota do aluno:");

                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException("Valor da nota deve ser decimal");
                        }

                        alunos[indiceAluno] = aluno;
                        indiceAluno++;  
                  
                        break;
                    case "2":
                        foreach(var a in alunos)
                        {
                            if (!string.IsNullOrEmpty(a.Nome))
                            {
                            Console.WriteLine($"Aluno: {a.Nome} - Nota: {a.Nota}");
                            }
                        }
                        break;
                    case "3":
                        decimal notaTotal = 0;       
                        var nrAlunos = 0;
                        for (int i=0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                nrAlunos++;
                            }
                        }

                        var médiaGeral = notaTotal / nrAlunos;
                        Conceito conceitoGeral;

                        if (médiaGeral < 2)
                        {
                            conceitoGeral = Conceito.E;
                        }
                        else if (médiaGeral < 4)
                        {
                            conceitoGeral = Conceito.D;
                        }
                        else if (médiaGeral < 6)
                        {
                            conceitoGeral = Conceito.C;
                        }
                        else if (médiaGeral < 8)
                        {
                            conceitoGeral = Conceito.B;
                        }
                        else
                        {
                            conceitoGeral = Conceito.A;
                        }


                        Console.WriteLine($"Média Geral: {médiaGeral} - Conceito: {conceitoGeral}");

                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                
                opçãoUsuario = ObterOpçãoUsuario();

            }
        }

        private static string ObterOpçãoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1- Inserir novo aluno");
            Console.WriteLine("2- Listar alunos");
            Console.WriteLine("3- Calcular média geral");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opçãoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opçãoUsuario;
        }
    }
}
