#pragma once

#include <iostream>
#include <Windows.h>
#include <msclr/marshal_cppstd.h>
#include <msclr/marshal.h>

using namespace System;
using namespace System::Diagnostics;
using namespace msclr::interop;
using namespace System::Runtime::InteropServices;
using namespace msclr::interop;

namespace SCEngine
{
    public ref class WindowHandlerUtils
    {
    public:
        static array<IntPtr^>^ GetWindowsHandle(array<Process^>^ processes)
        {
            array<IntPtr^>^ handles = gcnew array<IntPtr^>(processes->Length);
            int count = 0;
            for each (Process ^ process in processes) {
                if (!String::IsNullOrEmpty(process->MainWindowTitle))
                {
                    handles[count++] = process->MainWindowHandle;
                }
            }
            return handles;
        }

        static IntPtr^ GetWindowsHandle(Process^ process)
        {
            if (!String::IsNullOrEmpty(process->MainWindowTitle))\
            {
                return process->MainWindowHandle;
            }
            return IntPtr::Zero;
        }

        static void HideTargetWindow(String^ name)
        {
            const wchar_t* windowName = (const wchar_t*)(Marshal::StringToHGlobalUni(name)).ToPointer();
            HWND window;
            window = FindWindow(windowName, NULL);
            ShowWindow(window, SW_HIDE);//隐藏
        }

        static void ShowTargetWindow(String^ name)
        {
            const wchar_t* windowName = (const wchar_t*)(Marshal::StringToHGlobalUni(name)).ToPointer();
            HWND window;
            window = FindWindow(windowName, NULL);
            ShowWindow(window, SW_SHOW);//显示
        }

        static void InsertWindow(IntPtr^ toInsert, IntPtr^ parent) {
            HWND hwndToInsert = (HWND)toInsert->ToInt32();
            HWND hwndParent = (HWND)parent->ToInt32();
            // 将 hwndToInsert 窗口置入 hwndParent 窗口
            SetParent(hwndToInsert, hwndParent);

            // 设置子窗口样式为无边框
            ShowWindow(hwndToInsert, 3);
            LONG_PTR style = GetWindowLongPtr(hwndToInsert, GWL_STYLE);
            SetWindowLongPtr(hwndToInsert, GWL_STYLE, WS_VISIBLE);


            // 调整子窗口的位置和大小以适应父窗口
            RECT rcClient;
            GetClientRect(hwndParent, &rcClient);
            SetWindowPos(hwndToInsert, NULL, 0, 0, rcClient.right, rcClient.bottom, SWP_NOZORDER | SWP_NOACTIVATE);
        }

        static void SetChildWindowPos(IntPtr^ child, IntPtr^ parent)
        {
            HWND hwndToInsert = (HWND)child->ToInt32();
            HWND hwndParent = (HWND)parent->ToInt32();
            RECT rcClient;
            GetClientRect(hwndParent, &rcClient);
            SetWindowPos(hwndToInsert, NULL, 0, 0, rcClient.right, rcClient.bottom, SWP_NOZORDER | SWP_NOACTIVATE);
        }
    };
}
