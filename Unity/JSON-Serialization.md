# JSON Serialization

最开始的需求：从网上获取JSON字符串，将JSON转换为object并在程序中使用。这个时候，我们使用JsonUtility来处理JSON，完全够用了。  

后来JSON字符串中包含了Array数组，JsonUtility处理Array数组比较困难，对开发者来说，不够友好，不够简洁。这是我自己的使用感受。  

于是开始寻找替代方案，便发现了JSON .NET For Unity。使用JSON .NET处理Array数组，感觉简单轻松多了 : )


## 解决方案
1. Unity官方自带的JsonUtility
2. 第三方库JSON .NET For Unity

## JsonUtility
### JsonUtility Code Sample

```C#
void TestJsonUtility()
{
	MyClass myObject = new MyClass();
	myObject.level = 1;
	myObject.timeElapsed = 47.5f;
	myObject.playerName = "Charles";

	string json = JsonUtility.ToJson(myObject);
	Debug.LogFormat("json={0}", json);
}
```

### Output of JsonUtility Code Sample
	json={"level":1,"timeElapsed":47.5,"playerName":"Charles"}
  
## JSON .NET For Unity
### JSON .NET Code Sample

```C#
public class Prop
{
    public int id;
    public string name;
}

public class MyClass
{
    public int level;
    public float timeElapsed;
    public string playerName;
    public Prop[] props;
}

void TestJSONNet()
{
    MyClass myObject1 = new MyClass();
    myObject1.level = 1;
    myObject1.timeElapsed = 47.5f;
    myObject1.playerName = "Charles";

    myObject1.props = new Prop[]
    {
        new Prop() {id = 1, name = "p1"},
        new Prop() {id = 2, name = "p2"},
        new Prop() {id = 3, name = "p3"},
    };

    var json = JsonConvert.SerializeObject(myObject1);
    var myObject2 = JsonConvert.DeserializeObject<MyClass>(json);

    for (int i = 0; i < myObject2.props.Length; i++)
    {
        var prop = myObject2.props[i];
        Debug.LogFormat("prop {0}: id={1} name={2}", i, prop.id, prop.name);
    }
}
```

### Output of JSON .NET Code Sample
prop 0: id=1 name=p1  
prop 1: id=2 name=p2  
prop 2: id=3 name=p3  



