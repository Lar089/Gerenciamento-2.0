using System;

namespace Gerenciamento_2._0
{
    class App
    {
        private static String[] equipamento;
        private static String[] chamado;
        private static String[] equipamentos = new String[50];
        private static String[] chamados = new String[50];
        private static int cont_global_eq = 0;
        private static int cont_global_ch = 0;

        static void Main(string[] args)
        {
            String op;
            Console.WriteLine("Gerenciamento 2.0");
            do
            {
                op = Menu();
                switch (op)
                {
                    case "1":
                        Equipamentos();
                        break;
                    case "2":
                        Chamados();
                        break;
                    default:
                        if (op != "S")
                        {
                            Console.WriteLine("\n ERRO: Digite um valor valido! \n");
                        }
                        break;
                }

            } while (!op.Equals("S"));

        }

        public static String Menu()
        {
            Console.WriteLine("\nInventário Disponível");
            Console.WriteLine("1 - Controle de Equipamentos");
            Console.WriteLine("2 - Controle de Chamados");
            Console.WriteLine("S - Sair");
            String str = Console.ReadLine().ToUpper();
            return str;
        }

        public static String MenuEquipamentos()
        {
            Console.WriteLine("Controle de Equipamentos");
            Console.WriteLine("1 - Registrar Equipamento");
            Console.WriteLine("2 - Visualizar Equipamentos");
            Console.WriteLine("3 - Editar um Equipamento");
            Console.WriteLine("4 - Excluir um Equipamento");
            Console.WriteLine("S - Sair");
            String str = Console.ReadLine().ToUpper();
            return str;
        }

        public static String MenuChamados()
        {
            Console.WriteLine("Controle de Chamados");
            Console.WriteLine("1 - Registrar um Chamados");
            Console.WriteLine("2 - Visualizar Chamados");
            Console.WriteLine("3 - Editar um Chamado");
            Console.WriteLine("4 - Excluir um Chamado");
            Console.WriteLine("S - Sair");
            String str = Console.ReadLine().ToUpper();
            return str;
        }

        public static void Equipamentos()
        {
            String str;
            do
            {

                Console.WriteLine("\n********************************");
                str = MenuEquipamentos();
                switch (str)
                {
                    case "1":
                        CadastrarEquipamento(ref equipamentos, -1);
                        break;
                    case "2":
                        VisualizarEquipamentos();
                        break;
                    case "3":
                        Editar("E");
                        break;
                    case "4":
                        Deletar("E");
                        break;
                    default:
                        if (str != "S")
                        {
                            Console.WriteLine("\n ERRO: Digite um valor valido! \n");
                        }
                        break;
                }

            } while (!str.Equals("S"));
            Console.Clear();
        }

        public static void Chamados()
        {
            String str;
            do
            {

                Console.WriteLine("\n********************************");
                str = MenuChamados();
                switch (str)
                {
                    case "1":
                        if (cont_global_eq > 0)
                        {
                            CadastrarChamados(ref chamados, -1);
                        }
                        else
                        {
                            Console.WriteLine("ERRO: Cadastre um equipamento!");
                        }
                        break;
                    case "2":
                        VisualizarChamados();
                        break;
                    case "3":
                        if (cont_global_ch > 0)
                        {
                            Editar("M");
                        }
                        else
                        {
                            Console.WriteLine("ERRO: Cadastre um chamado!");
                        }
                        break;
                    case "4":
                        if (cont_global_ch > 0)
                        {
                            Deletar("M");
                        }
                        else
                        {
                            Console.WriteLine("ERRO: Cadastre um chamado!");
                        }
                        break;
                    default:
                        if (str != "S")
                        {
                            Console.WriteLine("\n ERRO: Digite um valor valido! \n");
                        }
                        break;
                }

            } while (!str.Equals("S"));
            Console.Clear();
        }

