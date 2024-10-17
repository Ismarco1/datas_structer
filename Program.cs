// muqtada mohammed hadi
class stack
{
    private int[] elements;
    private int top;
    private int capacity;

    public stack(int l)
    {
        capacity = l;
        elements = new int[capacity];
        top = -1;
    }

    public void push(int item)
    {
        if (isfull())
        {
            throw new ArgumentOutOfRangeException("stack is overflow");
        }
        else
        {
            elements[++top] = item;
        }
    }

    public int pop()
    {
        if (isempty())
        {
            throw new ArgumentOutOfRangeException("the stack is empty");
        }
        else
        {
            return elements[top--];
        }
    }

    public bool isempty()
    {
        return (top == -1);
    }

    public bool isfull()
    {
        return (top >= capacity - 1);
    }

    public int size()
    {
        return top + 1;
    }

    public int peek()
    {
        return elements[top];
    }

    // اضافة لمعرفة عدد العناصر الزوجية و الفردية
    public void count_even_odd(out int evenCount, out int oddCount)
    {
        evenCount = 0;
        oddCount = 0;

        for (int i = 0; i <= top; i++)
        {
            if (elements[i] % 2 == 0)
            {
                evenCount++;
            }
            else
            {
                oddCount++;
            }
        }
    }
}

class StackDivider
{
    public void divided_stack(stack originalStack, out stack evenstack, out stack oddstack)
    {
        originalStack.count_even_odd(out int evenCount, out int oddCount);

        evenstack = new stack(evenCount);
        oddstack = new stack(oddCount);

        // يجب استخدام pop لأخذ العنصر من الستاك الأصلي وليس peek
        while (!originalStack.isempty())
        {
            int item = originalStack.pop(); // نحذف العنصر من الستاك
            if (item % 2 == 0)
            {
                evenstack.push(item);
            }
            else
            {
                oddstack.push(item);
            }
        }
    }
}

class program
{
    static void Main()
    {
        stack mystack = new stack(5);
        mystack.push(1);
        mystack.push(2);
        mystack.push(3);
        mystack.push(4);
        mystack.push(5);

        StackDivider divider = new StackDivider();
        divider.divided_stack(mystack, out stack evenstack, out stack oddstack);

        Console.WriteLine("Even stack: ");
        while (!evenstack.isempty())
        {
            Console.WriteLine(evenstack.pop());
        }

        Console.WriteLine("Odd stack: ");
        while (!oddstack.isempty())
        {
            Console.WriteLine(oddstack.pop());
        }
    }
}
