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

R = Ry * Rx * Rz  

在Unity中需要特别注意的是旋转顺序，[Unity的官方文档](https://docs.unity3d.com/ScriptReference/Quaternion-eulerAngles.html)中有说明，先绕z轴旋转，再绕x轴旋转，最后绕y轴旋转。  