        public static void CadastrarEquipamento(ref String[] equipamentos, int posicao)
        {
            Console.Clear();
            String str;
            int cont = 0;
            double preco;
            bool aux = false;
            int aux_d, aux_m, aux_a;
            bool date_d, date_m, date_a;
            DateTime data;
            equipamento = new String[5];

            do
            {
                Console.WriteLine("Informe o Nome:");
                str = Console.ReadLine();
                if (str.Length < 6)
                {
                    Console.WriteLine("Erro: Nome precisa ter mais de 6 caracteres!\n");
                }
                else
                {
                    equipamento[cont] = str;
                    cont++;
                }
            } while (str.Length < 6);

            do
            {
                Console.WriteLine("Informe o Preço de Aquisição:");
                str = Console.ReadLine();
                aux = double.TryParse(str, out preco);
                if (!aux)
                {
                    Console.WriteLine("ERRO: Preço inválido!\n");
                }
                else
                {
                    equipamento[cont] = str;
                    cont++;
                }
            } while (aux != true);

            do
            {
                Console.WriteLine("Informe o Número de série:");
                str = Console.ReadLine();
                if (str.Length != 0)
                {
                    equipamento[cont] = str;
                    cont++;
                }
                else
                {
                    Console.WriteLine("ERRO: Esse campo não pode ficar vazio!\n");
                }
            } while (cont < 3);

            do
            {
                Console.WriteLine("Informe o Data de Fabricação (dd/mm/aaaa)");
                str = Console.ReadLine();
                if (str.Length == 10)
                {
                    string dia = str.Split('/')[0];
                    date_d = Int32.TryParse(dia, out aux_d);

                    string mes = str.Split('/')[1];
                    date_m = Int32.TryParse(mes, out aux_m);

                    string ano = str.Split('/')[2];
                    date_a = Int32.TryParse(ano, out aux_a);


                    if (!date_d || !date_m || !date_a)
                    {
                        Console.WriteLine("ERRO: Data invalida!\n");
                    }
                    else
                    {
                        try
                        {
                            data = new DateTime(aux_a, aux_m, aux_d);
                            equipamento[cont] = str;
                            cont++;
                        }

                        catch
                        {
                            Console.WriteLine("ERRO: Data invalida!\n");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("ERRO: Data invalida!\n");
                }
            } while (cont < 4);

            do
            {
                Console.WriteLine("Informe o Fabricante");
                str = Console.ReadLine();
                if (str.Length != 0)
                {
                    equipamento[cont] = str;
                    cont++;
                }
                else
                {
                    Console.WriteLine("ERRO: Esse campo não pode ficar vazio!\n");
                }
            } while (cont < 5);

            str = null;
            for (int i = 0; i < 5; i++)
            {
                str = str + equipamento[i];
                if (i < 4)
                {
                    str = str + " ";
                }
            }
            cont = 0;
            if (posicao < 0)
            {
                equipamentos[cont_global_eq] = str;
                cont_global_eq++;
            }
            else
            {
                equipamentos[posicao] = str;

            }

            Console.Clear();
        }

        public static void CadastrarChamados(ref String[] chamados, int posicao)
        {
            Console.Clear();
            String str;
            int cont = 0;
            double preco;
            bool aux = false;
            int aux_d, aux_m, aux_a, aux_posicao;
            bool date_d, date_m, date_a;
            DateTime data;
            chamado = new String[5];

            do
            {
                Console.WriteLine("Informe o Titulo:");
                str = Console.ReadLine();
                if (str.Length != 0)
                {
                    chamado[cont] = str;
                    cont++;
                }
                else
                {
                    Console.WriteLine("\nEsse campo não pode ficar vazio!\n");
                }
            } while (str.Length == 0);

            do
            {
                VisualizarEquipamentos();
                Console.WriteLine("\nInforme o Equipamento:");
                str = Console.ReadLine();
                if (str.Length != 0)
                {
                    aux_posicao = CompararEquipamento(str);
                    if (aux_posicao >= 0)
                    {
                        chamado[cont] = str;
                        String[] eq_fabricante;
                        eq_fabricante = equipamentos[aux_posicao].Split(" ");
                        chamado[4] = eq_fabricante[4];
                        cont++;
                    }
                }
                else
                {
                    Console.WriteLine("ERRO: Esse campo não pode ficar vazio!\n");
                }
            } while (cont < 2);

            do
            {
                Console.WriteLine("Informe o Data de Abertura (dd/mm/aaaa)");
                str = Console.ReadLine();
                if (str.Length == 10)
                {
                    string dia = str.Split('/')[0];
                    date_d = Int32.TryParse(dia, out aux_d);

                    string mes = str.Split('/')[1];
                    date_m = Int32.TryParse(mes, out aux_m);

                    string ano = str.Split('/')[2];
                    date_a = Int32.TryParse(ano, out aux_a);


                    if (!date_d || !date_m || !date_a)
                    {
                        Console.WriteLine("ERRO: Data invalida!\n");
                    }
                    else
                    {
                        try
                        {
                            data = new DateTime(aux_a, aux_m, aux_d);
                            chamado[cont] = str;
                            cont++;
                        }

                        catch
                        {
                            Console.WriteLine("ERRO: Data invalida!\n");
                        }
                        
                    }
                }
                else
                {
                    Console.WriteLine("ERRO: Data invalida!\n");
                }
            } while (cont < 3);

            do
            {
                Console.WriteLine("Número de dias que o chamado está aberto:");
                str = Console.ReadLine();
                aux = double.TryParse(str, out preco);
                if (!aux)
                {
                    Console.WriteLine("ERRO: Valor inválido!\n");
                }
                else
                {
                    chamado[cont] = str;
                    cont++;
                }
            } while (aux != true);

            str = null;
            for (int i = 0; i < 5; i++)
            {
                str = str + chamado[i];
                if (i < 4)
                {
                    str = str + " ";
                }
            }
            cont = 0;
            if (posicao < 0)
            {
                chamados[cont_global_ch] = str;
                cont_global_ch++;
            }
            else
            {
                chamados[posicao] = str;

            }

            Console.Clear();
        }

        public static void VisualizarEquipamentos()
        {
            if (cont_global_eq != 0)
            {
                for (int i = 0; i < cont_global_eq; i++)
                {
                    if (equipamentos[i] != null)
                    {
                        String[] str = equipamentos[i].Split(" ");
                        Console.WriteLine("\n*************************");
                        Console.WriteLine("Equipamento ");
                        Console.WriteLine($"Nome: {str[0]}");
                        Console.WriteLine($"Número de Serie: {str[2]}");
                        Console.WriteLine($"Fabricante: {str[4]}");
                    }
                    else
                    {
                        Console.WriteLine("\nERRO: Não possui equipamentos cadastrados!\n");
                    }
                }
            }
            else
            {
                Console.WriteLine("\nERRO: Não possui equipamentos cadastrados!\n");
            }
        }

        public static void VisualizarChamados()
        {
            if (cont_global_ch != 0)
            {
                for (int i = 0; i < cont_global_ch; i++)
                {
                    if (chamados[i] != null)
                    {
                        String[] str = chamados[i].Split(" ");
                        Console.WriteLine("\n*************************");
                        Console.WriteLine("Chamados ");
                        Console.WriteLine($"Título: {str[0]}");
                        Console.WriteLine($"Equipamento: {str[1]}");
                        Console.WriteLine($"Data de abertura: {str[2]}");
                        Console.WriteLine($"Fabricante: {str[4]}");
                    }
                    else
                    {
                        Console.WriteLine("\nERRO: Não possui chamados cadastrados!\n");
                    }
                }
            }
            else
            {
                Console.WriteLine("\nERRO: Não possui chamados cadastrados!\n");
            }
        }

        public static void Deletar(String tipo_str)
        {
            if (cont_global_eq != 0 || cont_global_ch != 0)
            {
                Console.Clear();
                Console.WriteLine("Digite o nome:");
                String _delete = Console.ReadLine();
                if (tipo_str.Equals("E"))
                {
                    for (int i = 0; i < cont_global_eq; i++)
                    {
                        String[] str = equipamentos[i].Split(" ");
                        if (_delete.Equals(str[0]))
                        {
                            equipamentos[i] = null;
                            Console.WriteLine("Sucesso!");
                            break;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < cont_global_ch; i++)
                    {
                        String[] str = chamados[i].Split(" ");
                        if (_delete.Equals(str[0]))
                        {
                            chamados[i] = null;
                            Console.WriteLine("Sucesso!");
                            break;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("\nERRO: Não possui nada cadastrados!\n");
            }
        }

        public static void Editar(String tipo_str)
        {
            if (cont_global_eq != 0 || cont_global_ch != 0)
            {
                Console.Clear();
                Console.WriteLine("Digite o nome:");
                String _delete = Console.ReadLine();
                if (tipo_str.Equals("E"))
                {
                    for (int i = 0; i < cont_global_eq; i++)
                    {
                        String[] str = equipamentos[i].Split(" ");
                        if (_delete.Equals(str[0]))
                        {
                            CadastrarEquipamento(ref equipamentos, i);
                        }
                        else if (i == cont_global_eq - 1)
                        {
                            Console.WriteLine("\nERRO: Nome não encontrado!\n");
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < cont_global_ch; i++)
                    {
                        String[] str = chamados[i].Split(" ");
                        if (_delete.Equals(str[0]))
                        {
                            CadastrarChamados(ref chamados, i);
                        }
                        else if (i == cont_global_ch - 1)
                        {
                            Console.WriteLine("\nERRO: Nome não encontrado!\n");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("\nERRO: Não possui nada cadastrados!\n");
            }


        }

        public static int CompararEquipamento(String str_compare)
        {
            int aux = -1;
            if (cont_global_eq != 0 || cont_global_ch != 0)
            {
                for (int i = 0; i < cont_global_eq; i++)
                {
                    String[] str = equipamentos[i].Split(" ");
                    if (str_compare.Equals(str[0]))
                    {
                        aux = i;
                        Console.WriteLine($" Posição: {aux}");
                        return aux;
                    }
                    else if (i == cont_global_eq - 1)
                    {
                        Console.WriteLine("\nERRO: Equipamento não encontrado!\n");
                    }
                }
            }
            return aux;
        }
    }
}
