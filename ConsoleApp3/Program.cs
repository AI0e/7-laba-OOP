using System;

public class DoublyLinkedList
{
    public class Node
    {
        public double Data;
        public Node Prev;
        public Node Next;

        public Node(double data)
        {
            Data = data;
            Prev = null;
            Next = null;
        }
    }

    private Node head;

    public DoublyLinkedList()
    {
        head = null;
    }

    public void AddFirst(double data)
    {
        Node newNode = new Node(data);
        if (head == null)
        {
            head = newNode;
        }
        else
        {
            newNode.Next = head;
            head.Prev = newNode;
            head = newNode;
        }
    }

    public void RemoveElementsBeforeMax()
    {
        double max = head.Data;
        Node current = head.Next;

        while (current != null)
        {
            if (current.Data > max)
            {
                max = current.Data;
            }
            current = current.Next;
        }

        current = head;

        while (current != null && current.Data < max)
        {
            head = current.Next;
            current = head;
        }

        if (current == null)
        {
            return;
        }

        //Node prev = current;
        //current = current.Next;

        //while (current != null)
        //{
        //    if (current.Data < max)
        //    {
        //        prev.Next = current.Next;
        //    }
        //    else
        //    {
        //        prev = current;
        //    }
        //    current = current.Next;
        //}
    }

    public void PrintList()
    {
        Node current = head;
        while (current != null)
        {
            Console.Write(current.Data + "; ");
            current = current.Next;
        }
        Console.WriteLine();
    }

    public void PrintFirstPositive()
    {
        Node current = head;

        while (current != null)
        {
            if (current.Data > 0)
            {
                Console.WriteLine("Це перший позитивний елемент: " + current.Data);
                return;
            }
            current = current.Next;
        }

        Console.WriteLine("У списку немає позитивного елементу.");
    }

    public int CountElementsLessThanAverage()
    {
        double sum = 0;
        int count = 0;
        Node current = head;

        while (current != null)
        {
            sum += current.Data;
            count++;
            current = current.Next;
        }

        double average = sum / count;

        int lessThanAverageCount = 0;
        current = head;

        while (current != null)
        {
            if (current.Data < average)
            {
                lessThanAverageCount++;
            }
            current = current.Next;
        }

        return lessThanAverageCount;
    }

    public DoublyLinkedList GetValuesGreaterThanAverage()
    {
        double sum = 0;
        int count = 0;
        Node current = head;

        while (current != null)
        {
            sum += current.Data;
            count++;
            current = current.Next;
        }

        double average = sum / count;

        DoublyLinkedList newList = new DoublyLinkedList();
        current = head;

        while (current != null)
        {
            if (current.Data > average)
            {
                newList.AddFirst(current.Data);
            }
            current = current.Next;
        }

        return newList;
    }

    public double this[int index]
    {
        get
        {
            Node current = head;
            int currentIndex = 0;
            while (current != null)
            {
                if (currentIndex == index)
                {
                    return current.Data;
                }
                current = current.Next;
                currentIndex++;
            }
            throw new IndexOutOfRangeException("Iндекс поза межами списку");
        }
        set
        {
            Node current = head;
            int currentIndex = 0;
            while (current != null)
            {
                if (currentIndex == index)
                {
                    current.Data = value;
                    return;
                }
                current = current.Next;
                currentIndex++;
            }
            throw new IndexOutOfRangeException("Iндекс поза межами списку");
        }
    }

    public int Count
    {
        get
        {
            int count = 0;
            Node current = head;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }
    }
}

class Program
{
    static void Main()
    {
        DoublyLinkedList list = new DoublyLinkedList();

        list.AddFirst(2.3);
        list.AddFirst(-53.2);
        list.AddFirst(9.1);
        list.AddFirst(-13.3);
        list.AddFirst(7.77);
        list.AddFirst(-6.66);
        list.PrintList();
        Console.WriteLine(list[4]);
        list[4] = 47;
        Console.WriteLine(list[4]);
        Console.WriteLine(list.Count);
        list.PrintFirstPositive();
        int lessthanaverangecount = list.CountElementsLessThanAverage();
        DoublyLinkedList Secondlist = new DoublyLinkedList();
        Secondlist = list.GetValuesGreaterThanAverage();

        Console.WriteLine($"Кiлькiсть елементiв менших за середнє значення: {lessthanaverangecount}");
        Console.WriteLine("Новий лист зi значеннями бiльшими за середнє значення:");
        Secondlist.PrintList();
        Console.WriteLine("Перший лист пiсля видалення елементiв, якi знаходяться до максимального числа:");
        list.RemoveElementsBeforeMax();
        list.PrintList();
    }
}