using System.Diagnostics;

char[] sliceArray(char[] arr, int start, int end)
{
    char[] newArr = new char[end - start];
    int index = 0;
    for (int i = start; i < end; i++)
    {
        newArr[index] = arr[i];
        index++;
    }
    return newArr;
}
char[] rotateArray(char[] array, int length)
{
    char[] endHalf = sliceArray(array, 0, length);
    char[] startHalf = sliceArray(array, length, array.Length);
    return startHalf.Concat(endHalf).ToArray();
}

char[] vocab = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };



char[][] smallSum = {
    vocab,
    rotateArray(vocab, 1),
    rotateArray(vocab, 2),
    rotateArray(vocab, 3),
    rotateArray(vocab, 4),
    rotateArray(vocab, 5),
    rotateArray(vocab, 6),
    rotateArray(vocab, 7),
    rotateArray(vocab, 8),
    rotateArray(vocab, 9)
};



char[] addSmall(char a, char b)
{
    int aNum = Array.IndexOf(vocab, a);
    int bNum = Array.IndexOf(vocab, b);
    char drop = smallSum[aNum][bNum];
    char carry = '0';
    if (vocab.Length - bNum <= aNum)
    {
        carry = '1';
    }
    return [carry, drop];
}

string Addition(string a, string b)
{
    if (b == "0") return a;
    if (a == "0") return b;

    List<char> result = new List<char>();
    char carry = '0';

    string longer = a.Length > b.Length ? a : b;
    string shorter = a.Length <= b.Length ? a : b;

    while (shorter.Length < longer.Length)
    {
        shorter = "0" + shorter;
    }

    for (var i = longer.Length - 1; i >= 0; i--)
    {
        char[] sum = addSmall(longer[i], shorter[i]);
        char tempCarry = sum[0];
        sum = addSmall(sum[1], carry);
        carry = addSmall(tempCarry, sum[0])[1];
        result.Add(sum[1]);
    }

    string s = "";

    for (int i = result.Count - 1; i >= 0; i--)
    {
        s += result[i].ToString();
    }

    return carry == '0' ? s : carry + s;
}





Random rand = new Random();

void Test()
{
    for (int i = 0; i < 10000; i++)
    {
        for (int j = 0; j < 100; j++)
        {
            int aNum = (int)rand.Next()/2;
            int bNum = (int)rand.Next()/2;
            int sum = aNum + bNum;

            string a = aNum.ToString();
            string b = bNum.ToString();
            try
            {
                if (sum.ToString() == Addition(a, b))
                {

                }
                else
                {
                    Console.WriteLine("a: " + a + ", b: " + b);
                    Console.WriteLine(sum.ToString() + ", not, " + Addition(a, b));
                    return;
                }
            } catch
            {
                Console.WriteLine(i + " " + j);


                return;
            }
        }
    }
    Debug.WriteLine("Passed!");
}

Test();