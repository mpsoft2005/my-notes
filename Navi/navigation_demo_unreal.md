# Navigation demo made with Unreal

## Mastering Markdwon

https://guides.github.com/features/mastering-markdown/

## Unreal C++

### Coding Standard
https://docs.unrealengine.com/en-us/Programming/Development/CodingStandard

## Unreal Plugin

### Unreal Plugin overview
https://docs.unrealengine.com/en-us/Programming/Plugins

### Unreal Plugin Samples
D:\Program Files\Epic Games\UE_4.21\Engine\Plugins\Developer

## Java Native Interface (JNI)

### Android JNI tips
https://developer.android.com/training/articles/perf-jni

### Android jni.h
https://github.com/ricardoquesada/android-ndk/blob/master/usr/include/jni.h

### JNI Array
```c++
jint Java_IntArray_sumArray(JNIEnv *env, jobject obj, jintArray arr)
{
    int i, sum = 0;
    jsize len = env->GetArrayLength(arr);
    jint *body = env->GetIntArrayElements(arr, 0);
    for (i = 0; i < len; i++)
    {
        sum += body[i];
    }
    env->ReleaseIntArrayElements(arr, body, 0);
    return sum;
}
```

