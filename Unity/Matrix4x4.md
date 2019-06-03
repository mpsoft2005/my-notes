# Matrices in Unity

Unity中的Matrix是列优先的。OpenGL中的Matrix也是列优先的。  
1. [Unity Matrix](https://docs.unity3d.com/ScriptReference/Matrix4x4.html)
2. [OpenGL Matrix](https://open.gl/transformations)

## Translation Matrix

![translation matrix](https://github.com/mpsoft2005/MyNotes/blob/master/Unity/Images/matrix/translation-matrix.png?raw=true)

## Scaling Matrix

![Scaling Matrix](https://github.com/mpsoft2005/MyNotes/blob/master/Unity/Images/matrix/scaling-matrix.png?raw=true)

## Basic Rotation Matrix

![Basic rotations](https://github.com/mpsoft2005/MyNotes/blob/master/Unity/Images/matrix/basic-rotation-matrices.png?raw=true)

## Rotation Matrix

需要特别注意旋转顺序，[Unity的官方文档](https://docs.unity3d.com/ScriptReference/Quaternion-eulerAngles.html)中有说明，先绕z轴旋转，再绕x轴旋转，最后绕y轴旋转。  

```C#
R = Ry * Rx * Rz  
```

## 如何计算 localToWorldMatrix ？

### 1）简单的情形：game object没有父节点

先进行scalingMatrix变换，再进行rotationMatrix变换，最后进行translationMatrix变换。

```C#
localToWorldMatrix = translationMatrix * rotationMatrix * scalingMatrix
```

### 2）复杂的情形：game object有父节点

假定game object层级结构如下：  
```
myRoot  
  myHouse  
    theDoor  
```
theDoor的父节点是myHouse，myHouse的父节点是myRoot，myRoot没有父节点。  

transformationMatrix = translationMatrix * rotationMatrix * scalingMatrix  

localToWorldMatrix = transformationMatrix<sub>**myRoot**</sub> \* transformationMatrix<sub>**myHouse**</sub> \* transformationMatrix<sub>**theDoor**</sub>
