# Collections使用注意事项

## Dictionary<TKey, TValue>

最常见的问题，在Dictionary中查找两次
```C#
if (myDictionary.Contains(myKey))
{
    int value = myDictionary[myKey];
    // do something
}
```

Contains进行第一次查找，索引器[]进行第二次查找。实际上只需要一次查找，代码如下
```C#
int myValue;
if (myDictionary.TryGetValue(myKey, out myValue))
{
    // do something
}
```

## List\<T>

使用List时，尽量显示指定Capacity。  

未指定Capacity时，List默认Capacity为0，当我们往List中添加元素时，Capacity会逐渐变大（依次为0,4,8,16,32,64,128...）  

每次Capacity变大，做以下操作：
```C#
  T[] array = new T[value];
  Array.Copy(_items, 0, array, 0, _size);
  _items = array;
```

因此在使用List的过程中，会导致大量的内存分配/复制/内存回收。指定一个适当的Capacity，可以减少许多的内存分配与复制。
尽量指定一个合理的Capacity，让程序运行地更快更好。
