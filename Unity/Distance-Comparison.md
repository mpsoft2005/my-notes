# Distance Comparison

使用Unity开发过程中，比较距离是最常见的操作之一，例如：判断一个目标是否在有效范围之内。

## Distance Comparison Method

最直观的代码示例如下：
```C#
var heading = target.position - player.position;
var distance = heading.magnitude;
if (distance < maxRange) {
    // target is within range
}
```

计算magnitude需要求平方根，这个过程比较耗时。如果我们只是想判断目标是否在有效范围之内，可以使用sqrMagnitude：
```C#
var heading = target.position - player.position;
var sqrDistance = heading.sqrMagnitude;
if (sqrDistance < maxRange * maxRange) {
    // target is within range
}
```

