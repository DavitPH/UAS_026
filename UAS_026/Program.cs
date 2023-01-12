using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_026
{
    class Node
    {

        public int id_obat;
        public string nama_obat;
        public int dosis_obat;
        public int harga_obat;
        public Node next;
        public Node prev;
    }

    class Apotik
    {
        Node START;
        public Apotik()
        {
            START = null;
        }
        public void addNode()
        {
            int id_obat;
            string nama_obat;
            int dosis_obat;
            int harga_obat;

            Console.Write("\nMasukan id obat: ");
            id_obat = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nMasukan nama obat: ");
            nama_obat = (Console.ReadLine());

            Console.Write("\nMasukan dosis obat (1 = Ringan, 2 = Sedang, 3 = Berat, 4 = izin dokter): ");
            dosis_obat = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nMasukan harga obat: ");
            harga_obat = Convert.ToInt32(Console.ReadLine());


            Node newnode = new Node();
            newnode.id_obat = id_obat;
            newnode.nama_obat = nama_obat;
            newnode.dosis_obat = dosis_obat;
            newnode.harga_obat = harga_obat;


            if (START == null || id_obat <= START.id_obat)
            {
                if ((START != null) && (id_obat == START.id_obat))
                {
                    Console.WriteLine("\nDuplicate roll id not allowed");
                    return;
                }
                newnode.next = START;
                if (START != null)
                    START.prev = newnode;
                newnode.prev = null;
                START = newnode;
                return;
            }

            Node previous, current;
            for (current = previous = START; current != null &&
                id_obat >= current.id_obat; previous = current, current =
                current.next)
            {
                if (id_obat == current.id_obat)
                {
                    Console.WriteLine("\nDuplicate roll id not allowed");
                    return;
                }
            }

            newnode.next = current;
            newnode.prev = previous;

            if (current == null)
            {
                newnode.next = null;
                previous.next = newnode;
                return;
            }
            current.prev = newnode;
            previous.next = newnode;
        }

        public bool search(int rollkel, ref Node previous, ref Node current)
        {
            previous = START;
            current = START;

            while ((current != null) && (rollkel != current.dosis_obat))
            {
                previous = current;
                current = current.next;
            }
            if (current == null)
                return false;
            else
                return true;
        }

        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
        public void display()
        {
            if (listEmpty())
                Console.WriteLine("\nList is Empty");
            else
            {
                Console.WriteLine("ID OBAT" + "     " + " NAMA OBAT" + "     " + " DOSIS OBAT" + "     " + "HARGA OBAT" + " \n");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                    
                    Console.Write(currentNode.id_obat + "     " + currentNode.nama_obat + "      " +currentNode.dosis_obat + "      "  + currentNode.harga_obat  + "      "  + "\n");
            }
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            Apotik dl = new Apotik();
            while (true)
            {
                try
                {
                    Console.WriteLine("================================");
                    Console.WriteLine("1. Menambahkan Data");
                    Console.WriteLine("2. Mencari Data");
                    Console.WriteLine("3. Menampilkan Data");
                    Console.WriteLine("4. Exit");
                    Console.WriteLine("\npilihlah(1 - 4): ");
                    Console.WriteLine("================================");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                dl.addNode();
                            }
                            break;
                        case '2':
                            {
                                if (dl.listEmpty() == true)
                                {
                                    Console.WriteLine("Kosong");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.WriteLine("Masukan dosis data: ");
                                int dosis_obat = Convert.ToInt32(Console.ReadLine());
                                if (dl.search(dosis_obat, ref prev, ref curr) == false)
                                    Console.WriteLine("Data tidak ada");
                                else
                                {
                                    Console.WriteLine("ID Obat: " + curr.id_obat);
                                    Console.WriteLine("Nama Obat: " + curr.nama_obat);
                                    Console.WriteLine("Dosis Obat: " + curr.dosis_obat);
                                    Console.WriteLine("Harga Obat: " + curr.harga_obat);
                                }
                            }
                            break;
                        case '3':
                            {

                                dl.display();
                            }
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Mohon lihat ulang");
                }
            }

        }
    }
}


// ESSAY
// 2. Algoritma Singly List karena algoritma ini saya rasa cocok dengan studi kasus pada soal
// 3. Linked List memakai node, sedangkan array digunakan jika data yang dimasukan dalam jumlah banyak
// 4. Rear dan Front
// 5. (a) 4 Level
//    (b) Preorder
//    Steps for traversing a tree in preorder sequence are as follows:
//      1.Visit root
//      2.Traverse the left subtree
//      3. Traverse the right subtree
//      60, 41, 16, 25, 53, 46, 42, 55,   74, 65, 63, 62, 64, 70