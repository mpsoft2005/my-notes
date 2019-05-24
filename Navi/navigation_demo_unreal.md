# Navigation demo made with Unreal

This note is mainly about Unreal C++ development and Android JNI.

## Unreal C++

### Coding Standard
https://docs.unrealengine.com/en-us/Programming/Development/CodingStandard

### Unreal Engine API Reference
https://api.unrealengine.com/INT/API/index.html

## Unreal Multithreading

### Async / AsyncTask
https://api.unrealengine.com/INT/API/Runtime/Core/Async/index.html
https://api.unrealengine.com/INT/API/Runtime/Core/Async/AsyncTask/index.html

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

### JNI Specification
https://docs.oracle.com/javase/8/docs/technotes/guides/jni/spec/jniTOC.html

### Android JNI tips
https://developer.android.com/training/articles/perf-jni

### Android jni.h
https://github.com/ricardoquesada/android-ndk/blob/master/usr/include/jni.h

### JNI Array code sample
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

### Unreal JNI

#### Unreal JNI code sample
```c++
{
    JNIEnv* Env = FAndroidApplication::GetJavaEnv()

    jobject JavaClass_TestManager = FAndroidApplication::FindJavaClass("com/ben/testlib/TestManager");
    UE_LOG(LogTemp, Warning, TEXT("JavaClass_TestManager=%p"), JavaClass_TestManager);

    jmethodID MethodID_TestManager_init = Env->GetMethodID(JavaClass_TestManager, "<init>", "()V");
    UE_LOG(LogTemp, Warning, TEXT("MethodID_TestManager_init=%p"), MethodID_TestManager_init);
}
```

### jstring to FString
Code sample: Convert JNI's jstring to Unreal's FString
```c++
FString GetFString(JNIEnv* Env, jstring JavaStringObject)
{
	const char* UTFString = Env->GetStringUTFChars(JavaStringObject, 0);
	FString result = FString(UTF8_TO_TCHAR(UTFString));
	Env->ReleaseStringUTFChars(JavaStringObject, UTFString); // release resource, it's very important!
	return result;
}
```
