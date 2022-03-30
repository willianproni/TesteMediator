using System;

namespace RefactoringGuru.DesignPatterns.Mediator.Conceptual
{
    //Declaração do Mediador
    //A interface Mediator declara um metodo que notifica o mediador
    //sobre vários eventos.
    //O Mediador pode reagir a esses eventos e passar a executar outros componentes.
    public interface IMediator
    {
        void Notificar(object recebe, string verf); //Criação do Mediador
    }

    // Criando class com objetos cooperativos com o Mediador
    class ConcreteMediator : IMediator
    {
        private Component1 Component1;
        '
        private Component2 Component2;

        public AdicionaPet AdicionaPet { get; }
        public TorreComando TorreComando { get; }

        public ConcreteMediator(Component1 component1, Component2 component2, AdicionaPet adicionapet, TorreComando torrecomando)
        {
            Component1 = component1;
            Component1.SetMediator(this);
            Component2 = component2;
            Component2.SetMediator(this);
            AdicionaPet = adicionapet;
            AdicionaPet.SetMediator(this);
            TorreComando = torrecomando;
            TorreComando.SetMediator(this);
        }

        public void Notificar(object recebe, string verf)
        {
            if (verf == "A")
            {
                Console.WriteLine("\n\t\tO mediador reage opção A e aciona as seguintes operações");
                Component2.AdicionarPessoa();
            }
            if (verf == "D")
            {
                Console.WriteLine("\n\t\tO mediador reage em D e aciona as seguintes operações");
                Component1.DoB();
            }
            if (verf == "C")
            {
                Console.WriteLine("\n\t\tO mediador encontra opção AdicionarPet e aciona a seguinte Operação:");
                AdicionaPet.opcPet();
            }
            if (verf == "F")
            {
                Console.WriteLine("\n\n\t\tO mediador encontra opção VerificarPista e aciona a seguinte Operação:");
                TorreComando.VerificaPista();
            }
        }
    }

    //Componente Base faz a funcionalidade de armazenar uma instância do medidor dentro de objetos componentes.
    class BaseComponent
    {
        public IMediator Mediator;

        public BaseComponent(IMediator mediator = null)
        {
            Mediator = mediator;
        }

        public void SetMediator(IMediator mediator)
        {
            Mediator = mediator;
        }
    }

    //Os componentes implementam várias funcionalidades, eles não dependem de outro componente.
    // classes.
    class Component1 : BaseComponent
    {
        public void opcA()
        {
            Console.Clear();
            Console.WriteLine("\t\tComponente 1 realiza opção A.");
            Console.ReadKey();

            Mediator.Notificar(this, "A");
        }

        public void DoB()
        {
            Console.WriteLine("\t\tComponent 1 realiza opção PilotoSolicita.");
            Console.Write("\n\t\tPiloto Solicita permisão para Pouso");
            Console.ReadKey();

            Mediator.Notificar(this, "F");
        }
    }

    class AdicionaPet : BaseComponent
    {
        public void opcPet()
        {
            Console.WriteLine("\t\tComponent 3 realiza opção Adicionar Pet.");
            Console.Write("\n\t\tQual o nome do Cachorro: ");
            string nomedog = Console.ReadLine();
            Console.WriteLine("\n\t\tCachorro Adicionado!!");
            Console.ReadKey();
            Mediator.Notificar(this, "B");
        }
    }

    class TorreComando : BaseComponent
    {
        public void VerificaPista()
        {
            Console.Write("\n\t\tTorre de Comando Pista Vazia: ");
            string pista = Console.ReadLine().ToUpper();

            if (pista == "S")
            {
                Console.WriteLine("\n\t\tPista Vazia!");
            }
            else
            {
                Console.WriteLine("\n\t\tPista Ocupada");
            }
            Console.ReadKey();
            Mediator.Notificar(this, "B");
        }
    }

    class Component2 : BaseComponent
    {
        public void AdicionarPessoa()
        {
            Console.WriteLine("\t\tComponent 2 realiza operção Adionar Pessoa\n\n");
            Console.WriteLine("\t\t-- Adicionar Nova Pessoa --");
            Console.Write("\t\tDigite o nome da Pessoa: ");
            string nome = Console.ReadLine();
            Console.Write("\t\tVocê Tem cachorro (S/N): ");
            string verificaPet = Console.ReadLine().ToUpper();

            if (verificaPet == "S")
            {
                Mediator.Notificar(this, "C");
            }
            Console.WriteLine("\n\t\tPessoa Adicionada!!");
            Console.ReadKey();
            Mediator.Notificar(this, "E");
        }

        public void DoD()
        {
            Console.Clear();
            Console.WriteLine("\t\tComponent 2 faz operação D.");
            Console.ReadKey();
            Mediator.Notificar(this, "D");
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            // The client code.
            Component1 operacao1 = new Component1();
            Component2 operacao2 = new Component2();
            AdicionaPet operacao3 = new AdicionaPet();
            TorreComando operacao4 = new TorreComando();
            new ConcreteMediator(operacao1, operacao2, operacao3, operacao4);
            string opc;

            do
            {
                Menu();
                opc = Console.ReadLine();

                switch (opc)
                {
                    case "1":
                        Console.WriteLine("O cliente aciona Adicionar Pessoa - A.\n");
                        operacao1.opcA();
                        break;
                    case "2":
                        Console.WriteLine("O cliente aciona a operação 2.\n");
                        operacao2.DoD();
                        break;
                    case "0":
                        Console.Clear();
                        Console.WriteLine("Fechado...");
                        break;
                    default:
                        Console.WriteLine("Opção Inválida");
                        break;
                }

            } while (opc != "0");

            void Menu()
            {
                Console.Clear();
                Console.WriteLine("\t\t----- design partners -----\n\n" +
                                  "\t\t[1] - Adicionar Pessoa\n" +
                                  "\t\t[2] - Verifica Pista Livre\n" +
                                  "\n\t\t----------------------------");
                Console.Write("\t\tOpção: ");
            }
        }
    }
}