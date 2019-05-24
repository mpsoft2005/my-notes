# Navigation demo made with Unreal

## Mastering Markdwon

https://guides.github.com/features/mastering-markdown/

## Unreal C++

### Coding Standard
https://docs.unrealengine.com/en-us/Programming/Development/CodingStandard

## Unreal Multithreading

### FRunnable / FRunnableThread
https://api.unrealengine.com/INT/API/Runtime/Core/HAL/FRunnable/index.html
https://api.unrealengine.com/INT/API/Runtime/Core/HAL/FRunnableThread/index.html

### FCriticalSection / FScopeLock
https://api.unrealengine.com/INT/API/Runtime/Core/Unix/FCriticalSection/index.html
https://api.unrealengine.com/INT/API/Runtime/Core/Misc/FScopeLock/index.html
```c++
{
    // Synchronize thread access to the following data
    FScopeLock ScopeLock(SynchObject);
    
    // Access data that is shared among multiple threads
    ...
    // When ScopeLock goes out of scope, other threads can access data
} 
```

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

