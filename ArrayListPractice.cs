using System.Collections;

class ArrayListPractice
{
    public static void Main()
    {
        var arrList1 = new ArrayList()
        {"Avanti Vihar",
         "Raipur"
        };
        var arrList = new ArrayList();
        arrList.Add(1);
        arrList.Add("Shivansh");
        arrList.Add("Cdac Acts");
        for (int i = 0; i < arrList.Count; i++)
        {
            Console.WriteLine(arrList[i]);
        }
        Console.WriteLine("****************************");
        arrList.Insert(2, "Shankaracharya");
        arrList.InsertRange(2, arrList1);
        for (int i = 0; i < arrList.Count; i++)
        {
            Console.WriteLine(arrList[i]);
        }
        ArrayList cloneArrList = (ArrayList)arrList.Clone();
        Console.WriteLine("****************************");
        arrList.Remove(1);
        for (int i = 0; i < arrList.Count; i++)
        {
            Console.WriteLine(arrList[i]);
        }
        Console.WriteLine("****************************");
        arrList.RemoveAt(arrList.Count - 1);
        for (int i = 0; i < arrList.Count; i++)
        {
            Console.WriteLine(arrList[i]);
        }
        Console.WriteLine("****************************");
        arrList.RemoveRange(1, 3);
        for (int i = 0; i < arrList.Count; i++)
        {
            Console.WriteLine(arrList[i]);
        }
        Console.WriteLine("****************************");
        for (int i = 0; i < cloneArrList.Count; i++)
        {
            Console.WriteLine(cloneArrList[i]);
        }
        ArrayList arrayList = new ArrayList()
            {
                    "India",
                    "USA",
                    "UK",
                    "Denmark",
                    "Nepal",
                    "HongKong",
                    "Austrailla",
                    "Srilanka",
                    "Japan",
                    "Britem",
                    "Brazil",
            };
        Console.WriteLine("Array List Elements Before Sorting:");
        foreach (var item in arrayList)
        {
            Console.Write($"{item} ");
        }
        arrayList.Sort();
        Console.WriteLine("\nArray List Elements After Sorting:");
        foreach (var item in arrayList)
        {
            Console.Write($"{item} ");
        }
    }


}
