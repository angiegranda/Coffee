using System;
using System.Collections.Generic;
using static System.Console;


interface PriorityQueue<T> {
    int count { get; }
    void add(T elem, double priority);
    (T, double) extractMax();
}

class BinaryHeap<T> : PriorityQueue<T> {

    private List<(double, T)> heapArr;
    
    public BinaryHeap() {
        heapArr = new List<(double, T)>();
    }

    public int count {
        get { return heapArr.Count; }
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
        while (i > 0 && heapArr[i].Item1 > heapArr[parent(i)].Item1) {
            (double, T) temp = heapArr[i];
            heapArr[i] = heapArr[parent(i)];
            heapArr[parent(i)] = temp;
            i = parent(i);
        }
    }

    private void down_heap(int i) {

        int currentIndex = i;
        int leftChild = left(i);
        if (leftChild < heapArr.Count && heapArr[leftChild].Item1 > heapArr[currentIndex].Item1) {
            currentIndex = leftChild;
        }
        int rightChild = right(i);
        if (rightChild < heapArr.Count && heapArr[rightChild].Item1 > heapArr[currentIndex].Item1) {
            currentIndex = rightChild;
        }
        if (i != currentIndex) {
            (double, T) data = heapArr[i];
            heapArr[i] = heapArr[currentIndex];
            heapArr[currentIndex] = data;
            down_heap(currentIndex);
        }
    }

    public void add(T elem, double priority) {
        heapArr.Add((priority, elem));
        up_heap(heapArr.Count - 1);
    }

    public (T, double) extractMax() {
        if (heapArr.Count == 0) {
            throw new InvalidOperationException("Coffee is empty");
        }
        (double, T) maxItem = heapArr[0];
        heapArr[0] = heapArr[heapArr.Count - 1];
        heapArr.RemoveAt(heapArr.Count - 1);
        down_heap(0);
        return (maxItem.Item2, maxItem.Item1);
    }
}

class Program {
    static void Main() {

        int roomCapacity = int.Parse(Console.ReadLine()!);

        BinaryHeap<string> maxHeap = new BinaryHeap<string>();
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
            maxHeap.add(info.name, info.priority);
            employeeCurrentOrder++;
        }

        while (maxHeap.count > 0) {
            var maxPriorityEmployee = maxHeap.extractMax();
            Console.WriteLine($"{maxPriorityEmployee.Item1} {maxPriorityEmployee.Item2:f1}");
            if (employeeCurrentOrder < data.Count){
                (string name, double priority) info = data[employeeCurrentOrder];
                maxHeap.add(info.name, info.priority);
                employeeCurrentOrder++;
            }
        }
    }
}
