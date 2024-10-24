using System.Reflection.Metadata.Ecma335;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

char[] punchHolesInArray(char[] array, int frequency, int length)
{
    char[] result = new char[length];
    int index = 0;
    for (int i = 0; i < length; i++)
    {
        result[i] = array[index % array.Length];
        index += frequency;
    }
    return result;
}

char[] divisibleIndexes(char[] array, int index)
{
    if (index == 0) { return array; }
    char[] result = new char[array.Length];
    result[0] = array[0];
    for (int i = 1; i < result.Length; i++)
    {
        int j = (int)Math.Floor((decimal)((i - 1) / index));
        if (j < 0) j = 0;
        result[i] = array[j];
    }
    return result;
}

string zeroList(int num)
{
    string s = "";
    while (s.Length < num)
    {
        s += "0";
    }
    return s;
}

//char[] vocab = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
 char[] vocab = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };

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
    rotateArray(vocab, 9),
    rotateArray(vocab, 10),
    rotateArray(vocab, 11),
    rotateArray(vocab, 12),
    rotateArray(vocab, 13),
    rotateArray(vocab, 14),
    rotateArray(vocab, 15)
};

char[][] smallProduct = {
    punchHolesInArray(vocab, 0, vocab.Length),
    punchHolesInArray(vocab, 1, vocab.Length),
    punchHolesInArray(vocab, 2, vocab.Length),
    punchHolesInArray(vocab, 3, vocab.Length),
    punchHolesInArray(vocab, 4, vocab.Length),
    punchHolesInArray(vocab, 5, vocab.Length),
    punchHolesInArray(vocab, 6, vocab.Length),
    punchHolesInArray(vocab, 7, vocab.Length),
    punchHolesInArray(vocab, 8, vocab.Length),
    punchHolesInArray(vocab, 9, vocab.Length),
    punchHolesInArray(vocab, 10, vocab.Length),
    punchHolesInArray(vocab, 11, vocab.Length),
    punchHolesInArray(vocab, 12, vocab.Length),
    punchHolesInArray(vocab, 13, vocab.Length),
    punchHolesInArray(vocab, 14, vocab.Length),
    punchHolesInArray(vocab, 15, vocab.Length)
};

/*
 0 0 0 0 0 0 0 0 0 0
 0 0 0 0 0 0 0 0 0 0
 0 0 0 0 0 1 1 1 1 1
 0 0 0 0 1 1 1 2 2 2
 0 0 0 1 1 2 2 2 3 3
 0 0 1 1 2 2 3 3 4 4
 0 0 1 1 2 3 3 4 4 5
 0 0 1 2 2 3 4 4 5 6
 0 0 1 2 3 4 4 5 6 7
 0 0 1 2 3 4 5 6 7 8
 */

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

char[] multiplySmall(char a, char b)
{
    if (a == '0' || b == '0') return ['0'];

    int aNum = Array.IndexOf(vocab, a);
    int bNum = Array.IndexOf(vocab, b);
    char drop = smallProduct[aNum][bNum];
    int carryIndex = (int)Math.Floor((decimal)((aNum * bNum) / vocab.Length));
    char carry = vocab[carryIndex];

    return [carry, drop];
}

string Multiplication(string a, string b)
{
    if (a == "0") return "0";
    if (b == "0") return "0";

    int index = 0;

    string longer = a.Length > b.Length ? a : b;
    string shorter = a.Length <= b.Length ? a : b;

    a = longer;
    b = shorter;

    string[] sums = new string[a.Length];

    for (int i = a.Length - 1; i >= 0; i--)
    {
        List<char> result = new List<char>();
        char carry = '0';

        for (int j = b.Length - 1; j >= 0; j--)
        {
            string product = new string(multiplySmall(a[i], b[j]));
            string sum = Addition(product, new string([carry]));
            if (sum.Length == 1)
            {
                result.Add(sum[0]);
                carry = '0';
            } else
            {
                result.Add(sum[1]);
                carry = sum[0];
            }
        }

        string s = "";

        for (int j = result.Count - 1; j >= 0; j--)
        {
            s += result[j].ToString();
        }


        sums[index] = (carry == '0' ? "" : carry) + s + zeroList(index);
        index++;
    }

    string total = "0";

    for (int i = 0; i < sums.Length; i++)
    {
        total = Addition(total, sums[i]);
    }

    return total;
}



Random rand = new Random();

void Test()
{
    for (int i = 0; i < 1000; i++)
    {
        for (int j = 0; j < 1000; j++)
        {
            Console.WriteLine("a: " + i + ", b: " + j);
            int product = i * j;
            string prediction = Multiplication(i.ToString(), j.ToString());

            if (prediction != product.ToString())
            {
                Console.WriteLine(i + " * " + j + " should equal " + product + ", not: " + prediction);
                return;
            }
        }

    }
    Console.WriteLine("Passed!");
}

Console.WriteLine(Multiplication("f", "123adfe"));
