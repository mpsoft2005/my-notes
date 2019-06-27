# Unity中的坐标系与变换矩阵

## 坐标系 (Coordinate System)：
1. Object space (Local space, Model space)
2. World space (Global space)
3. Camera space (Eye space, View space)
4. Clip space
5. Screen space

## 变换矩阵 (Transformation Matrix)
### Object space to World space
    a) localToWorldMatrix  
    b) Model Matrix in OpenGL  
### World space to Camera space
    a) worldToCameraMatrix  
    b) View Matrix in OpenGL  
### Camera space to Clip space
    a) projectionMatrix  
    b) Projection Matrix in OpenGL  
### Clip space to Screen space
    这里不用矩阵，直接映射  

## MVP Matrix
    MVP Matrix = Projection Matrix * View Matrix * Model Matrix
