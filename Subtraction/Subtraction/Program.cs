string alphabet = "0123456789abcdef";

string Reverse(string s)
{
    char[] charArray = s.ToCharArray();
    Array.Reverse(charArray);
    return new string(charArray);
}

string RemoveLeadingZeros(string a)
{
    int index = 0;
    while (a[index] == alphabet[0])
    {
        index++;
        if (index == a.Length)
        {
            return alphabet[0].ToString();
        }
    }
    return a.Substring(index);
}

bool lessThanTiny(char a, char b)
{
    if (alphabet.IndexOf(a) < alphabet.IndexOf(b))
    {
        return true;
    } else
    {
        return false;
    }
}

bool lessThan(string a, string b)
{
    if (a.Length > b.Length)
    {
        return false;
    } else if (a.Length < b.Length)
    {
        return true;
    } else
    {
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] != b[i])
            {
                return lessThanTiny(a[i], b[i]);
            }
        }
        return false;
    }

}

string oneOnOne(char a, char b)
{
    if (lessThanTiny(a, b))
    {
        return "-" + oneOnOne(b, a);
    } else
    {
        return alphabet[alphabet.IndexOf(a) - alphabet.IndexOf(b)].ToString();
    }
}


string carrySub(char a, char b)
{
    return alphabet[alphabet.IndexOf(a) + (alphabet.Length - alphabet.IndexOf(b))].ToString();
}

string Borrow(string a, int i)
{
    if (a[i + 1] != alphabet[0])
    {
        return a.Remove(i + 1, 1).Insert(i + 1, alphabet[alphabet.IndexOf(a[i + 1]) - 1].ToString()); 
    } else
    {
        return Borrow(a.Remove(i + 1, 1).Insert(i + 1, alphabet[alphabet.Length - 1].ToString()), i + 1);
    }
}

string Subtract(string a, string b)
{
    if (lessThan(a, b))
    {
        return "-" + Subtract(b, a);
    }
    a = Reverse(a);
    b = Reverse(b);

    string answer = "";
    for (int i = 0; i < a.Length; i++)
    {
        if (i < b.Length)
        {
            if (lessThanTiny(a[i], b[i]))
            {
                answer += carrySub(a[i], b[i]);
                a = Borrow(a, i);
            } else
            {
                answer += oneOnOne(a[i], b[i]);
            }
        } else
        {
            answer += a[i];
        }
    }
    return RemoveLeadingZeros(Reverse(answer));
}

void Test()
{
    for (int i = 0; i < 10000; i++)
    {
        for (int j = 500; j < 10000; j++)
        {
            string guess = Subtract(i.ToString(), j.ToString());
            if (guess != (i - j).ToString())
            {
                Console.WriteLine(i.ToString() + " - " + j.ToString() + " does not equal " + guess);
                return;
            }
        }
    }
    Console.WriteLine("Yay!");
}

Console.WriteLine(Subtract("3eb9", "3c7f"));
