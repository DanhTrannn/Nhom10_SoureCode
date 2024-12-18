﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Security.AccessControl;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace datastructure
{
    public struct Customer
    {
        public string id;
        public string name;
        public string phoneNumber;
        public Customer(string id, string name, string phoneNumber)
        {
            this.id = id;
            this.name = name;
            this.phoneNumber = phoneNumber;
        }
        // Ghi đè lại phương thức khi in ra màn hình
        public override string ToString() => $"Customer: {id}, {name}, {phoneNumber}";
    }

    public struct Movies
    {
        public string movieID;
        public string movieName;
        public string genre;
        public string duration;
        public Movies(string movieID, string movieName, string genre, string duration)
        {
            this.movieID = movieID;
            this.movieName = movieName;
            this.genre = genre; 
            this.duration = duration;
        }
        public override string ToString() => $"Movie: {movieID}, {movieName}, {genre}, {duration}";
    }

    public struct ShowTime
    {
        public string movieID;
        public DateTime showDateTime;
        public string hall;
        public ShowTime(string movieID, DateTime showDateTime, string hall)
        {
            this.movieID = movieID;
            this.showDateTime = showDateTime;
            this.hall = hall;
        }
        public override string ToString() => $"ShowTime: {showDateTime}, {hall}";
    }

    public class Node<T>
    {
        public T data;
        public Node<T> next;
        public Node(T data)
        {
            this.data = data;
            this.next = null;
        }
    }
    public class LinkedList<T>
    {
        public Node<T> head;
        public int size;
        public LinkedList()
        {
            head = null;
            size = 0;
        }
        public bool isEmpty()
        {
            return size == 0;
        }
        public void AddLast(T data)
        {
            Node<T> newNode = new Node<T>(data);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node<T> current = head;
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = newNode;
            }
            size++;
        }
        // Xoá một Node theo một biểu thức điều kiện cụ thể
        public void Remove(Predicate<T> match)
        {
            if (head == null) return;
            if (match(head.data))
            {
                head = head.next;
                size--;
                return;
            }

            Node<T> current = head;
            while (current.next != null && !match(current.next.data))
            {
                current = current.next;
            }
            if (current.next != null)
            {
                current.next = current.next.next;
                size--;
            }
        }
        public T Find(Predicate<T> match)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (match(current.data))
                {
                    // Trả về phần tử nếu thỏa mãn điều kiện
                    return current.data;
                }
                current = current.next;
            }
            // Trả về giá trị mặc định nếu không tìm thấy
            return default(T); 
        }
        public bool Update(Predicate<T> match, T newData)
        {
            Node<T> current = head;
            while(current != null)
            {
                if (match(current.data))
                {
                    current.data = newData;
                    return true;   
                }
                current = current.next;
            }
            return false;
        }
        public void Display()
        {
            Node<T> tmp = head;
            while (tmp != null)
            {
                Console.WriteLine(tmp.data);
                tmp = tmp.next;
            }
            Console.WriteLine();
        }
    }
    public class Queue<T>
    {
        private Node<T> front;
        private Node<T> rear;
        private int size;
        public int Count
        {
            get
            {
                return size;
            }
        }
        public Queue()
        {
            front = null;
            rear = null;
            size = 0;
        }
        public bool isEmpty()
        {
            return size == 0;
        }
        public void Enqueue(T value)
        {
            Node<T> newNode  = new Node<T>(value);
            if (rear == null)
            {
                front = newNode;
                rear = newNode;
            }
            else
            {
                rear.next = newNode;
                rear = newNode;
            }
            size++;
        }
        public T Dequeue()
        {
            if (front == null)
            {
                throw new Exception("Queue is Empty!");
            }
            Node<T> tmp = front;
            front = tmp.next;
            T tempValue = tmp.data;
            if (front == null)
            {
                rear = null;
            }
            size--;
            return tempValue;
        }
        public T Peek()
        {
            if (front == null)
            {
                throw new Exception("Queue is Empty!");
            }
            return front.data;
        }
        public void Display()
        {
            if (isEmpty())
            {
                return;
            }
            for (Node<T> current = front; current != null; current = current.next)
            {
                Console.WriteLine(current.data);
            }
        }
    }
    public class Stack<T>
    {
        private Node<T> top;
        private int size;
        public Stack()
        {
            top = null;
            size = 0;
        }
        public int Count()
        {
            Node<T> tmp = top;
            int count = 0;
            while(tmp != null)
            {
                count++;
                tmp = tmp.next;
            }
            return count;   
        }
        public bool IsEmpty()
        {
            return size == 0;
        }
        public void Push(T value)
        {
            Node<T> newNode = new Node<T>(value);
            if (top == null)
            {
                top = newNode;
                return;
            }
            newNode.next = top;
            top = newNode;
            size++;
        }
        public T Pop()
        {
            if (top == null)
            {
                throw new Exception("Stack is empty!");
            }
            Node<T> nodeTemp = top;
            top = nodeTemp.next;
            T tempValue = nodeTemp.data;
            size--;
            nodeTemp = null;
            return tempValue;
        }
        public T Peek()
        {
            if (top == null)
            {
                throw new Exception("Stack is Empty!");
            }
            return top.data;
        }
        public void Clear()
        {
            Node<T> tempNode;
            while (top != null)
            {
                tempNode = top;
                top = tempNode.next;
                tempNode = null;
            }
            size = 0;
        }
    }
    public class DataStructure
    {
        public Queue<Customer> line = new Queue<Customer>();
        public LinkedList<Customer> customers = new LinkedList<Customer>();
        public LinkedList<Movies> movies = new LinkedList<Movies>();
        public LinkedList<ShowTime> showtimes = new LinkedList<ShowTime>();
        public Stack<UndoAction> undo = new Stack<UndoAction>();
    }
    public class UndoAction
    {
        public string action;
        public Customer oldcustomer;
        public Movies oldmovie;
        public ShowTime oldshowtime;
        public UndoAction(string action, Customer oldcustomer)
        {
            this.action = action;
            this.oldcustomer = oldcustomer;
        }
        public UndoAction(string action, Movies oldmovie)
        {
            this.action = action;
            this.oldmovie = oldmovie;
        }
        public UndoAction(string action, ShowTime oldshowtime)
        {
            this.action = action;
            this.oldshowtime = oldshowtime;
        }
    }
}
