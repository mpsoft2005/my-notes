# Unity中的坐标系与变换矩阵

## 坐标系 (Coordinate System)：
1. object space (local space, model space)
2. world space (global space)
3. camera space (eye space, view space)
4. clip space
5. screen space

## 变换矩阵 (Transformation Matrix)
### object space to world space
    a) localToWorldMatrix  
    b) Model Matrix in OpenGL  
### world space to camera space
    a) worldToCameraMatrix  
    b) View Matrix in OpenGL  
### camera space to clip space
    a) projectionMatrix  
    b) Projection Matrix in OpenGL  
### clip space to screen space
    这里不用矩阵，直接映射  

## MVP Matrix
    MVP = Projection * View * Model
