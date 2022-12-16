using System;
namespace Laba_3
{
    class Key
    {
        string invent;
        int dayYear;
        public Key(string invent, int dayYear)
        {
            this.invent = invent;
            this.dayYear = dayYear; 
        }
        public int Hash()
        {
            int hash = dayYear;
            for(int i = 0; i < invent.Length; i++)
            {
                hash += invent[i]*3;
            }
            return hash;
        }
        public bool Eq(Key other)
        {
            return this.dayYear == other.dayYear && this.invent == other.invent;    
        }
    }
    class Node
    {
        public double value;
        public Key key;
        public Node next;
        public Node(Key key, double value, Node next)
        {
            this.key = key; 
            this.value = value; 
            this.next = next;

        }
    }
    class Carta_no_ne_Lukaschenka
    {
        Node[] nodes;
        public Carta_no_ne_Lukaschenka(int len)
        {
            nodes = new Node[len];
        }
        public void Put(Key key, double value)
        {
            int index = Math.Abs(key.Hash() % nodes.Length);
            if (nodes[index] == null)
            {
                nodes[index] = new Node(key, value, null);
            }
            else
            {
               for(Node node = nodes[index]; nodes != null; node = node.next)
               {
                    if (node.key.Eq(key))
                    {
                        nodes[index] = new Node(key, value, nodes[index]);
                    }
                    return;
               }
               
            }
        }
        public double Get(Key key)
        {
            int index = Math.Abs(key.Hash()%nodes.Length);
            for (Node node = nodes[index]; node != null; node = node.next)
            {
                if (node.key.Eq(key))
                {
                   return node.value;
                    
                }
            }
            return 0;
        }
        public bool ConstKey(Key key)
        {
            int index = Math.Abs(key.Hash() % nodes.Length);
            for (Node node = nodes[index]; node != null; node = node.next)
            {
                if (node.key.Eq(key))
                {
                    return true;

                }
            }
            return false;   
        }
        public double Remove(Key key)
        {
            int index = Math.Abs(key.Hash() % nodes.Length);
            for (Node node = nodes[index]; node != null; node = node.next)
            {
                if (node.key.Eq(key))
                {
                    nodes[index] = node.next;

               return node.value;
                }
            }
            return 0;
        }
        public int Size()
        {

            return nodes.Length;
        }

        public void Show()
        {
            for (int i = 0; i < nodes.Length; i++)
            {
                Console.WriteLine("Index [" + i + "]: ");

                for (Node node = nodes[i]; node != null; node = node.next)
                {
                    Console.WriteLine(node.value + " ");
                }
                Console.WriteLine(); 
            }
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main()
        {
            Carta_no_ne_Lukaschenka cartochka = new Carta_no_ne_Lukaschenka(6);
            cartochka.Put(new Key("CocaCola", 50), 50);
            cartochka.Put(new Key("Fanta", 60), 60);
            cartochka.Put(new Key("Pepsi", 70), 70);
            cartochka.Put(new Key("Milka", 80), 80);
            cartochka.Put(new Key("Schaschluk", 90), 90);
            cartochka.Put(new Key("BMW", 100), 100);
            cartochka.Show();
            Console.WriteLine(cartochka.Get(new Key("Schaschluk", 90)));
            Console.WriteLine(cartochka.ConstKey(new Key ("Pepsi", 70)));
            Console.WriteLine(cartochka.Remove(new Key("CocaCola", 50)));
            Console.WriteLine(cartochka.Size());
            cartochka.Show();
        }
    }
}
