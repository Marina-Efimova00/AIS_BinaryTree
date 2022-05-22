using System;

namespace AIS_BinaryTree
{
    class Program
    {

        class MyClass
        {
            class Tree
            {
                private string value;
                private int count;
                private Tree left;
                private Tree right;
                // вставка
                public void Insert(string value)
                {
                    if (this.value == null)
                        this.value = value;
                    else
                    {
                        if (this.value.CompareTo(value) == 1)
                        {
                            if (left == null)
                                this.left = new Tree();
                            left.Insert(value);
                        }
                        else if (this.value.CompareTo(value) == -1)
                        {
                            if (right == null)
                                this.right = new Tree();
                            right.Insert(value);
                        }
                        else
                            throw new Exception("Узел уже существует");
                    }

                    this.count = Recount(this);
                }
                // поиск
                public Tree Search(string value)
                {


                    if (this.value == value)
                        return this;
                    else if (this.value.CompareTo(value) == 1)
                    {
                        if (left != null)
                            return this.left.Search(value);
                        else
                            throw new Exception("Искомого узла в дереве нет");
                    }
                    else
                    {
                        if (right != null)
                            return this.right.Search(value);
                        else
                            throw new Exception("Искомого узла в дереве нет");
                    }
                }
                // отображение в строку
                public string Display(Tree t)
                {
                    string result = "";
                    if (t.left != null)
                        result += Display(t.left);

                    result += t.value + " ";

                    if (t.right != null)
                        result += Display(t.right);

                    return result;
                }


                // подсчет
                public int Recount(Tree t)
                {
                    int count = 0;

                    if (t.left != null)
                        count += Recount(t.left);

                    count++;

                    if (t.right != null)
                        count += Recount(t.right);

                    return count;
                }
                // очистка
                public void Clear()
                {
                    this.value = null;
                    this.left = null;
                    this.right = null;
                }
                // проверка пустоты
                public bool IsEmpty()
                {
                    if (this.value == null)
                        return true;
                    else
                        return false;
                }


                //удаление
                public void Remove(string value)
                {
                    Tree t = Search(value);
                    string[] str1 = Display(t).TrimEnd().Split(' ');
                    string[] str2 = new string[str1.Length - 1];

                    int i = 0;
                    foreach (string s in str1)
                    {
                        if (s != value)
                            str2[i++] = s;
                    }

                    t.Clear();
                    foreach (string s in str2)
                        t.Insert(s);

                    this.count = Recount(this);
                }
            }
            static void Main(string[] args)
            {
                Tree tr = new Tree();
                tr.Insert("5");
                tr.Insert("3");
                tr.Insert("55");
                tr.Insert("84");
                tr.Insert("57");
                tr.Insert("83");
                tr.Insert("2");
                tr.Insert("8888");
                Console.Write(tr.Display(tr));
                tr.Remove("55");
                tr.Remove("83");
                Console.WriteLine();
                Console.WriteLine(tr.Display(tr));
                Console.WriteLine();
                Console.ReadLine();
            }
        }
    }
}
