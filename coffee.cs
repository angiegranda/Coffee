using System;
using System.Collections.Generic;
using static System.Console;


interface PriorityQueue<T> {
    int count { get; }
    void add(T elem, double priority);
    (T, double) extractMax();
}

class CoffeRoom<T> : PriorityQueue<T> {

    private List<(double, T)> coffee;
    
    public CoffeRoom() {
        coffee = new List<(double, T)>();
    }

    public int count {
        get { return coffee.Count; }
    }

    private int left(int i) {
        return 2 * i + 1;
    }

    private int right(int i) {
        return 2 * i + 2;
    }

    private int parent(int i) {
        return (i - 1) / 2;
    }

    private void up_heap(int i) {
        while (i > 0 && coffee[i].Item1 > coffee[parent(i)].Item1) {
            (double, T) temp = coffee[i];
            coffee[i] = coffee[parent(i)];
            coffee[parent(i)] = temp;
            i = parent(i);
        }
    }

    private void down_heap(int i) {

        int currentIndex = i;
        int leftChild = left(i);
        if (leftChild < coffee.Count && coffee[leftChild].Item1 > coffee[currentIndex].Item1) {
            currentIndex = leftChild;
        }
        int rightChild = right(i);
        if (rightChild < coffee.Count && coffee[rightChild].Item1 > coffee[currentIndex].Item1) {
            currentIndex = rightChild;
        }
        if (i != currentIndex) {
            (double, T) data = heapArr[i];
            coffee[i] = coffee[currentIndex];
            coffee[currentIndex] = data;
            down_heap(currentIndex);
        }
    }

    public void add(T elem, double priority) {
        coffee.Add((priority, elem));
        up_heap(coffee.Count - 1);
    }

    public (T, double) extractMax() {
        if (coffee.Count == 0) {
            throw new InvalidOperationException("Coffee is empty");
        }
        (double, T) maxItem = heapArr[0];
        coffee[0] = coffee[heapArr.Count - 1];
        coffee.RemoveAt(coffee.Count - 1);
        down_heap(0);
        return (maxItem.Item2, maxItem.Item1);
    }
}

class Program {
    static void Main() {

        int roomCapacity = int.Parse(Console.ReadLine()!);

        CoffeRoom<string> coffee = new CoffeRoom<string>();
        List<(string, double)> data = new List<(string, double)>();

        string inputLine;
        while (!string.IsNullOrEmpty(inputLine = Console.ReadLine())) {
            string[] info = inputLine.Trim().Split(" ");
            data.Add((info[0], double.Parse(info[1])));
        }

        int limit = (data.Count < roomCapacity) ? data.Count : roomCapacity;
        int employeeCurrentOrder = 0;

        while (employeeCurrentOrder < limit) {
            (string name, double priority) info = data[employeeCurrentOrder];
            coffee.add(info.name, info.priority);
            employeeCurrentOrder++;
        }

        while (coffee.count > 0) {
            var maxPriorityEmployee = coffee.extractMax();
            Console.WriteLine($"{maxPriorityEmployee.Item1} {maxPriorityEmployee.Item2:f1}");
            if (employeeCurrentOrder < data.Count){
                (string name, double priority) info = data[employeeCurrentOrder];
                coffee.add(info.name, info.priority);
                employeeCurrentOrder++;
            }
        }
    }
}
