using System;
using System.Collections;
using System.Collections.Generic;
using Wintellect.PowerCollections;
using System.Linq;

public class Instock : IProductStock
{
    Dictionary<string, LinkedListNode<Product>> fastRetrievalByLabel = 
        new Dictionary<string, LinkedListNode<Product>>();
    List<Product> byInsertion = new List<Product>();
    Dictionary<int, LinkedList<Product>> byQuantity =
        new Dictionary<int, LinkedList<Product>>();
    OrderedBag<Pair<double, Product>> byPrice =
        new OrderedBag<Pair<double, Product>>((x, y) => y.First.CompareTo(x.First));
    SortedDictionary<string, Product> byLabel =
        new SortedDictionary<string, Product>();

    public int Count => this.byInsertion.Count;

    public void Add(Product product)
    {
        this.byInsertion.Add(product);
        this.byLabel.Add(product.Label, product);
        this.byPrice.Add(new Pair<double, Product>(product.Price, product));
        LinkedListNode<Product> node = new LinkedListNode<Product>(product);
        if (!this.byQuantity.ContainsKey(product.Quantity))
        {
            this.byQuantity.Add(product.Quantity, new LinkedList<Product>());
        }
        this.byQuantity[product.Quantity].AddLast(node);
        this.fastRetrievalByLabel.Add(product.Label, node);
    }

    public void ChangeQuantity(string label, int quantity)
    {
        if (!this.fastRetrievalByLabel.ContainsKey(label))
        {
            throw new ArgumentException();
        }
        
        LinkedListNode<Product> node = this.fastRetrievalByLabel[label];
        int oldQuantity = node.Value.Quantity;
        this.byQuantity[oldQuantity].Remove(node);
        node.Value.Quantity = quantity;
        if (!this.byQuantity.ContainsKey(quantity))
        {
            this.byQuantity.Add(quantity, new LinkedList<Product>());
        }
        this.byQuantity[quantity].AddLast(node);
    }


    public bool Contains(Product product)
    {
        return this.fastRetrievalByLabel.ContainsKey(product.Label);
    }

    public Product Find(int index)
    {
        if(index < 0 || index >= this.byInsertion.Count)
        {
            throw new IndexOutOfRangeException();
        }
        return this.byInsertion[index];
    }

    public IEnumerable<Product> FindAllByPrice(double price)
    {
        Pair<double, Product> pair = new Pair<double, Product>(price, null);
        IEnumerable<Pair<double, Product>> enumeration = this.byPrice.Range(pair, true, pair, true);
        foreach(var item in enumeration)
        {
            yield return item.Second;
        }
    }

    public IEnumerable<Product> FindAllByQuantity(int quantity)
    {
        if (this.byQuantity.ContainsKey(quantity))
        {
            return this.byQuantity[quantity];
        }
        return new List<Product>();
    }

    public IEnumerable<Product> FindAllInRange(double lo, double hi)
    {
        Pair<double, Product> start = new Pair<double, Product>(lo, null);
        Pair<double, Product> end = new Pair<double, Product>(hi, null);
        IEnumerable<Pair<double, Product>> enumeration = this.byPrice.Range(end, true, start, false);
        foreach (var item in enumeration)
        {
            yield return item.Second;
        }
    }

    public Product FindByLabel(string label)
    {
        if (!this.fastRetrievalByLabel.ContainsKey(label))
        {
            throw new ArgumentException();
        }
        return this.fastRetrievalByLabel[label].Value;
    }


    public IEnumerable<Product> FindFirstByAlphabeticalOrder(int count)
    {
        if(count < 0 || count > this.Count)
        {
            throw new ArgumentException();
        }
        
        foreach(var item in this.byLabel.Take(count))
        {
            yield return item.Value;
        }
    }

    public IEnumerable<Product> FindFirstMostExpensiveProducts(int count)
    {
        if(count <= 0 || count > this.Count)
        {
            throw new ArgumentException();
        }
        IEnumerable<Pair<double, Product>> products = this.byPrice.Take(count);
        List<Product> result = new List<Product>();
        foreach(var item in products)
        {
            result.Add(item.Second);
        }
        return result;
    }

    public IEnumerator<Product> GetEnumerator()
    {
        return this.byInsertion.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
